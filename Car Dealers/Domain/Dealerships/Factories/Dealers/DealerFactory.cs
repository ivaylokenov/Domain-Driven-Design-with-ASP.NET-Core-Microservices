namespace CarRentalSystem.Domain.Dealerships.Factories.Dealers
{
    using Models.Dealers;

    internal class DealerFactory : IDealerFactory
    {
        private string dealerName = default!;
        private string dealerPhoneNumber = default!;

        public IDealerFactory WithName(string name)
        {
            this.dealerName = name;
            return this;
        }

        public IDealerFactory WithPhoneNumber(string phoneNumber)
        {
            this.dealerPhoneNumber = phoneNumber;
            return this;
        }

        public Dealer Build() => new Dealer(this.dealerName, this.dealerPhoneNumber);
    }
}
