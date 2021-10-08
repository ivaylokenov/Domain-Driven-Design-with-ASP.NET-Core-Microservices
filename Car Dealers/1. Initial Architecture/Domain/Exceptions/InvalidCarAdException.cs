namespace CarRentalSystem.Domain.Exceptions
{
    public class InvalidCarAdException : BaseDomainException
    {
        public InvalidCarAdException()
        {
        }

        public InvalidCarAdException(string error) => this.Error = error;
    }
}
