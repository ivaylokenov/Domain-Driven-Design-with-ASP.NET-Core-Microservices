namespace CarRentalSystem.Application.Features.CarAds.Queries.Search
{
    using System.Collections.Generic;
    using Common;

    public class SearchCarAdsOutputModel : CarAdsOutputModel<CarAdOutputModel>
    {
        public SearchCarAdsOutputModel(
            IEnumerable<CarAdOutputModel> carAds, 
            int page, 
            int totalPages) 
            : base(carAds, page, totalPages)
        {
        }
    }
}
