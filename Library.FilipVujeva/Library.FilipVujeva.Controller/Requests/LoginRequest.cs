using System.ComponentModel.DataAnnotations;

namespace Library.FilipVujeva.Contracts.Requests
{
    public class LoginRequest
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is required for login")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Password is required for login")]
        public string Password { get; set; } = default!;
    }
}
