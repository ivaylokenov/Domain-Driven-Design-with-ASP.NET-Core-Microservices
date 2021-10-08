namespace CarRentalSystem.Application.Features.CarAds.Commands.Common
{
    public abstract class CarAdCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string Manufacturer { get; set; } = default!;

        public string Model { get; set; } = default!;

        public int Category { get; set; }

        public string ImageUrl { get; set; } = default!;

        public decimal PricePerDay { get; set; }

        public bool HasClimateControl { get; set; }

        public int NumberOfSeats { get; set; }

        public int TransmissionType { get; set; }
    }
}
