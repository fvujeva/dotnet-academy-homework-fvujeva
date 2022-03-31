using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.FilipVujeva.Contracts.Entities;
using Library.FilipVujeva.Contracts.Requests;
using Library.FilipVujeva.Contracts.Services;
using Microsoft.AspNetCore.Identity;

namespace Library.FilipVujeva.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly UserManager<Person> _userManager;

        public RegistrationService(UserManager<Person> userManager)
        {
            _userManager = userManager;
        }

        public async Task Register(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists!");
            }

            Person user = new Person(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Address.Street,
                request.Address.City,
                request.Address.Country);

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error.Description);
                }

                throw new Exception(result.Errors.ToString());
            }
        }
    }
}
