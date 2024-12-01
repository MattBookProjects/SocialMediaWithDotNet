using System.ComponentModel.DataAnnotations;
using OfbooxSocial.Models.ViewModels.Validators;

namespace OfbooxSocial.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required")]
        [PasswordValidator]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required")]
        [RepeatPasswordValidator]
        public string RepeatPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required")]
        [EmailAddress(ErrorMessage = "This field has to be a valid email address")]
        public string Email { get; set; } = string.Empty;

    }
}
