using System.Security.Claims;
using Library.FilipVujeva.Contracts.Dtos;
using Library.FilipVujeva.Contracts.Entities;
using Library.FilipVujeva.Contracts.Generators;
using Library.FilipVujeva.Contracts.Requests;
using Library.FilipVujeva.Contracts.Services;
using Library.FilipVujeva.Services.Generators;
using Microsoft.AspNetCore.Identity;

namespace Library.FilipVujeva.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<Person> _userManager;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthenticationService(UserManager<Person> userManager, ITokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<TokenDTO> Login(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception("Ooops... user not found");
            }

            var isValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isValidPassword)
            {
                throw new Exception("Password is incorrect");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("FullName", user.FullName),
                new Claim("Id", user.Id.ToString()),
            };

            return _tokenGenerator.GenerateToken(claims);
        }
    }
}
