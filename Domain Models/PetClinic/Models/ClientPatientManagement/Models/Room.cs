namespace PetClinic.Models.ClientPatientManagement.Models
{
    using Common.Models;

    public class Room : Entity<int>
    {
        internal Room(string name, bool isLab)
        {
            // Validate name.

            this.Name = name;
            this.IsLab = isLab;
        }

        public string Name { get; private set; }

        public bool IsLab { get; private set; }
    }
}