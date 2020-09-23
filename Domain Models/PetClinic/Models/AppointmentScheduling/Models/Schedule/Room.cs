namespace PetClinic.Models.AppointmentScheduling.Models.Schedule
{
    using Common.Models;

    public class Room : Entity<int>
    {
        internal Room(string name)
        {
            // Validate name.

            this.Name = name;
        }

        public string Name { get; private set; }
    }
}
