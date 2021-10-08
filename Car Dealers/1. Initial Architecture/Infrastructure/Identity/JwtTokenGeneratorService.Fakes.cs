namespace CarRentalSystem.Infrastructure.Identity
{
    using FakeItEasy;

    public class JwtTokenGeneratorFakes
    {
        public const string ValidToken = "ValidToken";

        public static IJwtTokenGenerator FakeJwtTokenGenerator
        {
            get
            {
                var jwtTokenGenerator = A.Fake<IJwtTokenGenerator>();

                A
                    .CallTo(() => jwtTokenGenerator.GenerateToken(A<User>.Ignored))
                    .Returns(ValidToken);

                return jwtTokenGenerator;
            }
        }
    }
}