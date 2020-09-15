namespace CarRentalSystem.Infrastructure.Common.Events
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using Application.Common;
    using Domain.Common;
    using Microsoft.Extensions.DependencyInjection;

    public class EventDispatcher : IEventDispatcher
    {
        private static readonly ConcurrentDictionary<Type, IEnumerable<Func<object, Task>>> HandlersCache
            = new ConcurrentDictionary<Type, IEnumerable<Func<object, Task>>>();

        private static readonly Type HandlerType = typeof(IEventHandler<>);

        private static readonly MethodInfo MakeDelegateMethod = typeof(EventDispatcher)
            .GetMethod(nameof(MakeDelegate), BindingFlags.Static | BindingFlags.NonPublic)!;

        private static readonly Type OpenGenericFuncType = typeof(Func<,>);

        private static readonly Type TaskType = typeof(Task);

        private readonly IServiceProvider serviceProvider;

        public EventDispatcher(IServiceProvider serviceProvider)
            => this.serviceProvider = serviceProvider;

        public async Task Dispatch(IDomainEvent domainEvent)
        {
            var eventHandlers = HandlersCache.GetOrAdd(domainEvent.GetType(), eventType =>
            {
                var eventHandlerType = HandlerType.MakeGenericType(eventType);

                var makeDelegate = MakeDelegateMethod.MakeGenericMethod(eventType);

                var funcType = OpenGenericFuncType.MakeGenericType(eventType, TaskType);

                return this.serviceProvider
                    .GetServices(eventHandlerType)
                    .Select(handler => handler
                        .GetType()
                        .GetMethod("Handle")!
                        .CreateDelegate(funcType, handler))
                    .Select(handlerDelegateConcrete => (Func<object, Task>)makeDelegate
                        .Invoke(null, new object[] { handlerDelegateConcrete })!)
                    .ToList();
            });

            foreach (var eventHandler in eventHandlers)
            {
                await eventHandler(domainEvent);
            }
        }

        private static Func<object, Task> MakeDelegate<T>(Func<T, Task> action)
            => value => action((T)value);
    }
}
