using System;
using System.Globalization;
using System.Windows.Media;

namespace Wpf_Template.Converters
{
    public class FontFamilyToStringValueConverter : ConverterBase<FontFamilyToStringValueConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? null : new FontFamilyConverter().ConvertFrom((string)value);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return (value as FontFamily)?.ToString();
        }
    }
}