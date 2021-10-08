namespace CarRentalSystem.Domain.Models.CarAds
{
    using Common;
    using Exceptions;

    using static ModelConstants.Common;

    public class Manufacturer : Entity<int>
    {
        internal Manufacturer(string name)
        { 
            this.Validate(name);

            this.Name = name;
        }

        public string Name { get; private set; }

        public Manufacturer UpdateName(string name)
        {
            this.Validate(name);
            this.Name = name;

            return this;
        }

        public void Validate(string newName)
            => Guard.ForStringLength<InvalidCarAdException>(
                newName,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
