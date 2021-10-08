namespace CarRentalSystem.Application.Dealerships.Dealers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Contracts;
    using Domain.Dealerships.Models.Dealers;
    using Queries.Common;
    using Queries.Details;

    public interface IDealerQueryRepository : IQueryRepository<Dealer>
    {
        Task<DealerDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<DealerOutputModel> GetDetailsByCarId(int carAdId, CancellationToken cancellationToken = default);
    }
}
