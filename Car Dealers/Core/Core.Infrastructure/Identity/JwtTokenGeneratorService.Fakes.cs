namespace CarRentalSystem.Infrastructure.Identity
{
    using System.Collections.Generic;
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
                    .CallTo(() => jwtTokenGenerator.GenerateToken(A<User>.Ignored, A<IEnumerable<string>>.Ignored))
                    .Returns(ValidToken);

                return jwtTokenGenerator;
            }
        }
    }
}