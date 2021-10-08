namespace CarRentalSystem.Infrastructure.Common.Events
{
    using System.Threading.Tasks;
    using Domain.Common;

    public interface IEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
    }
}
