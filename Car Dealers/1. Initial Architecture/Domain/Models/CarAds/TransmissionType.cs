namespace CarRentalSystem.Domain.Models.CarAds
{
    using Common;

    public class TransmissionType : Enumeration
    {
        public static readonly TransmissionType Manual = new TransmissionType(1, nameof(Manual));
        public static readonly TransmissionType Automatic = new TransmissionType(2, nameof(Automatic));

        private TransmissionType(int value)
            : this(value, FromValue<TransmissionType>(value).Name)
        {
        }

        private TransmissionType(int value, string name) 
            : base(value, name)
        {
        }
    }
}
