namespace CarRentalSystem.Domain.Models.CarAds
{
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;

    public class CarAdSpecs
    {
        [Fact]
        public void ChangeAvailabilityShouldMutateIsAvailable()
        {
            // Arrange
            var carAd = A.Dummy<CarAd>();

            // Act
            carAd.ChangeAvailability();

            // Assert
            carAd.IsAvailable.Should().BeFalse();
        }
    }
}
