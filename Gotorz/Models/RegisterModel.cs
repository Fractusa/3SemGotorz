using System.ComponentModel.DataAnnotations;

namespace Gotorz.Models
{
    public class RegisterModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6, ErrorMessage = "Password must be 6 digits")]
        public string Password { get; set; }

        [Required, Range(10000000, 99999999, ErrorMessage = "Phone number must be 8 digits")]
        public int PhoneNumber { get; set; }
    }
}
