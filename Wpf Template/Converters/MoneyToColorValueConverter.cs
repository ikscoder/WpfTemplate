using System;
using System.Globalization;
using System.Windows.Media;

namespace Wpf_Template.Converters
{
    public class MoneyToColorValueConverter : ConverterBase<MoneyToColorValueConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double.TryParse(value?.ToString(), out double val);
                if (Math.Abs(val) <= 100)
                    return new SolidColorBrush(Color.FromArgb(128, 255, 255, 0));
                if (val > 100)
                    return new SolidColorBrush(Color.FromArgb(255, 124, 179, 66));
                if (val < -100)
                    return new SolidColorBrush(Color.FromArgb(255, 244, 67, 54));
                return Brushes.Transparent;
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