namespace CarRentalSystem.Domain.Renting.Models
{
    using Common.Models;

    public class RentedCar : Entity<int>
    {
        internal RentedCar(
            string information, 
            int kilometers, 
            bool hasInsurance)
        {
            // TODO: Add validation.

            this.Information = information;
            this.Kilometers = kilometers;
            this.HasInsurance = hasInsurance;
        }

        // Contains the manufacturer and the model of the car.
        public string Information { get; private set; }

        public int Kilometers { get; private set; }

        public bool HasInsurance { get; private set; }
    }
}
