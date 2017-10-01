using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Wpf_Template.ValidationRules
{
    public class DateRule : ValidationRule
    {
        public bool IsUnix { get; set; } = true;
        public override ValidationResult Validate(object value, CultureInfo ci)
        {
            if (!DateTime.TryParse(value?.ToString(), out DateTime val))
            {
                return new ValidationResult(false, Application.Current.Resources["LangWrongInput"]);
            }

            if (IsUnix && val <= new DateTime(1970,1,1))
            {
                return new ValidationResult(false,
                  Application.Current.Resources["LangUncorrectDate"]);
            }
            return new ValidationResult(true, null);
        }
    }
}
