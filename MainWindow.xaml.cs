using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorMatching
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Color matchingColor;

        public MainWindow()
        {
            InitializeComponent();
            ColorSlider_ValueChanged(null, null);
            NewColorButton_Click(null, null);
        }

        private void ColorSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Color color = Color.FromRgb((byte)RedSlider.Value, (byte)GreenSlider.Value, (byte)BlueSlider.Value);
            UserColor.Fill = new SolidColorBrush(color);
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            Color userColor = Color.FromRgb((byte)RedSlider.Value, (byte)GreenSlider.Value, (byte)BlueSlider.Value);
            double distance = Math.Sqrt(Math.Pow(matchingColor.R - userColor.R, 2) + Math.Pow(matchingColor.G - userColor.G, 2) + Math.Pow(matchingColor.B - userColor.B, 2));
            double percentage = distance / Math.Sqrt(Math.Pow(255, 2) + Math.Pow(255, 2) + Math.Pow(255, 2));
            double accuary = 1 - percentage;
            AccuracyPercentage.Content = accuary.ToString("P", CultureInfo.InvariantCulture);
        }

        private void NewColorButton_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            matchingColor = Color.FromRgb((byte)r.Next(), (byte)r.Next(), (byte)r.Next());
            MatchColor.Fill = new SolidColorBrush(matchingColor);
            AccuracyPercentage.Content = "";
        }
    }
}
