namespace CarRentalSystem.Application.Dealerships.CarAds.Commands.ChangeAvailability
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Common.Contracts;
    using Common;
    using Domain.Dealerships.Repositories;
    using MediatR;

    public class ChangeAvailabilityCommand : EntityCommand<int>, IRequest<Result>
    {
        public class ChangeAvailabilityCommandHandler : IRequestHandler<ChangeAvailabilityCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly ICarAdDomainRepository carAdRepository;
            private readonly IDealerDomainRepository dealerRepository;

            public ChangeAvailabilityCommandHandler(
                ICurrentUser currentUser,
                ICarAdDomainRepository carAdRepository,
                IDealerDomainRepository dealerRepository)
            {
                this.currentUser = currentUser;
                this.carAdRepository = carAdRepository;
                this.dealerRepository = dealerRepository;
            }

            public async Task<Result> Handle(
                ChangeAvailabilityCommand request, 
                CancellationToken cancellationToken)
            {
                var dealerHasCar = await this.currentUser.DealerHasCarAd(
                    this.dealerRepository,
                    request.Id,
                    cancellationToken);

                if (!dealerHasCar)
                {
                    return dealerHasCar;
                }

                var carAd = await this.carAdRepository
                    .Find(request.Id, cancellationToken);

                carAd.ChangeAvailability();

                await this.carAdRepository.Save(carAd, cancellationToken);

                return Result.Success;
            }
        }
    }
}
