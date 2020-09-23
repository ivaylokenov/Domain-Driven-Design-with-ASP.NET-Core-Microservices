namespace CarRentalSystem.Application.Dealerships.CarAds
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Contracts;
    using Domain.Common;
    using Domain.Dealerships.Models.CarAds;
    using Domain.Dealerships.Models.Dealers;
    using Queries.Categories;
    using Queries.Common;
    using Queries.Details;

    public interface ICarAdQueryRepository : IQueryRepository<CarAd>
    {
        Task<IEnumerable<TOutputModel>> GetCarAdListings<TOutputModel>(
            Specification<CarAd> carAdSpecification,
            Specification<Dealer> dealerSpecification,
            CarAdsSortOrder carAdsSortOrder,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);

        Task<CarAdDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<GetCarAdCategoryOutputModel>> GetCarAdCategories(
            CancellationToken cancellationToken = default);

        Task<int> Total(
            Specification<CarAd> carAdSpecification,
            Specification<Dealer> dealerSpecification, 
            CancellationToken cancellationToken = default);
    }
}
