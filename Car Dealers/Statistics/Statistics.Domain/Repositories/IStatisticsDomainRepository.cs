namespace CarRentalSystem.Domain.Statistics.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Models;

    public interface IStatisticsDomainRepository : IDomainRepository<Statistics>
    {
        Task IncrementCarAds(CancellationToken cancellationToken = default);
    }
}
