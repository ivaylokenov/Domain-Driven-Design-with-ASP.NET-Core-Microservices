namespace CarRentalSystem.Domain.Renting.Models
{
    using Common.Models;

    public class Reservation : Entity<int>
    {
        internal Reservation(DateTimeRange timeRange, RentedCar rentedCar)
        {
            // TODO: Add validation.

            this.TimeRange = timeRange;
            this.RentedCar = rentedCar;
        }

        public DateTimeRange TimeRange { get; private set; }

        public RentedCar RentedCar { get; private set; }
    }
}
