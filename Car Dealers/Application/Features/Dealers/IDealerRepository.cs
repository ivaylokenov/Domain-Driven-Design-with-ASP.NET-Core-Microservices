namespace CarRentalSystem.Application.Features.Dealers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;
    using Domain.Models.Dealers;
    using Queries.Common;
    using Queries.Details;

    public interface IDealerRepository : IRepository<Dealer>
    {
        Task<Dealer> FindByUser(string userId, CancellationToken cancellationToken = default);

        Task<int> GetDealerId(string userId, CancellationToken cancellationToken = default);

        Task<bool> HasCarAd(int dealerId, int carAdId, CancellationToken cancellationToken = default);

        Task<DealerDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<DealerOutputModel> GetDetailsByCarId(int carAdId, CancellationToken cancellationToken = default);
    }
}
