using System;
using System.Globalization;

namespace Wpf_Template.Converters
{
    public class DateTimeToUnixTimeConverter : ConverterBase<DateTimeToUnixTimeConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DateTime.TryParse(value?.ToString(), out DateTime val))
            {
                try
                {
                    return val.ToUnixTime();
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                long.TryParse(value?.ToString(), out long val2);
                try
                {
                    return val2.FromUnixTime();
                }
                catch
                {
                    return new DateTime(1970,1,1);
                }
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DateTime.TryParse(value?.ToString(), out DateTime val))
            {
                try
                {
                    return val.ToUnixTime();
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                long.TryParse(value?.ToString(), out long val2);
                try
                {
                    return val2.FromUnixTime();
                }
                catch
                {
                    return new DateTime(1970, 1, 1);
                }
            }
        }
    }
}