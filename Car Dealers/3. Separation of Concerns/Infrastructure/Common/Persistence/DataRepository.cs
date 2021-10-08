namespace CarRentalSystem.Infrastructure.Common.Persistence
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Contracts;
    using Domain.Common;

    internal abstract class DataRepository<TDbContext, TEntity> : IDomainRepository<TEntity>
        where TDbContext : IDbContext
        where TEntity : class, IAggregateRoot
    {
        protected DataRepository(TDbContext db) => this.Data = db;

        protected TDbContext Data { get; }

        protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        public async Task Save(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            this.Data.Update(entity);

            await this.Data.SaveChangesAsync(cancellationToken);
        }
    }
}
