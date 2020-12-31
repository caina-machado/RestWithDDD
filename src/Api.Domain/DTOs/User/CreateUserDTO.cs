using System.ComponentModel.DataAnnotations;

namespace src.Api.Domain.DTOs.User
{
    public class CreateUserDTO
    {
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(60, ErrorMessage = "{0} must have under {1} characteres")]
        [MinLength(1, ErrorMessage = "{0} must have more then {1} characteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [EmailAddress(ErrorMessage = "{0} must be a valid {0}")]
        [MaxLength(60, ErrorMessage = "{0} must have under {1} characteres")]
        public string Email { get; set; }
    }
}
