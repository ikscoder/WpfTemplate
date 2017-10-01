using System;
using System.Globalization;

namespace Wpf_Template.Converters
{
    public class InverseSignValueConverter : ConverterBase<InverseSignValueConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return -1 * double.Parse(value.ToString());
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return -1 * double.Parse(value.ToString());
        }
    }
}