namespace CarRentalSystem.Infrastructure.Dealership.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Dealerships.CarAds;
    using Application.Dealerships.CarAds.Queries.Categories;
    using Application.Dealerships.CarAds.Queries.Common;
    using Application.Dealerships.CarAds.Queries.Details;
    using AutoMapper;
    using Common;
    using Common.Persistence;
    using Domain.Common;
    using Domain.Dealerships.Models.CarAds;
    using Domain.Dealerships.Models.Dealers;
    using Microsoft.EntityFrameworkCore;

    internal class CarAdRepository : DataRepository<IDealershipDbContext, CarAd>, ICarAdRepository
    {
        private readonly IMapper mapper;

        public CarAdRepository(IDealershipDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<CarAd> Find(int id, CancellationToken cancellationToken = default)
            => await this
                .All()
                .Include(c => c.Manufacturer)
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var carAd = await this.Data.CarAds.FindAsync(id);

            if (carAd == null)
            {
                return false;
            }

            this.Data.CarAds.Remove(carAd);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<IEnumerable<TOutputModel>> GetCarAdListings<TOutputModel>(
            Specification<CarAd> carAdSpecification,
            Specification<Dealer> dealerSpecification,
            CarAdsSortOrder carAdsSortOrder,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default)
            => (await this.mapper
                .ProjectTo<TOutputModel>(this
                    .GetCarAdsQuery(carAdSpecification, dealerSpecification)
                    .Sort(carAdsSortOrder))
                .ToListAsync(cancellationToken))
                .Skip(skip)
                .Take(take); // EF Core bug forces me to execute paging on the client.

        public async Task<CarAdDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<CarAdDetailsOutputModel>(this
                    .AllAvailable()
                    .Where(c => c.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<Category> GetCategory(
            int categoryId,
            CancellationToken cancellationToken = default)
            => await this
                .Data
                .Categories
                .FirstOrDefaultAsync(c => c.Id == categoryId, cancellationToken);

        public async Task<Manufacturer> GetManufacturer(
            string manufacturer,
            CancellationToken cancellationToken = default)
            => await this
                .Data
                .Manufacturers
                .FirstOrDefaultAsync(m => m.Name == manufacturer, cancellationToken);

        public async Task<IEnumerable<GetCarAdCategoryOutputModel>> GetCarAdCategories(
            CancellationToken cancellationToken = default)
        {
            var categories = await this.mapper
                .ProjectTo<GetCarAdCategoryOutputModel>(this.Data.Categories)
                .ToDictionaryAsync(k => k.Id, cancellationToken);

            var carAdsPerCategory = await this.AllAvailable()
                .GroupBy(c => c.Category.Id)
                .Select(gr => new
                {
                    CategoryId = gr.Key,
                    TotalCarAds = gr.Count()
                })
                .ToListAsync(cancellationToken);

            carAdsPerCategory.ForEach(c => categories[c.CategoryId].TotalCarAds = c.TotalCarAds);

            return categories.Values;
        }

        public async Task<int> Total(
            Specification<CarAd> carAdSpecification,
            Specification<Dealer> dealerSpecification,
            CancellationToken cancellationToken = default)
            => await this
                .GetCarAdsQuery(carAdSpecification, dealerSpecification)
                .CountAsync(cancellationToken);

        private IQueryable<CarAd> AllAvailable()
            => this
                .All()
                .Where(car => car.IsAvailable);

        private IQueryable<CarAd> GetCarAdsQuery(
            Specification<CarAd> carAdSpecification,
            Specification<Dealer> dealerSpecification)
            => this
                .Data
                .Dealers
                .Where(dealerSpecification)
                .SelectMany(d => d.CarAds)
                .Where(carAdSpecification);
    }
}
