namespace PetClinic.Application.AppointmentScheduling
{
    using Models.AppointmentScheduling.Models.Schedule;

    public interface IDoctorsRepository
    {
        Doctor GetById(int id);
    }
}
