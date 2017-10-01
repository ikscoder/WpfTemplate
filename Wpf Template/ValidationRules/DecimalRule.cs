using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Wpf_Template.ValidationRules
{
    public class DecimalRule : ValidationRule
    {
        public decimal Min { get; set; } = decimal.MinValue;

        public decimal Max { get; set; } = decimal.MaxValue;


        public override ValidationResult Validate(object value, CultureInfo ci)
        {
            if(!decimal.TryParse(value?.ToString(), NumberStyles.Float, ci, out decimal val))
            { 
                return new ValidationResult(false, Application.Current.Resources["LangWrongInput"]);
            }

            if (val < Min || val > Max)
            {
                return new ValidationResult(false,
                  Application.Current.Resources["LangUncorrectValue"]);
            }
            return new ValidationResult(true, null);
        }
    }
}
