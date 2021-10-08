namespace CarRentalSystem.Domain.Dealerships.Exceptions
{
    using Common;

    public class InvalidPhoneNumberException : BaseDomainException
    {
        public InvalidPhoneNumberException()
        {
        }

        public InvalidPhoneNumberException(string error) => this.Error = error;
    }
}
