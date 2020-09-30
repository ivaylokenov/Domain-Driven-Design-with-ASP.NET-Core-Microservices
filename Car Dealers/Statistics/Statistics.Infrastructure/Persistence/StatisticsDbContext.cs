namespace CarRentalSystem.Infrastructure.Statistics.Persistence
{
    using System.Reflection;
    using Domain.Statistics.Models;
    using Microsoft.EntityFrameworkCore;

    public class StatisticsDbContext : DbContext,
        IStatisticsDbContext
    {
        public StatisticsDbContext(DbContextOptions<StatisticsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Statistics> Statistics { get; set; } = default!;

        public DbSet<CarAdView> CarAdViews { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
