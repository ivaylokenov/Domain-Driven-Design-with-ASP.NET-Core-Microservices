namespace CarRentalSystem.Application.Dealerships.CarAds.Commands.Edit
{
    using Common;
    using Domain.Dealerships.Repositories;
    using FluentValidation;

    public class EditCarAdCommandValidator : AbstractValidator<EditCarAdCommand>
    {
        public EditCarAdCommandValidator(ICarAdDomainRepository carAdRepository)
            => this.Include(new CarAdCommandValidator<EditCarAdCommand>(carAdRepository));
    }
}
