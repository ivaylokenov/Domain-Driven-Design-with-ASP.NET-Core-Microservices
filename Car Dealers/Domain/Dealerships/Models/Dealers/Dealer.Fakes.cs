namespace CarRentalSystem.Domain.Dealerships.Models.Dealers
{
    using System.Collections.Generic;
    using System.Linq;
    using Bogus;
    using Common;
    using Common.Models;
    using static CarAds.CarAdFakes.Data;

    public class DealerFakes
    {
        public static class Data
        {
            public static IEnumerable<Dealer> GetDealers(int count = 10)
                => Enumerable
                    .Range(1, count)
                    .Select(GetDealer)
                    .ToList();

            public static Dealer GetDealer(int id = 1, int totalCarAds = 10)
            {
                var dealer = new Faker<Dealer>()
                    .CustomInstantiator(f => new Dealer(
                        $"Dealer{id}",
                        f.Phone.PhoneNumber("+########")))
                    .Generate()
                    .SetId(id);

                foreach (var carAd in GetCarAds().Take(totalCarAds))
                {
                    dealer.AddCarAd(carAd);
                }

                return dealer;
            }
        }
    }
}
