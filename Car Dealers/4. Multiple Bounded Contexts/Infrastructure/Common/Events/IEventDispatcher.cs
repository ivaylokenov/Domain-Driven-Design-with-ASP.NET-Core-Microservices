namespace CarRentalSystem.Infrastructure.Common.Events
{
    using System.Threading.Tasks;
    using Domain.Common;

    internal interface IEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
    }
}
