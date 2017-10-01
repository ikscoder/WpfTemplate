using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Wpf_Template.ValidationRules
{
    public class LongRule : ValidationRule
    {
        public long Min { get; set; } = long.MinValue;

        public long Max { get; set; } = long.MaxValue;


        public override ValidationResult Validate(object value, CultureInfo ci)
        {
            if (!long.TryParse(value?.ToString(), NumberStyles.Integer, ci, out long val))
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