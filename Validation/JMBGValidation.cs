using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SR01_2021_POP2022.Validation
{
    public class JMBGValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string valueString = value.ToString();
            if (valueString != "" && valueString.Length == 13)
            {
                return new ValidationResult(true, "");
            }
            return new ValidationResult(false, "Popunite polje");
        }
    }
}
