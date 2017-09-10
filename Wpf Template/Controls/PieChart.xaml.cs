using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Wpf_Template
{
    /// <summary>
    /// Логика взаимодействия для PieChart.xaml
    /// </summary>
    public partial class PieChart
    {
        public PieChart()
        {
            InitializeComponent();
            Slices.CollectionChanged += (s, e) => Draw();
            Loaded += (s, e) => { Draw(); };
            //LayoutUpdated += (s, e) => { Draw(); };
            Draw();
        }

        public int StrokeThickness
        {
            get { return (int)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        private ObservableCollection<double> _slices = new ObservableCollection<double>();
        public ObservableCollection<double> Slices
        {
            get { return _slices; }
            set { _slices = value; Draw(); }
        }

        public ObservableCollection<SolidColorBrush> Colors { get; set; } = new ObservableCollection<SolidColorBrush>
        {
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e91e63")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3f51b5")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8bc34a")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffc107")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f44336")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#673ab7")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#03a9f4")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4caf50")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffeb3b")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff5722")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9c27b0")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2196f3")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9800")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#607d8b")),
            new SolidColorBrush((Color)ColorConverter.ConvertFromString("#795548"))
        };

        public static readonly DependencyProperty StrokeThicknessProperty =
    DependencyProperty.Register("StrokeThickness", typeof(int), typeof(PieChart), new PropertyMetadata(10));



        private void Draw()
        {
            double sum = Slices.Sum();
            if (sum <= 0 || Slices.Any(x => x < 0) || !Colors.Any()) return;
            ChartGrid.Children.Clear();
            int i = 0;
            double oldangle = 180.0;
            foreach (double slice in Slices)
            {
                var path = new Path
                {
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    StrokeThickness = StrokeThickness,
                    Stroke = Colors[i % Colors.Count]
                };
                var pg = new PathGeometry();
                var pf = new PathFigure();
                var seg = new ArcSegment { SweepDirection = SweepDirection.Clockwise };
                double angle = slice / sum * 360 + oldangle;
                var startPoint = ComputeCartesianCoordinate(oldangle).Sum(Width == 0 ? ActualWidth / 2 : Width / 2, Height == 0 ? ActualHeight / 2 : Height / 2);
                var endPoint = ComputeCartesianCoordinate(angle).Sum(Width == 0 ? ActualWidth / 2 : Width / 2, Height == 0 ? ActualHeight / 2 : Height / 2);
                pf.StartPoint = startPoint;
                if (Math.Abs(startPoint.X - Math.Round(endPoint.X)) < 1 && Math.Abs(startPoint.Y - Math.Round(endPoint.Y)) < 1)
                    endPoint.X -= 0.1;
                seg.Point = endPoint;
                seg.Size = new Size(Math.Abs(ActualWidth / 2 - (double)StrokeThickness / 2), Math.Abs(ActualHeight / 2 - (double)StrokeThickness / 2));
                seg.IsLargeArc = angle - oldangle > 180.0;

                pf.Segments.Add(seg);

                pg.Figures.Add(pf);
                path.Data = pg;
                Panel.SetZIndex(path, 5);
                path.ToolTip = $"{slice} ({slice / sum:P})";
                ChartGrid.Children.Add(path);

                oldangle = angle;
                i++;
            }
        }

        private Point ComputeCartesianCoordinate(double angle)
        {
            double angleRad = (Math.PI / 180.0) * (angle - 90);
            double x = (ActualWidth / 2 - (double)StrokeThickness / 2) * Math.Cos(angleRad);
            double y = (ActualHeight / 2 - (double)StrokeThickness / 2) * Math.Sin(angleRad);
            return new Point(x, y);
        }


    }

    public static class Extension
    {
        public static Point Sum(this Point point, Point add)
        {
            return new Point(point.X + add.X, point.Y + add.Y);
        }
        public static Point Sum(this Point point, double x, double y)
        {
            return new Point(point.X + x, point.Y + y);
        }
    }
}
