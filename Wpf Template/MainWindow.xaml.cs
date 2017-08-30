using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Wpf_Template
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            PopSettings.Closed += (s, e) => { BodyGrid.Effect = null; };
            ThemeBox.SelectionChanged += ThemeChange;
            ThemeBox.ItemsSource = Enum.GetValues(typeof(Settings.Theme)).Cast<Settings.Theme>();
            ThemeBox.SelectedItem = Settings.Current.AppTheme;
            LangBox.SelectionChanged += LanguageChange;
            LangBox.ItemsSource = Enum.GetValues(typeof(Settings.Language)).Cast<Settings.Language>();
            LangBox.SelectedItem = Settings.Current.AppLanguage;
           
        }

        #region GUI

        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            Settings.Save();
            Application.Current.Shutdown();
        }

        private void BMaximize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void BMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BSettings_Click(object sender, RoutedEventArgs e)
        {
            BodyGrid.Effect = new BlurEffect();
            PopSettings.IsOpen = true;
        }

        public void Drag(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) return;
            Opacity = 0.5;
            DragMove();
            Opacity = 1;
        }

        private void BAlwaysOnTop_Click(object sender, RoutedEventArgs e)
        {
            BAlwaysOnTop.RenderTransform = Topmost ? null : new RotateTransform { Angle = -45 };
            Topmost = !Topmost;
        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            Settings.Current.AppTheme = (Settings.Theme)Enum.Parse(typeof(Settings.Theme), ThemeBox.SelectedItem.ToString());//(Settings.Theme)ThemeBox.SelectedItem;
            CustomThemePicker.Visibility = Settings.Current.AppTheme == Settings.Theme.Custom ? Visibility.Visible : Visibility.Hidden;
            PopSettings.Width= Settings.Current.AppTheme == Settings.Theme.Custom ? 700 : 400;
        }

        private void LanguageChange(object sender, SelectionChangedEventArgs e)
        {
            Settings.Current.AppLanguage = (Settings.Language)LangBox.SelectedItem;
        }

        #endregion

        private void PopupClose_OnClick(object sender, RoutedEventArgs e)
        {
            PopSettings.IsOpen = false;
        }
    }
}
