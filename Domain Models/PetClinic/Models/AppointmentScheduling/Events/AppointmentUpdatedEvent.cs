namespace PetClinic.Models.AppointmentScheduling.Events
{
    using System;
    using Common;
    using Models.Schedule;

    public class AppointmentUpdatedEvent : IDomainEvent
    {
        internal AppointmentUpdatedEvent(Appointment appointment)
            : this() 
            => this.AppointmentUpdated = appointment;

        internal AppointmentUpdatedEvent()
        {
            this.Id = Guid.NewGuid();

            this.DateTimeEventOccurred = DateTime.UtcNow;
        }

        public Guid Id { get; }

        public DateTime DateTimeEventOccurred { get; }

        public Appointment? AppointmentUpdated { get; }
    }
}