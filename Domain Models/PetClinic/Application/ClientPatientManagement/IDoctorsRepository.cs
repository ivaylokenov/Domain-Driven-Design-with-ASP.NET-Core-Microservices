namespace PetClinic.Application.ClientPatientManagement
{
    using System.Collections.Generic;
    using Models.ClientPatientManagement.Models;

    public interface IDoctorsRepository
    {
        IEnumerable<Doctor> GetByName(string name);
    }
}
