namespace CarRentalSystem.Domain.Dealerships.Models.CarAds
{
    using Common.Models;
    using Exceptions;
    using static ModelConstants.Common;
    using static ModelConstants.Category;

    public class Category : Entity<int>
    {
        internal Category(string name, string description)
        {
            this.Validate(name, description);

            this.Name = name;
            this.Description = description;
        }

        public string Name { get; }

        public string Description { get; }

        private void Validate(string name, string description)
        {
            Guard.ForStringLength<InvalidCarAdException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

            Guard.ForStringLength<InvalidCarAdException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength,
                nameof(this.Description));
        }
    }
}
