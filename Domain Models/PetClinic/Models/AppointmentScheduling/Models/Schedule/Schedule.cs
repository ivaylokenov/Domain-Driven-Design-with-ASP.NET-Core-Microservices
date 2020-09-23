namespace PetClinic.Models.AppointmentScheduling.Models.Schedule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Common.Models;
    using Events;
    using Shared;

    public class Schedule : Entity<int>, IAggregateRoot
    {
        private readonly List<Appointment> appointments;

        // From another bounded context.
        public int ClinicId { get; private set; }

        public DateTimeRange DateRange { get; private set; }

        public IReadOnlyList<Appointment> Appointments 
            => this.appointments.AsReadOnly();

        internal Schedule(
            int clinicId,
            DateTimeRange dateRange,
            IEnumerable<Appointment> appointments)
        {
            this.DateRange = dateRange;
            this.ClinicId = clinicId;

            this.appointments = new List<Appointment>(appointments);

            this.MarkConflictingAppointments();
        }

        public Appointment AddNewAppointment(Appointment appointment)
        {
            if (this.appointments.Any(a => a.Id == appointment.Id))
            {
                throw new ArgumentException("Cannot add duplicate appointment to schedule.", "appointment");
            }

            this.appointments.Add(appointment);

            this.MarkConflictingAppointments();

            var appointmentScheduledEvent = new AppointmentScheduledEvent(appointment);

            this.RaiseEvent(appointmentScheduledEvent);

            return appointment;
        }

        public void DeleteAppointment(Appointment appointment)
        {
            var appointmentToDelete = this.Appointments
                .FirstOrDefault(a => a.Id == appointment.Id);
            
            if (appointmentToDelete != null)
            {
                this.appointments.Remove(appointment);
            }

            this.MarkConflictingAppointments();
        }

        private void MarkConflictingAppointments()
        {
            var conflictingAppointments = new List<Guid>();

            foreach (var appointment in this.appointments)
            {
                var potentiallyConflictingAppointments = this.appointments
                    .Where(a => a.Id != appointment.Id &&
                        a.Room.Id == appointment.Room.Id &&
                        a.TimeRange.Overlaps(appointment.TimeRange))
                    .ToList();

                potentiallyConflictingAppointments
                    .ForEach(a =>
                    {
                        a.MarkAsPotentiallyConflicting();

                        conflictingAppointments.Add(a.Id);
                    });

                if (potentiallyConflictingAppointments.Any())
                {
                    appointment.MarkAsPotentiallyConflicting();

                    conflictingAppointments.Add(appointment.Id);
                }
            }

            if (conflictingAppointments.Any())
            {
                this.RaiseEvent(new AppointmentConflictingEvent(conflictingAppointments));
            }
        }
    }
}
