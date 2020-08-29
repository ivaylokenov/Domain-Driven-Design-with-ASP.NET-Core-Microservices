namespace CarRentalSystem.Application.Features.CarAds.Commands.Common
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Contracts;
    using Dealers;

    internal static class ChangeCarAdCommandExtensions
    {
        public static async Task<Result> DealerHasCarAd(
            this ICurrentUser currentUser,
            IDealerRepository dealerRepository,
            int carAdId,
            CancellationToken cancellationToken)
        {
            var dealerId = await dealerRepository.GetDealerId(
                currentUser.UserId,
                cancellationToken);

            var dealerHasCar = await dealerRepository.HasCarAd(
                dealerId,
                carAdId,
                cancellationToken);

            return dealerHasCar
                ? Result.Success
                : "You cannot edit this car ad.";
        }
    }
}
