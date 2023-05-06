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
    /// Logika interakcji dla klasy Decode.xaml
    /// </summary>
    public partial class Decode : Window
    {
        

        public Decode()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }

        static string CaesarDecode(string message, List<char> letters, int adder)
        {
            int size = letters.Count();
            string decodedMessage = "";

            foreach (char c in message)
            {
                if (Char.IsUpper(c))
                {
                    int index = letters.IndexOf(Char.ToLower(c));

                    if (index - adder < 0)
                    {
                        int diff = adder - index;
                        decodedMessage += Char.ToUpper(letters[size - diff % size]);
                    }
                    else
                    {
                        decodedMessage += Char.ToUpper(letters[(index - adder) % size]);
                    }
                }
                else if (c == ' ')
                {
                    decodedMessage += " ";
                }
                else if (char.IsDigit(c))
                {
                    decodedMessage += Math.Abs((int)Char.GetNumericValue(c)) - adder;
                }
                else if(Char.IsLower(c))
                {
                    int index = letters.IndexOf(c);

                    if (index - adder < 0)
                    {
                        int diff = adder - index;
                        decodedMessage += letters[size - diff % size];
                    }
                    else
                    {
                        decodedMessage += letters[(index - adder) % size];
                    }
                }
                else
                {
                    // Jeśli znak nie jest literą, zostawiamy go bez zmian.
                    decodedMessage += c;
                }
            }

            return decodedMessage;
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

        string messageDecrypted = "";

        private void decodeBtn_Click(object sender, RoutedEventArgs e)
        {

            // Utworzenie nowego obiektu SolidColorBrush o kolorze #4caf50
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff5050"));


            List<char> letters = new List<char>() { 'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'q', 'r', 's', 'ś', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'ź', 'ż' };
            string text = Message.Text;
            string count = Count.Text;

            if (count == "" && text == "")
            {
                this.Height = 540;
                result.Text = "Nie wpisano żadnej informacji!";
                result.Foreground = brush;
                copyMessage.Visibility = Visibility.Collapsed;
                result.Visibility = Visibility.Visible;
            }
            else if (count == "")
            {
                this.Height = 540;
                result.Text = "Nie wpisano, o ile mają być przesunięte litery!";
                result.Foreground = brush;
                copyMessage.Visibility = Visibility.Collapsed;
                result.Visibility = Visibility.Visible;
            }
            else if (text == "")
            {
                this.Height = 540;
                result.Text = "Nie wpisano wiadomości!";
                result.Foreground = brush;
                copyMessage.Visibility = Visibility.Collapsed;
                result.Visibility = Visibility.Visible;
            }
            else
            {
                this.Height = 540;
                string toDecode = CaesarDecode(text, letters, Convert.ToInt32(count));
                result.Visibility = Visibility.Collapsed;
                copyMessage.Visibility = Visibility.Visible;
                messageDecrypted = toDecode;
            }
        }



        private void exitApp(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }


        private void copyMessage_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(messageDecrypted);
        }


        private void menuOpen(object sender, RoutedEventArgs e)
        {
            this.Hide(); // Ukrywamy bieżące okno
            MainWindow mainForm = new MainWindow(); // Tworzymy obiekt klasy MainWindow (główne okno)
            mainForm.Show(); // Otwieramy główne okno
        }


        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }



        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                decodeBtn_Click(sender, e);
            }

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
            if (copyMessage.Visibility == Visibility.Visible)
            {
                copyMessage.Visibility = Visibility.Collapsed;
                this.Height = 460;
            }
        }


        private void Message_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (copyMessage.Visibility == Visibility.Visible)
            {
                copyMessage.Visibility = Visibility.Collapsed;
                this.Height = 460;
            }
        }
    }
}
