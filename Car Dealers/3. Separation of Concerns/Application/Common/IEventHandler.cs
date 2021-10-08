namespace CarRentalSystem.Application.Common
{
    using System.Threading.Tasks;
    using Domain.Common;

    public interface IEventHandler<in TEvent>
        where TEvent : IDomainEvent
    {
        Task Handle(TEvent domainEvent);
    }
}
