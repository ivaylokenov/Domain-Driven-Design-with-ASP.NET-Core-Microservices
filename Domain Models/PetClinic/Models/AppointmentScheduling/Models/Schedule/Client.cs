namespace PetClinic.Models.AppointmentScheduling.Models.Schedule
{
    using System.Collections.Generic;
    using Common.Models;

    public class Client : Entity<int>
    {
        internal Client(string fullName)
        {
            this.FullName = fullName;

            this.Patients = new List<Patient>();
        }

        public string FullName { get; private set; }

        public IList<Patient> Patients { get; private set; }
    }
}
