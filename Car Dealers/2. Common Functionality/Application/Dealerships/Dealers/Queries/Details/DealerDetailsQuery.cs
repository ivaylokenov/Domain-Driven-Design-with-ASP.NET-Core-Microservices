namespace CarRentalSystem.Application.Dealerships.Dealers.Queries.Details
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class DealerDetailsQuery : IRequest<DealerDetailsOutputModel>
    {
        public int Id { get; set; }

        public class DealerDetailsQueryHandler : IRequestHandler<DealerDetailsQuery, DealerDetailsOutputModel>
        {
            private readonly IDealerRepository dealerRepository;

            public DealerDetailsQueryHandler(IDealerRepository dealerRepository) 
                => this.dealerRepository = dealerRepository;

            public async Task<DealerDetailsOutputModel> Handle(
                DealerDetailsQuery request,
                CancellationToken cancellationToken)
                => await this.dealerRepository.GetDetails(request.Id, cancellationToken);
        }
    }
}
