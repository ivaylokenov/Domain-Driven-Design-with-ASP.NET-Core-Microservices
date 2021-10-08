namespace CarRentalSystem.Application.Dealerships.CarAds.Queries.Details
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Dealers;
    using MediatR;

    public class CarAdDetailsQuery : EntityCommand<int>, IRequest<CarAdDetailsOutputModel>
    {
        public class CarAdDetailsQueryHandler : IRequestHandler<CarAdDetailsQuery, CarAdDetailsOutputModel>
        {
            private readonly ICarAdRepository carAdRepository;
            private readonly IDealerRepository dealerRepository;

            public CarAdDetailsQueryHandler(
                ICarAdRepository carAdRepository, 
                IDealerRepository dealerRepository)
            {
                this.carAdRepository = carAdRepository;
                this.dealerRepository = dealerRepository;
            }

            public async Task<CarAdDetailsOutputModel> Handle(
                CarAdDetailsQuery request, 
                CancellationToken cancellationToken)
            {
                var carAdDetails = await this.carAdRepository.GetDetails(
                    request.Id,
                    cancellationToken);

                carAdDetails.Dealer = await this.dealerRepository.GetDetailsByCarId(
                    request.Id,
                    cancellationToken);

                return carAdDetails;
            }
        }
    }
}
