namespace CarRentalSystem.Domain.Factories.Dealers
{
    using Models.Dealers;

    public interface IDealerFactory : IFactory<Dealer>
    {
        IDealerFactory WithName(string name);

        IDealerFactory WithPhoneNumber(string phoneNumber);
    }
}
