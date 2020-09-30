namespace CarRentalSystem.Infrastructure.Dealership
{
    using Common.Persistence;
    using Persistence;
    using Domain.Dealerships.Models.CarAds;
    using Domain.Dealerships.Models.Dealers;
    using Microsoft.EntityFrameworkCore;

    internal interface IDealershipDbContext : IDbContext
    {
        DbSet<CarAd> CarAds { get; }

        DbSet<Category> Categories { get; }

        DbSet<Manufacturer> Manufacturers { get; }

        DbSet<Dealer> Dealers { get; }
    }
}
