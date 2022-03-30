using Library.FilipVujeva.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.FilipVujeva.Contracts.Services
{
    public interface IRegistrationService
    {
        public Task Register(RegistrationRequest request);
    }
}
