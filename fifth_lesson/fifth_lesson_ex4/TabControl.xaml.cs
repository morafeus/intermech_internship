
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace fifth_lesson_ex4
{
    public partial class TabControl : Page
    {
        private string _background = string.Empty;
        private string _foreground = string.Empty;
        private string _fontsize = string.Empty;
        private string _fontstyle = string.Empty;

        private SettingsController controller = new SettingsController();

        public TabControl()
        {
            InitializeComponent();

            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            _background = mainWindow.Background.ToString();
            _foreground = mainWindow.Foreground.ToString();
            _fontsize = mainWindow.FontSize.ToString();

            this.FontSizeBox.Text = mainWindow.FontSize.ToString();
            this.StyleSelector.SelectedIndex =  mainWindow.FontStyle == FontStyles.Normal ? 0 : 1;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _background = "#666666";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _background = "#f5f5f5";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _background = "#aa8ebf";
        }

        private void SetColor(string value, SettingType type)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            Color color = (Color)ColorConverter.ConvertFromString(value);
            switch (type)
            {
                case SettingType.BackGround:
                    mainWindow.Background = new SolidColorBrush(color); break;
                case SettingType.ForeGround:
                    mainWindow.Foreground = new SolidColorBrush(color);break;
                default:
                    break;

            }
        }

        private void SetParam(string value, SettingType type)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            switch (type)
            {
                case SettingType.FontSize:
                    mainWindow.FontSize = Convert.ToDouble(value); break;
                case SettingType.FontStyle:
                    mainWindow.FontStyle = _fontstyle == "0" ? FontStyles.Normal : FontStyles.Italic; break;
                default:
                    break;

            }
        }

        private void ConfirmChanges()
        {
            SetColor(_background, SettingType.BackGround);
            SetColor(_foreground, SettingType.ForeGround);
            SetParam(_fontsize, SettingType.FontSize);
            SetParam(_fontstyle, SettingType.FontStyle);

            NavigationService.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
        }

        

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            _foreground = "#000000";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            _foreground = "#fffff0";
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            _foreground = "#ff0000";
        }

        private void FontSizeBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _fontsize = this.FontSizeBox.Text;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {


            controller.SaveConfig(_background, SettingType.BackGround);
            controller.SaveConfig(_foreground, SettingType.ForeGround);
            controller.SaveConfig(_fontsize, SettingType.FontSize);
            controller.SaveConfig(_fontstyle, SettingType.FontStyle);

            ConfirmChanges();
           
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _fontstyle = StyleSelector.SelectedIndex.ToString();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            controller.SaveToRegistry(_background, SettingType.BackGround);
            controller.SaveToRegistry(_foreground, SettingType.ForeGround);
            controller.SaveToRegistry(_fontsize, SettingType.FontSize);
            controller.SaveToRegistry(_fontstyle, SettingType.FontStyle);
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            _background = controller.LoadFromRegistry(SettingType.BackGround);
            _foreground = controller.LoadFromRegistry(SettingType.ForeGround);
            _fontsize = controller.LoadFromRegistry(SettingType.FontSize);
            _fontstyle = controller.LoadFromRegistry(SettingType.FontStyle);

            ConfirmChanges();
        }

    }
}


