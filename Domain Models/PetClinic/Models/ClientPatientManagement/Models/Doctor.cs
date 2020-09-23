namespace PetClinic.Models.ClientPatientManagement.Models
{
    using Common.Models;

    public class Doctor : Entity<int>
    {
        internal Doctor(string name, Specialty specialty)
        {
            // Validate data.

            this.Name = name;
            this.Specialty = specialty;
        }

        public string Name { get; private set; }

        public Specialty Specialty { get; private set; }
    }
}
