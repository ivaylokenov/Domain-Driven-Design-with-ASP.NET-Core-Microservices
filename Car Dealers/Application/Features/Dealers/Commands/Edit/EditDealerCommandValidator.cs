namespace CarRentalSystem.Application.Features.Dealers.Commands.Edit
{
    using FluentValidation;

    using static Domain.Models.ModelConstants.Common;
    using static Domain.Models.ModelConstants.PhoneNumber;

    public class EditDealerCommandValidator : AbstractValidator<EditDealerCommand>
    {
        public EditDealerCommandValidator()
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
