using System.Security.Claims;
using Library.FilipVujeva.Contracts.Dtos;

namespace Library.FilipVujeva.Contracts.Generators
{
    public interface ITokenGenerator
    {
        public TokenDTO GenerateToken(List<Claim> claims);
    }
}
