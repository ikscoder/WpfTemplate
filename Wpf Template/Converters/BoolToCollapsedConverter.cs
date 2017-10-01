using System;
using System.Globalization;
using System.Windows;

namespace Wpf_Template.Converters
{
    public class BoolToCollapsedConverter : ConverterBase<BoolToCollapsedConverter>
    {
        #region ConverterBase<> Members

        public override object Convert(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            try
            {
                return value == null || (bool)value ? Visibility.Collapsed : Visibility.Visible;
            }
            catch
            {
                return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}