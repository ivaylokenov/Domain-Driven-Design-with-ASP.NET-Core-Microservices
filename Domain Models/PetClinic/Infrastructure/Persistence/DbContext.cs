namespace PetClinic.Infrastructure.Persistence
{
    using System.Collections.Generic;
    using Models;

    public class DbContext
    {
        public HashSet<DoctorData> Doctors { get; set; } = default!;
    }
}
