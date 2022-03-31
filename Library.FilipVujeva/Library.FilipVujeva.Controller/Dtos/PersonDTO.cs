using System.ComponentModel.DataAnnotations;
using Library.FilipVujeva.Contracts.Entities;

namespace Library.FilipVujeva.Contracts.Dtos
{
    public class PersonDTO
    {
        [Required(ErrorMessage = "You have to provide First Name")]
        [StringLength(20)]
        public string FirstName { get; set; } = default!;

        [Required(ErrorMessage = "You have to provide Last Name")]
        [StringLength(100)]
        public string LastName { get; set; } = default!;

        [Required(ErrorMessage = "You have to provide Adress")]
        public Address Address { get; set; } = default!;
    }
}
