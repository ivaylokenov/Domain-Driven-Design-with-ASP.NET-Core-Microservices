namespace CarRentalSystem.Infrastructure.Persistence.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Features.Dealers;
    using Application.Features.Dealers.Queries.Common;
    using Application.Features.Dealers.Queries.Details;
    using AutoMapper;
    using Domain.Exceptions;
    using Domain.Models.Dealers;
    using Identity;
    using Microsoft.EntityFrameworkCore;

    internal class DealerRepository : DataRepository<Dealer>, IDealerRepository
    {
        private readonly IMapper mapper;

        public DealerRepository(CarRentalDbContext db, IMapper mapper)
            : base(db) 
            => this.mapper = mapper;

        public async Task<bool> HasCarAd(int dealerId, int carAdId, CancellationToken cancellationToken = default)
            => await this
                .All()
                .Where(d => d.Id == dealerId)
                .AnyAsync(d => d.CarAds
                    .Any(c => c.Id == carAdId), cancellationToken);

        public async Task<DealerDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<DealerDetailsOutputModel>(this
                    .All()
                    .Where(d => d.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<DealerOutputModel> GetDetailsByCarId(int carAdId, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<DealerOutputModel>(this
                    .All()
                    .Where(d => d.CarAds.Any(c => c.Id == carAdId)))
                .SingleOrDefaultAsync(cancellationToken);

        public Task<int> GetDealerId(
            string userId, 
            CancellationToken cancellationToken = default)
            => this.FindByUser(userId, user => user.Dealer!.Id, cancellationToken);

        public Task<Dealer> FindByUser(
            string userId,
            CancellationToken cancellationToken = default)
            => this.FindByUser(userId, user => user.Dealer!, cancellationToken);

        private async Task<T> FindByUser<T>(
            string userId,
            Expression<Func<User, T>> selector,
            CancellationToken cancellationToken = default)
        {
            var dealerData = await this
                .Data
                .Users
                .Where(u => u.Id == userId)
                .Select(selector)
                .FirstOrDefaultAsync(cancellationToken);

            if (dealerData == null)
            {
                throw new InvalidDealerException("This user is not a dealer.");
            }

            return dealerData;
        }
    }
}
