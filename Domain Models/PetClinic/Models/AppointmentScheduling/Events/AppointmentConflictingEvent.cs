namespace PetClinic.Models.AppointmentScheduling.Events
{
    using System;
    using System.Collections.Generic;
    using Common;

    public class AppointmentConflictingEvent : IDomainEvent
    {
        internal AppointmentConflictingEvent(List<Guid> conflictingAppointments)
        {
            this.Id = Guid.NewGuid();

            this.DateTimeEventOccurred = DateTime.UtcNow;

            this.ConflictingAppointments = conflictingAppointments.AsReadOnly();
        }

        public Guid Id { get; }

        public DateTime DateTimeEventOccurred { get; }

        public IReadOnlyList<Guid> ConflictingAppointments { get; }
    }
}
