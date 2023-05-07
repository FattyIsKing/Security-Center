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
    /// Logika interakcji dla klasy PasswordChecker.xaml
    /// </summary>
    public partial class PasswordChecker : Window
    {
        public PasswordChecker()
        {
            InitializeComponent();
        }


        public void Checker(string password) 
        {
            // Utworzenie nowego obiektu SolidColorBrush o kolorze #4caf50
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff5050"));

            int passwordLength = password.Length;
            int upperCaseCount = 0;
            int specialCharCount = 0;
            int digitCount = 0;

            // Sprawdź długość hasła
            if (passwordLength < 8)
            {
                result.Foreground = brush;
                result.Text = "Słabe hasło";
            }
            else if (passwordLength < 10)
            {
                // Sprawdź, czy hasło zawiera co najmniej jedną dużą literę, jeden znak specjalny i dwie cyfry
                foreach (char c in password)
                {
                    if (Char.IsUpper(c))
                    {
                        upperCaseCount++;
                    }
                    else if ("!@#$%^&*()_+-=[]{};':\"\\|,.<>/?".Contains(c))
                    {
                        specialCharCount++;
                    }
                    else if (Char.IsDigit(c))
                    {
                        digitCount++;
                    }
                }

                if (upperCaseCount >= 1 && specialCharCount >= 1 && digitCount >= 1)
                {
                    result.Foreground = new SolidColorBrush(Colors.Orange);
                    result.Text = "Średnie hasło";
                }
                else
                {
                    result.Foreground = brush;
                    result.Text = "Słabe hasło";
                }
            }
            else
            {
                // Sprawdź, czy hasło zawiera co najmniej trzy duże litery, trzy znaki specjalne i cztery cyfry
                foreach (char c in password)
                {
                    if (Char.IsUpper(c))
                    {
                        upperCaseCount++;
                    }
                    else if ("!@#$%^&*()_+-=[]{};':\"\\|,.<>/?".Contains(c))
                    {
                        specialCharCount++;
                    }
                    else if (Char.IsDigit(c))
                    {
                        digitCount++;
                    }
                }

                if (upperCaseCount >= 3 && specialCharCount >= 3 && digitCount >= 3)
                {
                    result.Foreground = new SolidColorBrush(Colors.Green);
                    result.Text = "Silne hasło";
                }
                else
                {
                    result.Foreground = new SolidColorBrush(Colors.Orange);
                    result.Text = "Średnie hasło";
                }
            }
        }





        //funkcja która zamyka aplikację
        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }





        //funkcja pozwalająca na przemieszczanie okienka aplikacji
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }




        private void menuOpen(object sender, RoutedEventArgs e)
        {
            this.Hide(); // Ukrywamy bieżące okno
            MainWindow mainForm = new MainWindow(); // Tworzymy obiekt klasy MainWindow (główne okno)
            mainForm.Show(); // Otwieramy główne okno
        }






        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            string password = Password.Text;

            if (Password.Text == "")
            {
                result.Text = "";
            }
            else
            {
                Checker(password);
            }
        }




        private void Password_GotFocus(object sender, RoutedEventArgs e)
        {
            // Utworzenie nowego obiektu SolidColorBrush o kolorze #4caf50
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4caf50"));

            // Ustawienie koloru ramki TextBoxa na brush
            Password.BorderBrush = brush;
        }



        private void Password_LostFocus(object sender, RoutedEventArgs e)
        {
            // Utworzenie nowego obiektu SolidColorBrush o kolorze #FFC0BBBB
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC0BBBB"));

            // Ustawienie koloru ramki TextBoxa na brush
            Password.BorderBrush = brush;
        }



       
    }
}
