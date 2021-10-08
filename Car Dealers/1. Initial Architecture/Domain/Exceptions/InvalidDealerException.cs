namespace CarRentalSystem.Domain.Exceptions
{
    public class InvalidDealerException : BaseDomainException
    {
        public InvalidDealerException()
        {
        }

        public InvalidDealerException(string error) => this.Error = error;
    }
}
