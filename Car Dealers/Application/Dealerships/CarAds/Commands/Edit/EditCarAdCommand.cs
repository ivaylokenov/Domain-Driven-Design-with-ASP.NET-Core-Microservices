namespace CarRentalSystem.Application.Dealerships.CarAds.Commands.Edit
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Common.Contracts;
    using Common;
    using Domain.Common.Models;
    using Domain.Dealerships.Models.CarAds;
    using Domain.Dealerships.Repositories;
    using MediatR;

    public class EditCarAdCommand : CarAdCommand<EditCarAdCommand>, IRequest<Result>
    {
        public class EditCarAdCommandHandler : IRequestHandler<EditCarAdCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly ICarAdDomainRepository carAdRepository;
            private readonly IDealerDomainRepository dealerRepository;

            public EditCarAdCommandHandler(
                ICurrentUser currentUser, 
                ICarAdDomainRepository carAdRepository, 
                IDealerDomainRepository dealerRepository)
            {
                this.currentUser = currentUser;
                this.carAdRepository = carAdRepository;
                this.dealerRepository = dealerRepository;
            }

            public async Task<Result> Handle(
                EditCarAdCommand request, 
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

                var category = await this.carAdRepository.GetCategory(
                    request.Category, 
                    cancellationToken);

                var carAd = await this.carAdRepository
                    .Find(request.Id, cancellationToken);

                carAd
                    .UpdateManufacturer(request.Manufacturer)
                    .UpdateModel(request.Model)
                    .UpdateCategory(category)
                    .UpdateImageUrl(request.ImageUrl)
                    .UpdatePricePerDay(request.PricePerDay)
                    .UpdateOptions(
                        request.HasClimateControl,
                        request.NumberOfSeats,
                        Enumeration.FromValue<TransmissionType>(request.TransmissionType));

                await this.carAdRepository.Save(carAd, cancellationToken);

                return Result.Success;
            }
        }
    }
}
