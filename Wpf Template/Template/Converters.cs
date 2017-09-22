using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Wpf_Template
{
    public class InverseBooleanConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(bool) && targetType != typeof(bool?))
                return value;

            return value != null && !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(bool) && targetType != typeof(bool?))
                return value;

            return value != null && !(bool)value;
        }

        #endregion
    }

    public class BooleanColorConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            try
            {
                //return !(bool)value ? (Color)(new ColorConverter().ConvertFrom("#ff76ff03")) : (Color)(new ColorConverter().ConvertFrom("#ffb71c1c"));
                return !(bool) value
                    ? ((Color)Application.Current.Resources["CheckedColor"])
                    : ((Color)Application.Current.Resources["UncheckedColor"]);
            }
            catch
            {
                return Colors.Transparent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }

    public class ColorToSolidColorBrushValueConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (value as SolidColorBrush)?.Color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value == null ? null : new SolidColorBrush((Color)value);
        }
    }

    public class FontFamilyToStringValueConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value == null ? null : new FontFamilyConverter().ConvertFrom((string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            return (value as FontFamily)?.ToString();
        }
    }

    public class InverseSignValueConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return -1*double.Parse(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            return -1 * double.Parse(value.ToString());
        }
    }

    public class TextExistenceToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return string.IsNullOrEmpty(value?.ToString()) ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }

    public class BoolToInvisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            try
            {
                return (bool)value ? Visibility.Hidden : Visibility.Visible;
            }
            catch
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }

    public class BoolToCollapsedConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
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

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }


    public class BoolToUnCollapsedConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            try
            {
                return value != null && (bool)value ? Visibility.Visible : Visibility.Collapsed;
            }
            catch
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
