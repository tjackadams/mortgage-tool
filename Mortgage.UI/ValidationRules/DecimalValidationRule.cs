using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mortgage.UI.ValidationRules
{
    using System.Globalization;
    using System.Windows.Controls;

    public class DecimalValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrWhiteSpace((value ?? string.Empty).ToString()))
            {
                return ValidationResult.ValidResult;
            }

            if (decimal.TryParse((value ?? string.Empty).ToString(), out decimal result))
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "Enter a valid amount.");
        }
    }
}
