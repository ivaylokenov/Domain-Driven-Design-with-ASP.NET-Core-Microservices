namespace Blog.Domain.Events
{
    using System.Threading.Tasks;

    public interface IEventHandler<in TEvent>
        where TEvent : IDomainEvent
    {
        Task Handle(TEvent domainEvent);
    }
}
