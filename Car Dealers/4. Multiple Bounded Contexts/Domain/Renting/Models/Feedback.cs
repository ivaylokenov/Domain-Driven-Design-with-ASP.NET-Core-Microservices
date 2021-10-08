namespace CarRentalSystem.Domain.Renting.Models
{
    using Common.Models;

    public class Feedback : Entity<int>
    {
        internal Feedback(string content, Reservation reservation)
        {
            // TODO: Add validation.
            // this.Validate(content);

            this.Content = content;
            this.Reservation = reservation;
        }

        public string Content { get; private set; }

        public Reservation Reservation { get; private set; }
    }
}
