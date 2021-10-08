namespace CarRentalSystem.Application.Identity
{
    using Domain.Dealerships.Models.Dealers;

    public interface IUser
    {
        void BecomeDealer(Dealer dealer);
    }
}
