namespace CarRentalSystem.Domain.Models.CarAds
{
    using System;
    using FakeItEasy;

    public class OptionsFakes
    {
        public class OptionsDummyFactory : IDummyFactory
        {
            public bool CanCreate(Type type) => type == typeof(Options);

            public object? Create(Type type)
                => new Options(true, 4, TransmissionType.Automatic);

            public Priority Priority => Priority.Default;
        }
    }
}
