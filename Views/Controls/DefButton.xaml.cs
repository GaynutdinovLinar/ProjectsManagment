using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Views.Controls
{
    /// <summary>
    /// Логика взаимодействия для DefButton.xaml
    /// </summary>
    public partial class DefButton : Button
    {
        public DefButton()
        {
            InitializeComponent();

            DataContext = this;
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
              nameof(Icon),
              typeof(Geometry),
              typeof(DefButton),
              new PropertyMetadata(null));

        public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register(
             nameof(IconHeight),
             typeof(double),
             typeof(DefButton),
             new PropertyMetadata(0d));

        public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register(
             nameof(IconWidth),
             typeof(double),
             typeof(DefButton),
             new PropertyMetadata(0d));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
              nameof(CornerRadius),
              typeof(CornerRadius),
              typeof(DefButton),
              new PropertyMetadata(new CornerRadius(0)));

        public static readonly DependencyProperty SpaceProperty = DependencyProperty.Register(
             nameof(Space),
             typeof(double),
             typeof(DefButton),
             new PropertyMetadata(0d));

        public static readonly DependencyProperty TextVerticalAligmentProperty = DependencyProperty.Register(
             nameof(TextVerticalAligment),
             typeof(VerticalAlignment),
             typeof(DefButton),
             new PropertyMetadata(VerticalAlignment.Center));

        public static readonly DependencyProperty HoverBackgroundProperty = DependencyProperty.Register(
             nameof(HoverBackground),
             typeof(Brush),
             typeof(DefButton),
             new PropertyMetadata(Brushes.Gray));

        public static readonly DependencyProperty DisabledBackgroundProperty = DependencyProperty.Register(
             nameof(DisabledBackground),
             typeof(Brush),
             typeof(DefButton),
             new PropertyMetadata(Brushes.Gray));

        public static readonly DependencyProperty HoverForegroundProperty = DependencyProperty.Register(
             nameof(HoverForeground),
             typeof(Brush),
             typeof(DefButton),
             new PropertyMetadata(Brushes.Black));

        public static readonly DependencyProperty DisabledForegroundProperty = DependencyProperty.Register(
             nameof(DisabledForeground),
             typeof(Brush),
             typeof(DefButton),
             new PropertyMetadata(Brushes.Black));

        public Geometry Icon
        {
            get => (Geometry)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public double IconHeight
        {
            get => (double)GetValue(IconHeightProperty);
            set => SetValue(IconHeightProperty, value);
        }

        public double IconWidth
        {
            get => (double)GetValue(IconWidthProperty);
            set => SetValue(IconWidthProperty, value);
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public double Space
        {
            get => (double)GetValue(SpaceProperty);
            set => SetValue(SpaceProperty, value);
        }

        public VerticalAlignment TextVerticalAligment
        {
            get => (VerticalAlignment)GetValue(TextVerticalAligmentProperty);
            set => SetValue(TextVerticalAligmentProperty, value);
        }

        public Brush HoverBackground
        {
            get => (Brush)GetValue(HoverBackgroundProperty);
            set => SetValue(HoverBackgroundProperty, value);
        }

        public Brush DisabledBackground
        {
            get => (Brush)GetValue(DisabledBackgroundProperty);
            set => SetValue(DisabledBackgroundProperty, value);
        }

        public Brush HoverForeground
        {
            get => (Brush)GetValue(HoverForegroundProperty);
            set => SetValue(HoverForegroundProperty, value);
        }

        public Brush DisabledForeground
        {
            get => (Brush)GetValue(DisabledForegroundProperty);
            set => SetValue(DisabledForegroundProperty, value);
        }

    }
}
