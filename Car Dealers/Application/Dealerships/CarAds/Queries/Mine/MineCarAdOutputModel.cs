namespace CarRentalSystem.Application.Dealerships.CarAds.Queries.Mine
{
    using AutoMapper;
    using Common;
    using Domain.Dealerships.Models.CarAds;

    public class MineCarAdOutputModel : CarAdOutputModel
    {
        public bool IsAvailable { get; private set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<CarAd, MineCarAdOutputModel>()
                .IncludeBase<CarAd, CarAdOutputModel>();
    }
}
