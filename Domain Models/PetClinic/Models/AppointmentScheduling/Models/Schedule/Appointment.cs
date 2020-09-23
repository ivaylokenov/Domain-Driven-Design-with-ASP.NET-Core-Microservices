namespace PetClinic.Models.AppointmentScheduling.Models.Schedule
{
    using System;
    using Common.Models;
    using Events;
    using Shared;

    public class Appointment : Entity<Guid>
    {
        internal Appointment(
            string title, 
            Client client, 
            Patient patient, 
            Room room, 
            Doctor? doctor, 
            AppointmentDetails appointmentDetails,
            DateTimeRange timeRange)
        {
            // Validate data.

            this.Title = title;
            this.Client = client;
            this.Patient = patient;
            this.Room = room;
            this.Doctor = doctor;
            this.AppointmentDetails = appointmentDetails;
            this.TimeRange = timeRange;
        }

        public string Title { get; private set; }

        public Client Client { get; private set; }

        public Patient Patient { get; private set; }

        public Room Room { get; private set; }

        public Doctor? Doctor { get; private set; }

        public AppointmentDetails AppointmentDetails { get; private set; }

        public DateTimeRange TimeRange { get; private set; }

        public DateTime? DateTimeConfirmed { get; private set; }

        public bool IsPotentiallyConflicting { get; private set; }

        public void UpdateRoom(Room room)
        {
            if (this.Room.Id == room.Id)
            {
                return;
            }

            this.Room = room;

            var appointmentUpdatedEvent = new AppointmentUpdatedEvent(this);

            this.RaiseEvent(appointmentUpdatedEvent);
        }

        public void UpdateTime(DateTimeRange newStartEnd)
        {
            if (newStartEnd == this.TimeRange)
            {
                return;
            }

            this.TimeRange = newStartEnd;

            var appointmentUpdatedEvent = new AppointmentUpdatedEvent(this);

            this.RaiseEvent(appointmentUpdatedEvent);
        }

        public void Confirm(DateTime dateConfirmed)
        {
            if (this.DateTimeConfirmed.HasValue)
            {
                return; // no need to reconfirm
            }

            this.DateTimeConfirmed = dateConfirmed;

            var appointmentConfirmedEvent = new AppointmentConfirmedEvent(this);

            this.RaiseEvent(appointmentConfirmedEvent);
        }

        public void MarkAsPotentiallyConflicting()
            => this.IsPotentiallyConflicting = true;
    }
}
