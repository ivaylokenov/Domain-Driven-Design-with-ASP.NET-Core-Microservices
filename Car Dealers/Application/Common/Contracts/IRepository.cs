namespace CarRentalSystem.Application.Common.Contracts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Common;

    public interface IRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
        Task Save(TEntity entity, CancellationToken cancellationToken = default);
    }
}
