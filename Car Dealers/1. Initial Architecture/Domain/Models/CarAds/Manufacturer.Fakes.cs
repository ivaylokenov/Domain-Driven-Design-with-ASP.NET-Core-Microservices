namespace CarRentalSystem.Domain.Models.CarAds
{
    using System;
    using FakeItEasy;

    public class ManufacturerFakes
    {
        public class ManufacturerDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Manufacturer);

            public object? Create(Type type)
                => new Manufacturer("Valid manufacturer");

            public Priority Priority => Priority.Default;
        }
    }
}
