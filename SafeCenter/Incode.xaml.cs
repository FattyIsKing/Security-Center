using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// Logika interakcji dla klasy Incode.xaml
    /// </summary>
    public partial class Incode : Window
    {

        

        public Incode()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            
        }

        

        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }





        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }





        static string CaesarEncode(string message, List<char> letters, int adder)
        {
            string encodedMessage = "";

            foreach (char c in message)
            {
                if (Char.IsLetter(c))
                {
                    bool isUpper = Char.IsUpper(c);
                    int index = letters.IndexOf(Char.ToLower(c));

                    if (index != -1)
                    {
                        int newIndex = (index + adder) % letters.Count;

                        if (isUpper)
                        {
                            encodedMessage += Char.ToUpper(letters[newIndex]);
                        }
                        else
                        {
                            encodedMessage += letters[newIndex];
                        }
                    }
                    else
                    {
                        // Jeśli znak nie znajduje się w liście liter, zostawiamy go bez zmian.
                        encodedMessage += c;
                    }
                }
                else if (char.IsDigit(c))
                {
                    encodedMessage += (int)Char.GetNumericValue(c) + adder;
                }
                else
                {
                    // Jeśli znak nie jest literą, zostawiamy go bez zmian.
                    encodedMessage += c;
                }
            }

            return encodedMessage;
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


        
        private void incodeBtn_Click(object sender, RoutedEventArgs e)
        {
            
            // Utworzenie nowego obiektu SolidColorBrush o kolorze #4caf50
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff5050"));



            List<char> letters = new List<char>() { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'q', 'r', 's', 'ś', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'ź', 'ż' };
            string text = Message.Text;
            string count = Count.Text;

            if (count == "" && text == "")
            {
                this.Height = 590;
                result.Foreground = brush;
                result.Text = "Nie wpisano żadnej informacji!";
                
            }
            else if (count == "")
            {
                this.Height = 590;
                result.Foreground = brush;
                result.Text = "Nie wpisano, o ile mają być przesunięte litery!";
                
            }
            else if (text == "")
            {
                this.Height = 590;
                result.Foreground = brush;
                result.Text = "Nie wpisano wiadomości!";
                
            }
            else
            {

                
                string toIncode = CaesarEncode(text, letters, Convert.ToInt32(count));
                this.Height = 550;
                Encrypted.Text = toIncode;
                result.Text = "";
            }
        }


        private void menuOpen(object sender, RoutedEventArgs e)
        {
            this.Hide(); // Ukrywamy bieżące okno
            MainWindow mainForm = new MainWindow(); // Tworzymy obiekt klasy MainWindow (główne okno)
            mainForm.Show(); // Otwieramy główne okno
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                incodeBtn_Click(sender, e);
            }

        }



        private void copyMessage_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(Encrypted.Text);
        }



        private void Message_GotFocus(object sender, RoutedEventArgs e)
        {
            // Utworzenie nowego obiektu SolidColorBrush o kolorze #4caf50
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4caf50"));

            // Ustawienie koloru ramki TextBoxa na brush
            Message.BorderBrush = brush;
        }

        private void Message_LostFocus(object sender, RoutedEventArgs e)
        {
            // Utworzenie nowego obiektu SolidColorBrush o kolorze #FFC0BBBB
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC0BBBB"));

            // Ustawienie koloru ramki TextBoxa na brush
            Message.BorderBrush = brush;
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


        private void Count_TextChanged(object sender, TextChangedEventArgs e)
        {
            Encrypted.Text = "";
        }

        private void Message_TextChanged(object sender, TextChangedEventArgs e)
        {
            Encrypted.Text = "";
        }
    }
}
