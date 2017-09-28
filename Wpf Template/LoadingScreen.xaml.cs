using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Wpf_Template
{
    public partial class LoadingScreen
    {
        public LoadingScreen()
        {
            Settings.Load();
            InitializeComponent();
            Version.Content = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        }

        private async void LoadingScreen_OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
    
                LoadingLabel.Content = "Useless Loading...";
                await Task.Run(() => { Thread.Sleep(2000); });
                Hide();
                new MainWindow().Show();
            }
            catch (Exception exception)
            {
                App.Log.Error(exception);
                Message.Show("Loading error: " + exception.Message, (string)Application.Current.Resources["LangError"]);
                Application.Current.Shutdown(1);
            }
        }

        private void Path_OnInitialized(object sender, EventArgs e)
        {
            var da = new DoubleAnimation(0, 359, new Duration(TimeSpan.FromMilliseconds(1200)));
            var rt = new RotateTransform();
            ((UIElement)sender).RenderTransform = rt;
            ((UIElement)sender).RenderTransformOrigin = new Point(0.5, 0.5);
            da.RepeatBehavior = RepeatBehavior.Forever;
            rt.BeginAnimation(RotateTransform.AngleProperty, da);
        }
    }
}
