namespace PetClinic.Models.AppointmentScheduling.Models.Schedule
{
    using Common.Models;

    public class AppointmentDetails : ValueObject
    {
        internal AppointmentDetails(string name, string code, int duration)
        {
            // Validate data.

            this.Name = name;
            this.Code = code;
            this.Duration = duration;
        }

        public string Name { get; private set; }

        public string Code { get; private set; }

        public int Duration { get; private set; }
    }
}
