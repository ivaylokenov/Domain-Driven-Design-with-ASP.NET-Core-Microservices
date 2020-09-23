namespace CarRentalSystem.Infrastructure.Common.Persistence
{
    using System.Collections.Generic;
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
        private readonly Stack<object> savesChangesTracker;

        public CarRentalDbContext(
            DbContextOptions<CarRentalDbContext> options,
            IEventDispatcher eventDispatcher)
            : base(options)
        {
            this.eventDispatcher = eventDispatcher;

            this.savesChangesTracker = new Stack<object>();
        }

        public DbSet<CarAd> CarAds { get; set; } = default!;

        public DbSet<Category> Categories { get; set; } = default!;

        public DbSet<Manufacturer> Manufacturers { get; set; } = default!;

        public DbSet<Dealer> Dealers { get; set; } = default!;

        public DbSet<Statistics> Statistics { get; set; } = default!;

        public DbSet<CarAdView> CarAdViews { get; set; } = default!;

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            this.savesChangesTracker.Push(new object());

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

            this.savesChangesTracker.Pop();

            if (!this.savesChangesTracker.Any())
            {
                return await base.SaveChangesAsync(cancellationToken);
            }

            return 0;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
