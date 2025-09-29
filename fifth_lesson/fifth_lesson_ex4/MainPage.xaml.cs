using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace fifth_lesson_ex4
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("TabControl.xaml", UriKind.Relative));
        }
    }
}
