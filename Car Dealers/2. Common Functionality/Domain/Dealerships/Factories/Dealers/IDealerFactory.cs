namespace CarRentalSystem.Domain.Dealerships.Factories.Dealers
{
    using Common;
    using Models.Dealers;

    public interface IDealerFactory : IFactory<Dealer>
    {
        IDealerFactory WithName(string name);

        IDealerFactory WithPhoneNumber(string phoneNumber);
    }
}
