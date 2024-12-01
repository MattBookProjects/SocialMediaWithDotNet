using System.ComponentModel.DataAnnotations;
using System;

namespace OfbooxSocial.Models.ViewModels.Validators
{
    public class PasswordValidator: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var casted = value as string;
            if (casted == null)
            {
                return false;
            }
            if( casted.Length < 10)
            {
                ErrorMessage = "Password must be at least 10 characters long";
                return false;
            }
            var containsLowerCase = false;
            var containsUpperCase = false;
            var containsDigit = false;
            var containsSpecial = false;

            foreach (var c in casted)
            {
                if (Char.IsUpper(c))
                {
                    containsUpperCase = true;
                }
                if (Char.IsLower(c)) { 
                    containsLowerCase = true;
                }
                if (Char.IsDigit(c))
                {
                    containsDigit = true;
                }
                if (!Char.IsLetterOrDigit(c))
                {
                    containsSpecial = true;
                }
            }
            if (!containsUpperCase || !containsLowerCase || !containsDigit || !containsSpecial)
            {
                ErrorMessage = "Password must contain an uppercase letter, a lowercase letter, a digit and a special character";
                return false;
            }
            return true;
        }
    }
}
