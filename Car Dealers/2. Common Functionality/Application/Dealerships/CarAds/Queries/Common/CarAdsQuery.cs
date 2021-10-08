namespace CarRentalSystem.Application.Dealerships.CarAds.Queries.Common
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Common;
    using Domain.Dealerships.Models.CarAds;
    using Domain.Dealerships.Models.Dealers;
    using Domain.Dealerships.Specifications.CarAds;
    using Domain.Dealerships.Specifications.Dealers;

    public abstract class CarAdsQuery
    {
        private const int CarAdsPerPage = 10;

        public string? Manufacturer { get; set; }

        public int? Category { get; set; }

        public string? Dealer { get; set; }

        public decimal? MinPricePerDay { get; set; }

        public decimal? MaxPricePerDay { get; set; }

        public string? SortBy { get; set; }

        public string? Order { get; set; }

        public int Page { get; set; } = 1;

        public abstract class CarAdsQueryHandler
        {
            private readonly ICarAdRepository carAdRepository;

            protected CarAdsQueryHandler(ICarAdRepository carAdRepository)
                => this.carAdRepository = carAdRepository;

            protected async Task<IEnumerable<TOutputModel>> GetCarAdListings<TOutputModel>(
                CarAdsQuery request,
                bool onlyAvailable = true,
                int? dealerId = default,
                CancellationToken cancellationToken = default)
            {
                var carAdSpecification = this.GetCarAdSpecification(request, onlyAvailable);

                var dealerSpecification = this.GetDealerSpecification(request, dealerId);

                var searchOrder = new CarAdsSortOrder(request.SortBy, request.Order);

                var skip = (request.Page - 1) * CarAdsPerPage;

                return await this.carAdRepository.GetCarAdListings<TOutputModel>(
                    carAdSpecification,
                    dealerSpecification,
                    searchOrder,
                    skip,
                    take: CarAdsPerPage,
                    cancellationToken);
            }

            protected async Task<int> GetTotalPages(
                CarAdsQuery request,
                bool onlyAvailable = true,
                int? dealerId = default,
                CancellationToken cancellationToken = default)
            {
                var carAdSpecification = this.GetCarAdSpecification(request, onlyAvailable);

                var dealerSpecification = this.GetDealerSpecification(request, dealerId);

                var totalCarAds = await this.carAdRepository.Total(
                    carAdSpecification,
                    dealerSpecification,
                    cancellationToken);

                return (int)Math.Ceiling((double)totalCarAds/CarAdsPerPage);
            }

            private Specification<CarAd> GetCarAdSpecification(CarAdsQuery request, bool onlyAvailable)
                => new CarAdByManufacturerSpecification(request.Manufacturer)
                    .And(new CarAdByCategorySpecification(request.Category))
                    .And(new CarAdByPricePerDaySpecification(request.MinPricePerDay, request.MaxPricePerDay))
                    .And(new CadAdOnlyAvailableSpecification(onlyAvailable));

            private Specification<Dealer> GetDealerSpecification(CarAdsQuery request, int? dealerId)
                => new DealerByIdSpecification(dealerId)
                    .And(new DealerByNameSpecification(request.Dealer));
        }
    }
}
