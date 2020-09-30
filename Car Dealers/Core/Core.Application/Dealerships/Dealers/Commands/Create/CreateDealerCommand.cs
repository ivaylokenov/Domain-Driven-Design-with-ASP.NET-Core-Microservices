namespace CarRentalSystem.Application.Dealerships.Dealers.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Contracts;
    using Domain.Dealerships.Factories.Dealers;
    using Domain.Dealerships.Repositories;
    using MediatR;

    public class CreateDealerCommand : IRequest<CreateDealerOutputModel>
    {
        public string Name { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public class CreateDealerCommandHandler : IRequestHandler<CreateDealerCommand, CreateDealerOutputModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IDealerFactory dealerFactory;
            private readonly IDealerDomainRepository dealerRepository;

            public CreateDealerCommandHandler(
                ICurrentUser currentUser,
                IDealerFactory dealerFactory, 
                IDealerDomainRepository dealerRepository)
            {
                this.currentUser = currentUser;
                this.dealerFactory = dealerFactory;
                this.dealerRepository = dealerRepository;
            }

            public async Task<CreateDealerOutputModel> Handle(
                CreateDealerCommand request, 
                CancellationToken cancellationToken)
            {
                var dealer = this.dealerFactory
                    .WithName(request.Name)
                    .WithPhoneNumber(request.PhoneNumber)
                    .FromUser(this.currentUser.UserId)
                    .Build();

                await this.dealerRepository.Save(dealer, cancellationToken);

                return new CreateDealerOutputModel(dealer.Id);
            }
        }
    }
}
