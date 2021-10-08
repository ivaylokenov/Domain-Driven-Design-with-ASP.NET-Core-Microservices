namespace CarRentalSystem.Infrastructure.Common.Persistence.Models
{
    using System.Collections.Generic;
    using Domain.Dealerships.Models.Dealers;

    internal class DealerData
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public PhoneNumber PhoneNumber { get; set; } = default!;

        public ICollection<CarData> CarAds { get; set; } = new HashSet<CarData>();
    }
}
