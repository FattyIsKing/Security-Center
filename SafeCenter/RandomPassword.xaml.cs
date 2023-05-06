using MaterialDesignThemes.Wpf;
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
using System.Windows.Shapes;

namespace SafeCenter
{
    /// <summary>
    /// Logika interakcji dla klasy RandomPassword.xaml
    /// </summAary>
    /// 
    public partial class RandomPassword : Window
    {
        public RandomPassword()
        {
            InitializeComponent();
        }

        static string PassswordGenerator(int length)
        {
           
            // Lista znaków, z których ma być generowane hasło
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789|@#%$&*^?.";

            // Generator liczb pseudolosowych
            Random random = new Random();

            // Generowanie hasła
            string password = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return password;
        }



        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }





        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            DragMove();
        }


        private void Count_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidNumericChars(e.Text);
        }




        private bool AreAllValidNumericChars(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }



        string passwordHolder = "";
        private void generate_Click(object sender, RoutedEventArgs e)
        {

          
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff5050"));

            this.Height = 540;

            if (Count.Text == "" || Count.Text == "0")
            {
                result.Foreground = brush;
                result.Text = "Nie wpisano długości hasła";
                copyMessage.Visibility = Visibility.Collapsed;
                result.Visibility = Visibility.Visible;
            }
            else
            {
                int count = Convert.ToInt32(Count.Text);
                string password = PassswordGenerator(count);
                passwordHolder = password;
                copyMessage.Visibility = Visibility.Visible;
                result.Visibility = Visibility.Collapsed;
            }
        }


        private void copyMessage_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(passwordHolder);
        }




        private void menuOpen(object sender, RoutedEventArgs e)
        {
            this.Hide(); // Ukrywamy bieżące okno
            MainWindow mainWindow = new MainWindow(); // Tworzymy obiekt klasy MainWindow (główne okno)
            mainWindow.Show(); // Otwieramy główne okno
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                generate_Click(sender, e);
            }

        }

        private void Count_GotFocus(object sender, RoutedEventArgs e)
        {
            // Utworzenie nowego obiektu SolidColorBrush o kolorze #4caf50
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4caf50"));

            // Ustawienie koloru ramki TextBoxa na brush
            Count.BorderBrush = brush;
        }

        private void Count_LostFocus(object sender, RoutedEventArgs e)
        {
            // Utworzenie nowego obiektu SolidColorBrush o kolorze #FFC0BBBB
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC0BBBB"));

            // Ustawienie koloru ramki TextBoxa na brush
            Count.BorderBrush = brush;
        }
    }
}
