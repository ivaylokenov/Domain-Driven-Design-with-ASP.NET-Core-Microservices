namespace CarRentalSystem.Startup.Specs
{
    using System.Linq;
    using Application.Features.CarAds.Queries.Search;
    using Domain.Models.Dealers;
    using FluentAssertions;
    using MyTested.AspNetCore.Mvc;
    using Web.Features;
    using Xunit;

    public class CarAdsControllerSpecs
    {
        [Fact]
        public void SearchShouldHaveCorrectAttributes()
            => MyController<CarAdsController>
                .Calling(c => c.Search(With.Default<SearchCarAdsQuery>()))

                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Get));

        [Theory]
        [InlineData(2)]
        public void SearchShouldReturnAllCarAdsWithoutAQuery(int totalCarAds)
            => MyPipeline
                .Configuration()
                .ShouldMap("/CarAds")

                .To<CarAdsController>(c => c.Search(With.Empty<SearchCarAdsQuery>()))
                .Which(instance => instance
                    .WithData(DealerFakes.Data.GetDealer(totalCarAds: totalCarAds)))

                .ShouldReturn()
                .ActionResult<SearchCarAdsOutputModel>(result => result
                    .Passing(model => model
                        .CarAds.Count().Should().Be(totalCarAds)));

        [Fact]
        public void SearchShouldReturnAvailableCarAdsWithoutAQuery()
            => MyPipeline
                .Configuration()
                .ShouldMap("/CarAds")

                .To<CarAdsController>(c => c.Search(With.Empty<SearchCarAdsQuery>()))
                .Which(instance => instance
                    .WithData(DealerFakes.Data.GetDealer()))

                .ShouldReturn()
                .ActionResult<SearchCarAdsOutputModel>(result => result
                    .Passing(model => model
                        .CarAds.Count().Should().Be(10)));

        [Theory]
        [InlineData("Manufacturer10")]
        public void SearchShouldReturnFilteredCarAdsWithQuery(string manufacturer)
            => MyPipeline
                .Configuration()
                .ShouldMap($"/CarAds?{nameof(manufacturer)}={manufacturer}")

                .To<CarAdsController>(c => c.Search(new SearchCarAdsQuery { Manufacturer = manufacturer }))
                .Which(instance => instance
                    .WithData(DealerFakes.Data.GetDealer()))

                .ShouldReturn()
                .ActionResult<SearchCarAdsOutputModel>(result => result
                    .Passing(model =>
                    {
                        model.CarAds.Count().Should().Be(1);
                        model.CarAds.First().Manufacturer.Should().Be(manufacturer);
                    }));
    }
}
