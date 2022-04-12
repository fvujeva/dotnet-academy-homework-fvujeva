using Library.FilipVujeva.Contracts.Requests;

namespace Library.FilipVujeva.Contracts.Services
{
    public interface IRegistrationService
    {
        public Task Register(RegistrationRequest request);
    }
}
