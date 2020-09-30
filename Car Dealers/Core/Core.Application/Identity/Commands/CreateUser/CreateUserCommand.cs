namespace CarRentalSystem.Application.Identity.Commands.CreateUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using MediatR;

    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;

            public CreateUserCommandHandler(IIdentity identity) 
                => this.identity = identity;

            public async Task<Result> Handle(
                CreateUserCommand request,
                CancellationToken cancellationToken)
                => await this.identity.Register(request);
        }
    }
}