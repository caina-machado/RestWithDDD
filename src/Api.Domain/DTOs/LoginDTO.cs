using System.ComponentModel.DataAnnotations;

namespace src.Api.Domain.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "{0} is required")]
        [EmailAddress(ErrorMessage = "{0} must be a valid {0}")]
        [MaxLength(100, ErrorMessage = "{0} must have under {1} characteres")]
        public string Email { get; set; }
    }
}
