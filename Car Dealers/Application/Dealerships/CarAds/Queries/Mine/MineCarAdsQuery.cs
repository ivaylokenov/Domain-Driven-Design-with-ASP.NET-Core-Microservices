namespace CarRentalSystem.Application.Dealerships.CarAds.Queries.Mine
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Contracts;
    using Common;
    using Domain.Dealerships.Repositories;
    using MediatR;

    public class MineCarAdsQuery : CarAdsQuery, IRequest<MineCarAdsOutputModel>
    {
        public class MineCarAdsQueryHandler : CarAdsQueryHandler, IRequestHandler<
            MineCarAdsQuery,
            MineCarAdsOutputModel>
        {
            private readonly IDealerDomainRepository dealerRepository;
            private readonly ICurrentUser currentUser;

            public MineCarAdsQueryHandler(
                ICarAdQueryRepository carAdRepository, 
                IDealerDomainRepository dealerRepository,
                ICurrentUser currentUser)
                : base(carAdRepository)
            {
                this.currentUser = currentUser;
                this.dealerRepository = dealerRepository;
            }

            public async Task<MineCarAdsOutputModel> Handle(
                MineCarAdsQuery request,
                CancellationToken cancellationToken)
            {
                var dealerId = await this.dealerRepository.GetDealerId(
                    this.currentUser.UserId, 
                    cancellationToken);

                var mineCarAdListings = await base.GetCarAdListings<MineCarAdOutputModel>(
                    request,
                    onlyAvailable: false,
                    dealerId,
                    cancellationToken);

                var totalPages = await base.GetTotalPages(
                    request,
                    onlyAvailable: false,
                    dealerId,
                    cancellationToken);

                return new MineCarAdsOutputModel(mineCarAdListings, request.Page, totalPages);
            }
        }
    }
}
