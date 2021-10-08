namespace CarRentalSystem.Domain.Dealerships.Models.Dealers
{
    using CarAds;
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;

    public class DealerSpecs
    {
        [Fact]
        public void AddCarAdShouldSaveCarAd()
        {
            // Arrange
            var dealer = new Dealer("Valid dealer", "+12345678");
            var carAd = A.Dummy<CarAd>();

            // Act
            dealer.AddCarAd(carAd);

            // Assert
            dealer.CarAds.Should().Contain(carAd);
        }
    }
}
