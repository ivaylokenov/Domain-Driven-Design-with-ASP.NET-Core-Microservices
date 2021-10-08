namespace CarRentalSystem.Domain.Factories.CarAds
{
    using Models.CarAds;

    public interface ICarAdFactory : IFactory<CarAd>
    {
        ICarAdFactory WithManufacturer(string name);

        ICarAdFactory WithManufacturer(Manufacturer manufacturer);

        ICarAdFactory WithModel(string model);

        ICarAdFactory WithCategory(string name, string description);

        ICarAdFactory WithCategory(Category category);

        ICarAdFactory WithImageUrl(string imageUrl);

        ICarAdFactory WithPricePerDay(decimal pricePerDay);

        ICarAdFactory WithOptions(
            bool hasClimateControl, 
            int numberOfSeats, 
            TransmissionType transmissionType);
    }
}
