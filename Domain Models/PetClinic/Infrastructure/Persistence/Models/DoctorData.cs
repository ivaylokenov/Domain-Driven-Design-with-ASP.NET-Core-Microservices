
namespace PetClinic.Infrastructure.Persistence.Models
{
    using System.Collections.Generic;
    using PetClinic.Models.ClientPatientManagement.Models;

    public class DoctorData
    {
        internal DoctorData(string name)
        {
            this.Name = name;

            this.Clients = new List<Client>();
        }

        public string Name { get; private set; }

        public Specialty Specialty { get; private set; }

        public List<Client> Clients { get; private set; }
    }
}
