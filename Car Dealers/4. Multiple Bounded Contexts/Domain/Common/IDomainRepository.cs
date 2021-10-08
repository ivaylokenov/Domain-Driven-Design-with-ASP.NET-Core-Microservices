namespace CarRentalSystem.Domain.Common
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IDomainRepository<in TEntity>
        where TEntity : IAggregateRoot
    {
        Task Save(TEntity entity, CancellationToken cancellationToken = default);
    }
}
