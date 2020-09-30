namespace CarRentalSystem.Domain.Renting.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class RentingScheduleService : IRentingScheduleService
    {
        public bool IsOverlapping(DateTimeRange timeRange, IEnumerable<Reservation> reservations) 
            => reservations.Any(reservation => reservation
                .TimeRange.Overlaps(timeRange));
    }
}
