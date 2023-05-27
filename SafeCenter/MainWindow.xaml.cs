using System;
using System.Collections.Generic;
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
using MaterialDesignThemes.Wpf;
using System.Windows.Media.Animation;
using System.Diagnostics;

namespace SafeCenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Incode window1;
        private Decode window2;
        private RandomPassword window3;
        private PasswordChecker window5;
        private IncodeUltra window6;
        private DecodeUltra window7;

        public MainWindow()
        {
            InitializeComponent();
            window1 = new Incode();
            window2 = new Decode();
            window3 = new RandomPassword();
            window5 = new PasswordChecker();
            window6 = new IncodeUltra();
            window7 = new DecodeUltra();
        }


        private void OpenWebsite()
        {
            string url = "https://github.com/GrubyIsKing/Security-Center"; // Adres URL strony, na którą chcesz przekierować użytkownika

            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void projectGithub(object sender, RoutedEventArgs e)
        {
            OpenWebsite();
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }



        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            DragMove();
        }



        private void incodeBtn_Click(object sender, RoutedEventArgs e)
        {
            window1.Show();
            this.Hide();
        }



        private void decodeBtn_Click(object sender, RoutedEventArgs e)
        {
            window2.Show();
            this.Hide();
        }




        private void passBtn_Click(object sender, RoutedEventArgs e)
        {
            window3.Show();
            this.Hide();
        }



        private void passcheckBtn_Click(object sender, RoutedEventArgs e)
        {
            window5.Show();
            this.Hide();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var greenPrimaryDictionary = new ResourceDictionary();
            greenPrimaryDictionary.Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Green.xaml");

            Application.Current.Resources.MergedDictionaries.Add(greenPrimaryDictionary);
        }



        private void incodeUltraBtn_Click(object sender, RoutedEventArgs e)
        {
            window6.Show();
            this.Hide();
        }



        private void decodeUltraBtn_Click(object sender, RoutedEventArgs e)
        {
            window7.Show();
            this.Hide();
        }
    }
}
