namespace CarRentalSystem.Domain.Dealerships.Models.CarAds
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Common.Models;
    using Exceptions;
    using static ModelConstants.Common;
    using static ModelConstants.CarAd;

    public class CarAd : Entity<int>, IAggregateRoot
    {
        private static readonly IEnumerable<Category> AllowedCategories
            = new CategoryData().GetData().Cast<Category>();

        internal CarAd( 
            Manufacturer manufacturer, 
            string model, 
            Category category,
            string imageUrl, 
            decimal pricePerDay,
            Options options,
            bool isAvailable)
        {
            this.Validate(model, imageUrl, pricePerDay);
            this.ValidateCategory(category);

            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Category = category;
            this.ImageUrl = imageUrl;
            this.PricePerDay = pricePerDay;
            this.Options = options;
            this.IsAvailable = isAvailable;
        }

        private CarAd(
            string model,
            string imageUrl,
            decimal pricePerDay,
            bool isAvailable)
        {
            this.Model = model;
            this.ImageUrl = imageUrl;
            this.PricePerDay = pricePerDay;
            this.IsAvailable = isAvailable;

            this.Manufacturer = default!;
            this.Category = default!;
            this.Options = default!;
        }

        public Manufacturer Manufacturer { get; private set; }

        public string Model { get; private set; }

        public Category Category { get; private set; }

        public string ImageUrl { get; private set; }

        public decimal PricePerDay { get; private set; }

        public Options Options { get; private set; }

        public bool IsAvailable { get; private set; }

        public CarAd UpdateManufacturer(string manufacturer)
        {
            if (this.Manufacturer.Name != manufacturer)
            {
                this.Manufacturer = new Manufacturer(manufacturer);
            }

            return this;
        }

        public CarAd UpdateModel(string model)
        {
            this.ValidateModel(model);
            this.Model = model;

            return this;
        }

        public CarAd UpdateCategory(Category category)
        {
            this.ValidateCategory(category);
            this.Category = category;

            return this;
        }

        public CarAd UpdateImageUrl(string imageUrl)
        {
            this.ValidateImageUrl(imageUrl);
            this.ImageUrl = imageUrl;

            return this;
        }

        public CarAd UpdatePricePerDay(decimal pricePerDay)
        {
            this.ValidatePricePerDay(pricePerDay);
            this.PricePerDay = pricePerDay;

            return this;
        }

        public CarAd UpdateOptions(
            bool hasClimateControl,
            int numberOfSeats,
            TransmissionType transmissionType)
        {
            this.Options = new Options(hasClimateControl, numberOfSeats, transmissionType);

            return this;
        }

        public CarAd ChangeAvailability()
        {
            this.IsAvailable = !this.IsAvailable;

            return this;
        }

        private void Validate(string model, string imageUrl, decimal pricePerDay)
        {
            this.ValidateModel(model);
            this.ValidateImageUrl(imageUrl);
            this.ValidatePricePerDay(pricePerDay);
        }

        private void ValidateModel(string model)
            => Guard.ForStringLength<InvalidCarAdException>(
                model,
                MinModelLength,
                MaxModelLength,
                nameof(this.Model));

        private void ValidateImageUrl(string imageUrl)
            => Guard.ForValidUrl<InvalidCarAdException>(
                imageUrl,
                nameof(this.ImageUrl));

        private void ValidatePricePerDay(decimal pricePerDay)
            => Guard.AgainstOutOfRange<InvalidCarAdException>(
                pricePerDay,
                Zero,
                decimal.MaxValue,
                nameof(this.PricePerDay));

        private void ValidateCategory(Category category)
        {
            var categoryName = category?.Name;

            if (AllowedCategories.Any(c => c.Name == categoryName))
            {
                return;
            }

            var allowedCategoryNames = string.Join(", ", AllowedCategories.Select(c => $"'{c.Name}'"));

            throw new InvalidCarAdException($"'{categoryName}' is not a valid category. Allowed values are: {allowedCategoryNames}.");
        }
    }
}
