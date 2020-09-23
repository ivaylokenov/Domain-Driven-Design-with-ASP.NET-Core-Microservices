namespace PetClinic.Models.ClientPatientManagement.Models
{
    using System.Collections.Generic;
    using Common;
    using Common.Models;

    public class Client : Entity<int>, IAggregateRoot
    {
        internal Client(
            string fullName, 
            string emailAddress,
            string preferredName,
            Doctor? preferredDoctor = null)
        {
            // Validate data.

            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.PreferredName = preferredName;
            this.PreferredDoctor = preferredDoctor;

            this.Patients = new List<Patient>();
        }

        public string FullName { get; private set; }

        public string EmailAddress { get; private set; }

        public string PreferredName { get; private set; }

        public Doctor? PreferredDoctor { get; private set; }

        public IList<Patient> Patients { get; private set; }
    }
}