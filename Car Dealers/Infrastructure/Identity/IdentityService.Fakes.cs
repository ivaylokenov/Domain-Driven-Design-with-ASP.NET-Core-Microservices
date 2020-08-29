namespace CarRentalSystem.Infrastructure.Identity
{
    using FakeItEasy;
    using Microsoft.AspNetCore.Identity;

    public class IdentityFakes
    {
        public const string TestEmail = "test@test.com";
        public const string ValidPassword = "TestPass";

        public static UserManager<User> FakeUserManager
        {
            get
            {
                var userManager = A.Fake<UserManager<User>>();

                A
                    .CallTo(() => userManager.FindByEmailAsync(TestEmail))
                    .Returns(new User(TestEmail) { Id = "test" });

                A
                    .CallTo(() => userManager.CheckPasswordAsync(A<User>.That.Matches(u => u.Email == TestEmail), ValidPassword))
                    .Returns(true);

                return userManager;
            }
        }
    }
}
