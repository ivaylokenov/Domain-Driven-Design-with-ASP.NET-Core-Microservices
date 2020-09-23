namespace PetClinic.Models.AppointmentScheduling.Models.Schedule
{
    using Common.Models;

    public class Doctor : Entity<int>
    {
        internal Doctor(string name)
        {
            // Validate name.

            this.Name = name;
        }

        public string Name { get; private set; }
    }
}
