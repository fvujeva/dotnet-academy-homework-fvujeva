using Library.FilipVujeva.Contracts.Dtos;
using Library.FilipVujeva.Contracts.Requests;

namespace Library.FilipVujeva.Contracts.Services
{
    public interface IAuthenticationService
    {
        public Task<TokenDTO> Login(LoginRequest request);
    }
}
