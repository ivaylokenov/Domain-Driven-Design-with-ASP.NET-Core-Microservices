namespace CarRentalSystem.Application.Dealerships.CarAds.Queries.Categories
{
    using Application.Common.Mapping;
    using Domain.Dealerships.Models.CarAds;

    public class GetCarAdCategoryOutputModel : IMapFrom<Category>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public int TotalCarAds { get; set; }
    }
}
