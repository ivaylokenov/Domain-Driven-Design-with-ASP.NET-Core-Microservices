namespace CarRentalSystem.Domain.Dealerships.Exceptions
{
    using Common;

    public class InvalidCarAdException : BaseDomainException
    {
        public InvalidCarAdException()
        {
        }

        public InvalidCarAdException(string error) => this.Error = error;
    }
}
