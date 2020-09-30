namespace CarRentalSystem.Infrastructure.Persistence.Models
{
    using Application.Common.Mapping;
    using Domain.Dealerships.Models.CarAds;

    internal class CarData : IMapTo<CarAd>
    {
        public int Id { get; set; }

        public string Model { get; set; } = default!;

        public string ImageUrl { get; set; } = default!;

        public decimal PricePerDay { get; set; }

        public bool IsAvailable { get; set; }

        public int Kilometers { get; private set; }

        public bool HasInsurance { get; private set; }

        public Options Options { get; set; } = default!;

        public int ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; } = default!;

        public int CategoryId { get; set; }

        public Category Category { get; set; } = default!;

        public int DealerId { get; set; }

        public DealerData Dealer { get; set; } = default!;
    }
}
