namespace CarRentalSystem.Application.Dealerships.Dealers.Commands.Create
{
    using FluentValidation;
    using static Domain.Common.Models.ModelConstants.Common;
    using static Domain.Dealerships.Models.ModelConstants.PhoneNumber;

    public class CreateDealerCommandValidator : AbstractValidator<CreateDealerCommand>
    {
        public CreateDealerCommandValidator()
        {
            this.RuleFor(u => u.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(u => u.PhoneNumber)
                .MinimumLength(MinPhoneNumberLength)
                .MaximumLength(MaxPhoneNumberLength)
                .Matches(PhoneNumberRegularExpression)
                .NotEmpty();
        }
    }
}