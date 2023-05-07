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

        private string PasswordGenerator(int length, bool useLowercase, bool useUppercase, bool useNumbers, bool useSpecialChars)
        {
            string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
            string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbersChars = "0123456789";
            string specialChars = "|@#%$&*^?.";
            string chars = "";

            if (useLowercase)
            {
                chars += lowercaseChars;
            }
            if (useUppercase)
            {
                chars += uppercaseChars;
            }
            if (useNumbers)
            {
                chars += numbersChars;
            }
            if (useSpecialChars)
            {
                chars += specialChars;
            }

            if (chars.Length == 0)
            {
                // Jeśli żadna opcja nie jest zaznaczona, zwróć pusty ciąg znaków
                return "";
            }

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


        bool useLowercase = false;
        bool useUppercase = false;
        bool useNumbers = false;
        bool useSpecialChars = false;


        private void lowercase_Checked(object sender, RoutedEventArgs e)
        {
            useLowercase = true;
        }

        private void uppercase_Checked(object sender, RoutedEventArgs e)
        {
            useUppercase = true;
        }

        private void numbers_Checked(object sender, RoutedEventArgs e)
        {
            useNumbers = true;
        }

        private void specialChars_Checked(object sender, RoutedEventArgs e)
        {
            useSpecialChars = true;
        }



        private void lowercase_Unchecked(object sender, RoutedEventArgs e)
        {
            useLowercase = false;
        }

        private void uppercase_Unchecked(object sender, RoutedEventArgs e)
        {
            useUppercase = false;
        }

        private void numbers_Unchecked(object sender, RoutedEventArgs e)
        {
            useNumbers = false;
        }

        private void specialChars_Unchecked(object sender, RoutedEventArgs e)
        {
            useSpecialChars = false;
        }


        private void generate_Click(object sender, RoutedEventArgs e)
        {

            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff5050"));

            
            if (Count.Text == "" || Count.Text == "0")
            {
                result.Foreground = brush;
                result.Text = "Nie wpisano długości hasła";
                this.Height = 610;
            }
            else
            {
                if(!useLowercase && !useNumbers && !useSpecialChars && !useUppercase)
                {
                    result.Foreground = brush;
                    result.Text = "Nie podano żadnej właściwości";
                    this.Height = 610;
                }
                else
                {
                    int count = Convert.ToInt32(Count.Text);
                    string password = PasswordGenerator(count, useLowercase, useUppercase, useNumbers, useSpecialChars);
                    PasswordGenerate.Text = password;
                    this.Height = 570;
                    result.Text = "";
                }
                

            }
        }


        private void copyMessage_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(PasswordGenerate.Text);
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
