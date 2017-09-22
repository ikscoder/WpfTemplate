using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace Wpf_Template
{
    public partial class MaterialTextBox
    {
        public MaterialTextBox()
        {
            InitializeComponent();
        }

        public Validator Validator
        {
            get
            {
                return (Validator)GetValue(ValidatorProperty);
            }
            set
            {
                SetValue(ValidatorProperty, value);
            }
        }
        public static readonly DependencyProperty ValidatorProperty =
        DependencyProperty.Register("Validator", typeof(Validator), typeof(MaterialTextBox), new PropertyMetadata(Validator.Not, OnPropertyChanged));

        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }
        public static readonly DependencyProperty IsValidProperty =
    DependencyProperty.Register("IsValid", typeof(bool), typeof(MaterialTextBox), new PropertyMetadata(true, OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            if (args.Property.Name == nameof(IsValid))
            {
                var s = sender as MaterialTextBox;
                if (s != null)
                    s.Resources["ValidBrush"] = s.IsValid ? ((SolidColorBrush)Application.Current.Resources["PrimaryBrush"]) : ((SolidColorBrush)Application.Current.Resources["UncheckedBrush"]);
            }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
DependencyProperty.Register("Text", typeof(string), typeof(MaterialTextBox), new PropertyMetadata(null, OnPropertyChanged));

        public string WrongText
        {
            get { return (string)GetValue(WrongTextProperty); }
            set { SetValue(WrongTextProperty, value); }
        }
        public static readonly DependencyProperty WrongTextProperty =
DependencyProperty.Register("WrongText", typeof(string), typeof(MaterialTextBox), new PropertyMetadata("Неверные данные", OnPropertyChanged));

        private void Validate()
        {
            IsValid = true;
            if (string.IsNullOrWhiteSpace(TextBox.Text)) return;
            switch (Validator)
            {
                case Validator.Double:
                    IsValid = double.TryParse(TextBox.Text, out double val1);
                    break;
                case Validator.Long:
                    IsValid = long.TryParse(TextBox.Text, out long val2);
                    break;
                case Validator.Email:
                    IsValid = IsValidEmail(TextBox.Text);
                    break;
                case Validator.DateTime:
                    IsValid = DateTime.TryParse(TextBox.Text, out DateTime val3);
                    break;
                case Validator.Not:
                default:
                    break;
            }
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void TextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            Validate();
        }

        private void TextBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            Validate();
        }
    }



    public enum Validator
    {
        Email,
        DateTime,
        Double,
        Long,
        Not
    }

    public class MTextExistenceToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            return string.IsNullOrEmpty(value?.ToString()) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }

    public class MTextNotExistenceToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            return !string.IsNullOrEmpty(value?.ToString()) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
