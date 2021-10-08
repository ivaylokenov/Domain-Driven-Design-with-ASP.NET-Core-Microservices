namespace CarRentalSystem.Application.Dealerships.CarAds.Commands.Edit
{
    using Common;
    using FluentValidation;

    public class EditCarAdCommandValidator : AbstractValidator<EditCarAdCommand>
    {
        public EditCarAdCommandValidator(ICarAdRepository carAdRepository)
            => this.Include(new CarAdCommandValidator<EditCarAdCommand>(carAdRepository));
    }
}
