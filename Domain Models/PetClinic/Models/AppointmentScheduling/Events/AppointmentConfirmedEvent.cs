namespace PetClinic.Models.AppointmentScheduling.Events
{
    using System;
    using Common;
    using Models.Schedule;

    public class AppointmentConfirmedEvent : IDomainEvent
    {
        internal AppointmentConfirmedEvent(Appointment appointment) 
            : this() 
            => this.AppointmentUpdated = appointment;

        internal AppointmentConfirmedEvent()
        {
            this.Id = Guid.NewGuid();

            this.DateTimeEventOccurred = DateTime.UtcNow;
        }

        public Guid Id { get; }

        public DateTime DateTimeEventOccurred { get; }

        public Appointment? AppointmentUpdated { get; }
    }
}