namespace PetClinic.Models.AppointmentScheduling.Events
{
    using System;
    using Common;
    using Models.Schedule;

    public class AppointmentScheduledEvent : IDomainEvent
    {
        internal AppointmentScheduledEvent(Appointment appointment) 
            : this() 
            => this.AppointmentScheduled = appointment;

        internal AppointmentScheduledEvent()
        {
            this.Id = Guid.NewGuid();

            this.DateTimeEventOccurred = DateTime.UtcNow;
        }

        public Guid Id { get; }

        public DateTime DateTimeEventOccurred { get; }

        public Appointment? AppointmentScheduled { get; }
    }
}