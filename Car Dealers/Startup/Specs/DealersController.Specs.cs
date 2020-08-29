namespace CarRentalSystem.Startup.Specs
{
    using Application.Features.Dealers.Queries.Details;
    using MyTested.AspNetCore.Mvc;
    using Web;
    using Web.Features;
    using Xunit;

    public class DealersControllerSpecs
    {
        [Fact]
        public void DetailsShouldHaveCorrectAttributes()
            => MyController<DealersController>
                .Calling(c => c.Details(With.Default<DealerDetailsQuery>()))

                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Get)
                    .SpecifyingRoute(ApiController.Id));
    }
}
