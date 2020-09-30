namespace CarRentalSystem.Infrastructure.Persistence.Models
{
    using System.Collections.Generic;
    using Application.Common.Mapping;
    using Domain.Dealerships.Models.Dealers;

    internal class DealerData : IMapTo<Dealer>
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public PhoneNumber PhoneNumber { get; set; } = default!;

        public ICollection<CarData> CarAds { get; set; } = new HashSet<CarData>();
    }
}
