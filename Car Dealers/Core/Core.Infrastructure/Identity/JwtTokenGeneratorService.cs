namespace CarRentalSystem.Infrastructure.Identity
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Application.Common;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    internal class JwtTokenGeneratorService : IJwtTokenGenerator
    {
        private readonly ApplicationSettings applicationSettings;

        public JwtTokenGeneratorService(IOptions<ApplicationSettings> applicationSettings) 
            => this.applicationSettings = applicationSettings.Value;

        public string GenerateToken(User user, IEnumerable<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.applicationSettings.Secret);

            var identityClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Email)
            };

            foreach (var role in roles)
            {
                identityClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(identityClaims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }
    }
}
