namespace CarRentalSystem.Infrastructure.Identity
{
    using System.Collections.Generic;

    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user, IEnumerable<string> roles);
    }
}
