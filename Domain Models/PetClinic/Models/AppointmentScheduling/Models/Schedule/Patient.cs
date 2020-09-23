namespace PetClinic.Models.AppointmentScheduling.Models.Schedule
{
    using Common.Models;
    using Shared;

    public class Patient : Entity<int>
    {
        internal Patient(
            string name, 
            Gender gender, 
            AnimalType animalType, 
            Client client, 
            Doctor? preferredDoctor = null)
        {
            this.Name = name;
            this.Gender = gender;
            this.AnimalType = animalType;
            this.Client = client;
            this.PreferredDoctor = preferredDoctor;
        }

        public string Name { get; private set; }

        public Gender Gender { get; private set; }

        public AnimalType AnimalType { get; private set; }

        public Client Client { get; private set; }

        public Doctor? PreferredDoctor { get; private set; }
    }
}
