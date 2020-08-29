namespace Blog.Infrastructure.IntegrationTests.Events
{
    using System;
    using System.Threading.Tasks;
    using Domain.Events;
    using Infrastructure.Services;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class EventDispatcherTests
    {
        [Fact]
        public async Task DispatchShouldDispatchEvents()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IEventHandler<ArticleEvent>, ArticleEventHandler>();

            var dispatcher = new EventDispatcherService(serviceCollection.BuildServiceProvider());

            var domainEvent = new ArticleEvent();

            await dispatcher.Dispatch(domainEvent);

            Assert.True(domainEvent.Handled);
        }

        private class ArticleEvent : IDomainEvent
        {
            public bool Handled { get; set; }

            public DateTime OccurredOn => DateTime.Now;
        }

        private class ArticleEventHandler : IEventHandler<ArticleEvent>
        {
            public Task Handle(ArticleEvent domainEvent)
            {
                domainEvent.Handled = true;
                return Task.CompletedTask;
            }
        }
    }
}
