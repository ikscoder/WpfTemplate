using System;
using System.Globalization;

namespace Wpf_Template.Converters
{
    public class InverseBooleanConverter : ConverterBase<InverseBooleanConverter>
    {
        #region ConverterBase<> Members

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(bool) && targetType != typeof(bool?))
                return value;

            return value != null && !(bool)value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            if (targetType != typeof(bool) && targetType != typeof(bool?))
                return value;

            return value != null && !(bool)value;
        }

        #endregion
    }
}