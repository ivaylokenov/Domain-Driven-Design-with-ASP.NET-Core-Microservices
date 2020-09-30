namespace CarRentalSystem.Application.Dealerships.CarAds.Commands.Create
{
    using Common;
    using Domain.Dealerships.Repositories;
    using FluentValidation;

    public class CreateCarAdCommandValidator : AbstractValidator<CreateCarAdCommand>
    {
        public CreateCarAdCommandValidator(ICarAdDomainRepository carAdRepository) 
            => this.Include(new CarAdCommandValidator<CreateCarAdCommand>(carAdRepository));
    }
}
