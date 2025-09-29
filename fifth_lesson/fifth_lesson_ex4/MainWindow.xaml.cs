using System;
using System.Configuration;
using System.Windows;
using System.Windows.Media;

namespace fifth_lesson_ex4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            this.Loaded += MainWindow_Loaded;

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ApplySettings();
        }

        private void ApplySettings()
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            var colorValue = ConfigurationManager.AppSettings["BackgroundColor"];
            if (colorValue != null)
            {
                var color = (Color)ColorConverter.ConvertFromString(colorValue);
                mainWindow.Background = new SolidColorBrush(color);
            }

            var fontColor = ConfigurationManager.AppSettings["FontColor"];
            if (fontColor != null)
            {
                var font = (Color)ColorConverter.ConvertFromString(fontColor);
                Application.Current.MainWindow.Foreground = new SolidColorBrush(font);
            }

            var size = ConfigurationManager.AppSettings["FontSize"];
            if (size != null)
            {
                var fontSize = Convert.ToDouble(size);
                mainWindow.FontSize = fontSize;
            }

            var fontstyle = ConfigurationManager.AppSettings["FontStyle"];
            if (fontstyle != null)
            {
                mainWindow.FontStyle = fontstyle == "0" ? FontStyles.Normal : FontStyles.Italic;
            }
            mainWindow.UpdateLayout();

            MainFrame.Navigate(new Uri("MainPage.xaml", UriKind.Relative));

        }
    }
}
