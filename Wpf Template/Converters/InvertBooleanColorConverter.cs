using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace Wpf_Template.Converters
{
    public class InvertBooleanColorConverter : ConverterBase<InvertBooleanColorConverter>
    {
        #region ConverterBase<> Members

        public override object Convert(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            try
            {
                bool.TryParse(value?.ToString(), out bool val);
                return val
                    ? ((Color)Application.Current.Resources["CheckedColor"])
                    : ((Color)Application.Current.Resources["UncheckedColor"]);
            }
            catch
            {
                return Colors.Transparent;
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