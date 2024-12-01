using System.ComponentModel.DataAnnotations;

namespace OfbooxSocial.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; } = string.Empty;

    }
}
