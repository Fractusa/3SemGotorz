using System.ComponentModel.DataAnnotations;

namespace Gotorz.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = "test";

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Phone number must be exactly 8 digits")]
        public string PhoneNumber { get; set; }
    }
}
