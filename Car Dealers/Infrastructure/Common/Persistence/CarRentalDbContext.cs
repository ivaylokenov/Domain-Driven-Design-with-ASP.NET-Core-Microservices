namespace CarRentalSystem.Infrastructure.Common.Persistence
{
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Dealership;
    using Domain.Common.Models;
    using Domain.Dealerships.Models.CarAds;
    using Domain.Dealerships.Models.Dealers;
    using Domain.Statistics.Models;
    using Events;
    using Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Statistics;

    internal class CarRentalDbContext : IdentityDbContext<User>,
        IDealershipDbContext,
        IStatisticsDbContext
    {
        private readonly IEventDispatcher eventDispatcher;
        private bool eventsDispatched;

        public CarRentalDbContext(
            DbContextOptions<CarRentalDbContext> options,
            IEventDispatcher eventDispatcher)
            : base(options)
        {
            this.eventDispatcher = eventDispatcher;

            this.eventsDispatched = false;
        }

        public DbSet<CarAd> CarAds { get; set; } = default!;

        public DbSet<Category> Categories { get; set; } = default!;

        public DbSet<Manufacturer> Manufacturers { get; set; } = default!;

        public DbSet<Dealer> Dealers { get; set; } = default!;

        public DbSet<Statistics> Statistics { get; set; } = default!;

        public DbSet<CarAdView> CarAdViews { get; set; } = default!;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entriesModified = 0;

            if (!this.eventsDispatched)
            {
                var entities = this.ChangeTracker
                    .Entries<IEntity>()
                    .Select(e => e.Entity)
                    .Where(e => e.Events.Any())
                    .ToArray();

                foreach (var entity in entities)
                {
                    var events = entity.Events.ToArray();

                    entity.ClearEvents();

                    foreach (var domainEvent in events)
                    {
                        await this.eventDispatcher.Dispatch(domainEvent);
                    }
                }

                this.eventsDispatched = true;

                entriesModified = await base.SaveChangesAsync(cancellationToken);
            }

            return entriesModified;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
