using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MyProject.API.Validation
{
    public class TZValidation : ValidationAttribute
    {
        private Regex _regex = new Regex(@"[0-9]{9}");

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (_regex.IsMatch(value.ToString()))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Solo se permite letras, numeros y puntuaciones(- _ .)");
        }
    }
}
