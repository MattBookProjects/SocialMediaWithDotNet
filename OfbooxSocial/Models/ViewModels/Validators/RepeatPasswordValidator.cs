using System.ComponentModel.DataAnnotations;

namespace OfbooxSocial.Models.ViewModels.Validators
{
    public class RepeatPasswordValidator: ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var password = value as string;
        
            var viewModel = validationContext.ObjectInstance as RegisterViewModel;
            if (password != null && 
                viewModel != null && 
                viewModel.Password != null && 
                password.Equals(viewModel.Password))
            {
                return ValidationResult.Success;
            }
            else
            {
                Console.WriteLine("INVALID");
                return new ValidationResult("Passwords don't match");
            }
            ;
          /*  var repeatPassword = validationContext.Items["RepeatPassword"];
            if (password != null && repeatPassword != null && password.Equals(repeatPassword)){
                return ValidationResult.Success;
            } else
            {
                return new ValidationResult("Passwords don't match");
            } */

        }
    }
}
