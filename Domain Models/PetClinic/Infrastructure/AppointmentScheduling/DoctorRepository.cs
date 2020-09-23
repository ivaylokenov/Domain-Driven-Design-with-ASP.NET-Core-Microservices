namespace PetClinic.Infrastructure.AppointmentScheduling
{
    using System.Linq;
    using Application.AppointmentScheduling;
    using Models.AppointmentScheduling.Models.Schedule;
    using Persistence;

    public class DoctorRepository : IDoctorsRepository
    {
        private readonly DbContext data = new DbContext();

        public Doctor GetById(int id)
        {
            var doctor = this.data.Doctors.FirstOrDefault();

            return new Doctor(doctor.Name);
        }
    }
}
