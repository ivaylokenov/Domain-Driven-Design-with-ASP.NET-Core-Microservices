namespace CarRentalSystem.Application.Features.CarAds.Queries.Search
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using MediatR;

    public class SearchCarAdsQuery : CarAdsQuery, IRequest<SearchCarAdsOutputModel>
    {
        public class SearchCarAdsQueryHandler : CarAdsQueryHandler, IRequestHandler<
            SearchCarAdsQuery, 
            SearchCarAdsOutputModel>
        {
            public SearchCarAdsQueryHandler(ICarAdRepository carAdRepository)
                : base(carAdRepository)
            {
            }

            public async Task<SearchCarAdsOutputModel> Handle(
                SearchCarAdsQuery request,
                CancellationToken cancellationToken)
            {
                var carAdListings = await base.GetCarAdListings<CarAdOutputModel>(
                    request,
                    cancellationToken: cancellationToken);

                var totalPages = await base.GetTotalPages(
                    request,
                    cancellationToken: cancellationToken);

                return new SearchCarAdsOutputModel(carAdListings, request.Page, totalPages);
            }
        }
    }
}
