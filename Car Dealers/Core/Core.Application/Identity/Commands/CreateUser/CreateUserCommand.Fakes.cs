namespace CarRentalSystem.Application.Identity.Commands.CreateUser
{
    using Bogus;

    public class CreateUserCommandFakes
    {
        public static class Data
        {
            public static CreateUserCommand GetCommand()
                => new Faker<CreateUserCommand>()
                    .RuleFor(u => u.Email, f => f.Internet.Email())
                    .RuleFor(u => u.Password, f => f.Lorem.Letter(10))
                    .Generate();
        }
    }
}
