using System;
using System.Globalization;
using System.Windows.Media;

namespace Wpf_Template.Converters
{
    public class ColorToSolidColorBrushValueConverter : ConverterBase<ColorToSolidColorBrushValueConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as SolidColorBrush)?.Color;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? null : new SolidColorBrush((Color)value);
        }
    }
}