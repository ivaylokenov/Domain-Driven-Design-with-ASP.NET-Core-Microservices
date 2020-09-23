namespace PetClinic.Infrastructure.ClientPatientManagement
{
    using System.Collections.Generic;
    using System.Linq;
    using Application.ClientPatientManagement;
    using Models.ClientPatientManagement.Models;
    using Persistence;

    public class DoctorsRepository : IDoctorsRepository
    {
        private readonly DbContext data = new DbContext();

        public IEnumerable<Doctor> GetByName(string name)
        {
            return this.data
                .Doctors
                .Where(d => d.Name == name)
                .ToList()
                .Select(d => new Doctor(d.Name, d.Specialty));
        }
    }
}
