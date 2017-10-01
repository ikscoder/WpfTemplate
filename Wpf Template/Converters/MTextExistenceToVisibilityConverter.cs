using System;
using System.Globalization;
using System.Windows;

namespace Wpf_Template.Converters
{
    public class MTextExistenceToVisibilityConverter : ConverterBase<MTextExistenceToVisibilityConverter>
    {
        #region IValueConverter Members

        public override object Convert(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            return !string.IsNullOrEmpty(value?.ToString()) ? Visibility.Visible : Visibility.Collapsed;
        }

        public override object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}