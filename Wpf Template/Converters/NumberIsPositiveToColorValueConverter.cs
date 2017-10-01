using System;
using System.Globalization;
using System.Windows.Media;

namespace Wpf_Template.Converters
{
    public class NumberIsPositiveToColorValueConverter : ConverterBase<NumberIsPositiveToColorValueConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double.TryParse(value?.ToString().Replace(',', '.'), out double val);
                return val >= 0
                    ? new SolidColorBrush(Color.FromArgb(255, 124, 179, 66))
                    : new SolidColorBrush(Color.FromArgb(255, 244, 67, 54));
            }
            catch
            {
                return Brushes.Transparent;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}