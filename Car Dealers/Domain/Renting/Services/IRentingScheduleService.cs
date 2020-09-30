namespace CarRentalSystem.Domain.Renting.Services
{
    using System.Collections.Generic;
    using Models;

    public interface IRentingScheduleService
    {
        bool IsOverlapping(DateTimeRange timeRange, IEnumerable<Reservation> reservations);
    }
}
