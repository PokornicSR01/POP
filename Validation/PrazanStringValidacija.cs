using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SR01_2021_POP2022.Validation
{
    public class PrazanStringValidacija : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString() != "")
            {
                return new ValidationResult(true, "");
            }
            return new ValidationResult(false, "Popunite polje");
        }
    }
}
