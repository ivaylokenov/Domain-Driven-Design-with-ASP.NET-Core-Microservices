namespace CarRentalSystem.Domain.Renting.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Common.Models;

    public class Driver : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Reservation> reservations;
        private readonly HashSet<Feedback> feedback;

        internal Driver(string license, int yearsOfExperience)
        {
            this.License = license;
            this.YearsOfExperience = yearsOfExperience;

            this.reservations = new HashSet<Reservation>();
            this.feedback = new HashSet<Feedback>();
        }

        public string License { get; private set; }

        public int YearsOfExperience { get; private set; }

        public IReadOnlyCollection<Reservation> Reservations => this.reservations.ToList().AsReadOnly();

        public IReadOnlyCollection<Feedback> Feedback => this.feedback.ToList().AsReadOnly();
    }
}
