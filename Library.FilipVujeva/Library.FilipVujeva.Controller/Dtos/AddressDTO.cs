using System.ComponentModel.DataAnnotations;
using Library.FilipVujeva.Contracts.Attributes;

namespace Library.FilipVujeva.Contracts.Dtos
{
    public class AddressDTO
    {
        [Required(ErrorMessage = "You have to provide Street")]
        [StringLength(100)]
        public string Street { get; set; } = default!;

        [Required(ErrorMessage = "You have to provide City")]
        [StringLength(100)]
        public string City { get; set; } = default!;

        [Required(ErrorMessage = "You have to provide Country")]
        public string Country { get; set; } = default!;
    }
}
