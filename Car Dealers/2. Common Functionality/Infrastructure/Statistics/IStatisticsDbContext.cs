namespace CarRentalSystem.Infrastructure.Statistics
{
    using Common.Persistence;
    using Domain.Statistics.Models;
    using Microsoft.EntityFrameworkCore;

    public interface IStatisticsDbContext : IDbContext
    {
        DbSet<Statistics> Statistics { get; }

        DbSet<CarAdView> CarAdViews { get; }
    }
}
