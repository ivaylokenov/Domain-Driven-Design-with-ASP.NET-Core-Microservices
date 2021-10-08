namespace CarRentalSystem.Application.Features.Identity
{
    using Domain.Models.Dealers;

    public interface IUser
    {
        void BecomeDealer(Dealer dealer);
    }
}
