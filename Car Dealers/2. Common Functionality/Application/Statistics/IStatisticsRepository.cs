namespace CarRentalSystem.Application.Statistics
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Contracts;
    using Domain.Statistics.Models;
    using Queries.Current;

    public interface IStatisticsRepository : IRepository<Statistics>
    {
        Task<GetCurrentStatisticsOutputModel> GetCurrent(CancellationToken cancellationToken = default);

        Task<int> GetCarAdViews(int carAdId, CancellationToken cancellationToken = default);

        Task IncrementCarAds(CancellationToken cancellationToken = default);
    }
}
