using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;

namespace Wpf_Template
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
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
        private void PopupClose_OnClick(object sender, RoutedEventArgs e)
        {
            PopSettings.IsOpen = false;
        }

        #region ResizeWindows

        private bool _resizeInProcess;


        private void Resize_Init(object sender, MouseButtonEventArgs e)
        {
            var senderRect = sender as Rectangle;
            if (senderRect == null) return;
            _resizeInProcess = true;
            senderRect.CaptureMouse();
        }

        private void Resize_End(object sender, MouseButtonEventArgs e)
        {
            var senderRect = sender as Rectangle;
            if (senderRect == null) return;
            _resizeInProcess = false;
            senderRect.ReleaseMouseCapture();
        }

        private void Resizeing_Form(object sender, MouseEventArgs e)
        {
            const int step = 1;
            if (!_resizeInProcess) return;
            var senderRect = sender as Rectangle;
            var mainWindow = senderRect?.Tag as Window;
            if (mainWindow == null) return;
            double width = e.GetPosition(mainWindow).X;
            double height = e.GetPosition(mainWindow).Y;
            senderRect.CaptureMouse();
            if (senderRect.Name.ToLower().Contains("right"))
            {
                width += step;
                if (width > 0)
                    mainWindow.Width = width;
            }
            if (senderRect.Name.ToLower().Contains("left") && mainWindow.Width - width - step >= MinWidth)
            {

                width -= step;
                mainWindow.Left += width;
                width = mainWindow.Width - width;
                if (width > 0)
                {
                    mainWindow.Width = width;
                }
            }
            if (senderRect.Name.ToLower().Contains("bottom"))
            {
                height += step;
                if (height > 0)
                    mainWindow.Height = height;
            }
            if (senderRect.Name.ToLower().Contains("top") && mainWindow.Height - height - step > MinHeight)
            {
                height -= step;
                mainWindow.Top += height;
                height = mainWindow.Height - height;
                if (height > 0)
                {
                    mainWindow.Height = height;
                }
            }
        }
        #endregion


        private void OnMenuOpening(object sender, object e)
        {
            BodyGrid.Effect = new BlurEffect { Radius = 5 };
        }

        private void OnMenuClosing(object sender, object e)
        {
            BodyGrid.Effect = null;
        }
        #endregion


    }
}
