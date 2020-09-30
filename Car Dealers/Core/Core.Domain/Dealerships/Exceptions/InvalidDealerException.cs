namespace CarRentalSystem.Domain.Dealerships.Exceptions
{
    using Common;

    public class InvalidDealerException : BaseDomainException
    {
        public InvalidDealerException()
        {
        }

        public InvalidDealerException(string error) => this.Error = error;
    }
}
