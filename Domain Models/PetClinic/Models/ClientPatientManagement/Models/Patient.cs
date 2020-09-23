namespace PetClinic.Models.ClientPatientManagement.Models
{
    using Common.Models;
    using Shared;

    public class Patient : Entity<int>
    {
        internal Patient(Client owner, string name, Gender gender)
        {
            // Validate data.

            this.Owner = owner;
            this.Name = name;
            this.Gender = gender;
        }

        public Client Owner { get; private set; }

        public string Name { get; private set; }

        public Gender Gender { get; private set; }
    }
}