namespace CarRentalSystem.Infrastructure.Statistics.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Statistics;
    using Application.Statistics.Queries.Current;
    using AutoMapper;
    using Common.Persistence;
    using Domain.Statistics.Models;
    using Domain.Statistics.Repositories;
    using Microsoft.EntityFrameworkCore;

    internal class StatisticsRepository : DataRepository<IStatisticsDbContext, Statistics>,
        IStatisticsDomainRepository,
        IStatisticsQueryRepository
    {
        private readonly IMapper mapper;

        public StatisticsRepository(IStatisticsDbContext db, IMapper mapper)
            : base(db) 
            => this.mapper = mapper;

        public async Task<GetCurrentStatisticsOutputModel> GetCurrent(CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<GetCurrentStatisticsOutputModel>(this.All())
                .SingleOrDefaultAsync(cancellationToken);

        public async Task<int> GetCarAdViews(int carAdId, CancellationToken cancellationToken = default)
            => await this.Data
                .CarAdViews
                .CountAsync(cav => cav.CarAdId == carAdId, cancellationToken);

        public async Task IncrementCarAds(CancellationToken cancellationToken = default)
        {
            var statistics = await this.Data
                .Statistics
                .SingleOrDefaultAsync(cancellationToken);

            statistics.AddCarAd();

            await this.Save(statistics, cancellationToken);
        }
    }
}
