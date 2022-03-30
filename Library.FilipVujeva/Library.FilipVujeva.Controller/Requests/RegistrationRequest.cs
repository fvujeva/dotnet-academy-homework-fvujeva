using System.ComponentModel.DataAnnotations;
using Library.FilipVujeva.Contracts.Dtos;

namespace Library.FilipVujeva.Contracts.Requests
{
    public class RegistrationRequest
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; } = default!;

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; } = default!;

        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = default!;

        [Required(ErrorMessage = "Adress is required")]
        public AddressDTO Address { get; set; } = default!;
    }
}
