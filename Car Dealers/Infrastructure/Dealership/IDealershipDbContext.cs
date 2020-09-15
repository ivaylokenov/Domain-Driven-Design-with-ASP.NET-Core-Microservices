namespace CarRentalSystem.Infrastructure.Dealership
{
    using Common.Persistence;
    using Domain.Dealerships.Models.CarAds;
    using Domain.Dealerships.Models.Dealers;
    using Identity;
    using Microsoft.EntityFrameworkCore;

    public interface IDealershipDbContext : IDbContext
    {
        DbSet<CarAd> CarAds { get; }

        DbSet<Category> Categories { get; }

        DbSet<Manufacturer> Manufacturers { get; }

        DbSet<Dealer> Dealers { get; }

        DbSet<User> Users { get; } // TODO: Temporary workaround
    }
}
