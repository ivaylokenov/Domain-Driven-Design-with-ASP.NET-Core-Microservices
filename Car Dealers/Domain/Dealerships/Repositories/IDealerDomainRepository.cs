namespace CarRentalSystem.Domain.Dealerships.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models.Dealers;

    public interface IDealerDomainRepository
    {
        Task<Dealer> FindByUser(string userId, CancellationToken cancellationToken = default);

        Task<int> GetDealerId(string userId, CancellationToken cancellationToken = default);

        Task<bool> HasCarAd(int dealerId, int carAdId, CancellationToken cancellationToken = default);
    }
}
