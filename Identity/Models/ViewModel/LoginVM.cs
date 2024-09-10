using System.ComponentModel.DataAnnotations;

namespace Identity.Models.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [MaxLength(40, ErrorMessage = "Email cannot be longer than 40 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.Password)]
        [MaxLength(40)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
