using System;
using System.Globalization;

namespace Wpf_Template.Converters
{
    public class UnixTimeToDateConverter : ConverterBase<UnixTimeToDateConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            long.TryParse(value?.ToString(), out long val);
            return val.FromUnixTime().ToString("dd MMMM yyyy");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}