using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Library.FilipVujeva.Contracts.Dtos;
using Library.FilipVujeva.Contracts.Generators;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Library.FilipVujeva.Services.Generators
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly JWTSettings _settings;

        public TokenGenerator(IOptions<JWTSettings> settings)
        {
            _settings = settings.Value;
        }

        public TokenDTO GenerateToken(List<Claim> claims)
        {
            var keyBytes = Encoding.UTF8.GetBytes(_settings.Key);
            var authSigningKey = new SymmetricSecurityKey(keyBytes);

            var jwtToken = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                expires: DateTime.Now.AddHours(_settings.ValidHours),
                claims: claims,
                signingCredentials: new SigningCredentials(
                    authSigningKey,
                    SecurityAlgorithms.HmacSha256));

            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return new TokenDTO
            {
                Token = token,
                ExpiresAt = jwtToken.ValidTo,
            };
        }
    }
}
