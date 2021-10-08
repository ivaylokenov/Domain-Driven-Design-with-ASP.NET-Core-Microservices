namespace CarRentalSystem.Domain.Dealerships.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models.CarAds;

    public interface ICarAdDomainRepository
    {
        Task<CarAd> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

        Task<Category> GetCategory(
            int categoryId,
            CancellationToken cancellationToken = default);

        Task<Manufacturer> GetManufacturer(
            string manufacturer,
            CancellationToken cancellationToken = default);
    }
}
