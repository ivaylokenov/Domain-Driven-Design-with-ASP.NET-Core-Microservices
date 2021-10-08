namespace CarRentalSystem.Application.Dealerships.CarAds.Commands.Create
{
    using Common;
    using FluentValidation;

    public class CreateCarAdCommandValidator : AbstractValidator<CreateCarAdCommand>
    {
        public CreateCarAdCommandValidator(ICarAdQueryRepository carAdRepository) 
            => this.Include(new CarAdCommandValidator<CreateCarAdCommand>(carAdRepository));
    }
}
