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
using System.Security.Cryptography; //CryptoStream
using System.IO; //MemoryStream
using MaterialDesignColors;


namespace SafeCenter
{
    /// <summary>
    /// Logika interakcji dla klasy IncodeSecret.xaml
    /// </summary>
    /// 

    public partial class IncodeUltra: Window
    {

        public IncodeUltra()
        {
            InitializeComponent();
        }


         private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }





        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            DragMove();
        }



        private void menuOpen(object sender, RoutedEventArgs e)
        {
            this.Hide(); // Ukrywamy bieżące okno
            MainWindow mainForm = new(); // Tworzymy obiekt klasy MainWindow (główne okno)
            mainForm.Show(); // Otwieramy główne okno
        }





        static string KeyGenerator(int length)
        {

            // Lista znaków, z których ma być generowany klucz
            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789|@#%$&*^?.";

            // Generator liczb pseudolosowych
            Random random = new Random();

            // Generowanie klucza
            string key = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return key;
        }



        // Metoda służy do szyfrowania tekstu przy użyciu algorytmu DES z kluczem prywatnym i publicznym.
        // Przyjmuje trzy parametry: publickey - klucz publiczny, privatekey - klucz prywatny, textToEncrypt - tekst do zaszyfrowania.
        // Zwraca zaszyfrowany tekst w postaci ciągu znaków.
        public static string Encrypt(string publickey, string privatekey, string textToEncrypt)
        {
            try
            {
                string ToReturn = "";
                byte[] secretkeyByte = { };
                secretkeyByte = Encoding.UTF8.GetBytes(privatekey); // Konwertuje klucz prywatny na ciąg bajtów.
                byte[] publickeybyte = { };
                publickeybyte = Encoding.UTF8.GetBytes(publickey); // Konwertuje klucz publiczny na ciąg bajtów.
                MemoryStream ms;
                CryptoStream cs;
                byte[] inputbyteArray = Encoding.UTF8.GetBytes(textToEncrypt); // Konwertuje tekst do zaszyfrowania na ciąg bajtów.
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length); // Zapisuje zaszyfrowany tekst do strumienia.
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray()); // Konwertuje zaszyfrowany tekst na ciąg znaków w formacie Base64.
                }
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }



        



        private void incodeBtn_Click(object sender, RoutedEventArgs e)
        {

            
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff5050"));

            string text = Message.Text;
            string publickey = Publickey.Text;
            string privatekey = Privatekey.Text;


            if (text == "")
            {
                this.Height = 830;
                result.Foreground = brush;
                result.Text = "Nie wpisano wiadomości!";
            }

            else if(publickey.Length != 8 || privatekey.Length != 8)
            {
                this.Height = 830;
                result.Foreground = brush;
                result.Text = "Klucze nie mają 8 znaków!";
            }

            else if(publickey.Length != 8 && text == "" && privatekey.Length != 8)
            {
                this.Height = 830;
                result.Foreground = brush;
                result.Text = "Nie podano wszystkich informacji!";
            }

            else
            {
                string encrypted = Encrypt(publickey, privatekey, text);
                Encrypted.Text = encrypted;
                this.Height = 790;
                result.Text = "";
            }
        }


        

    

        private void keyGenerator_Click(object sender, RoutedEventArgs e)
        {
            Publickey.Text = KeyGenerator(8);
            Privatekey.Text = KeyGenerator(8);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                incodeBtn_Click(sender, e);
            }

        }

        private void Copy1_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(Publickey.Text);
        }

        private void Copy2_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(Privatekey.Text);
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

        private void Publickey_GotFocus(object sender, RoutedEventArgs e)
        {
            // Utworzenie nowego obiektu SolidColorBrush o kolorze #4caf50
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4caf50"));

            // Ustawienie koloru ramki TextBoxa na brush
            Publickey.BorderBrush = brush;
        }


        private void Publickey_LostFocus(object sender, RoutedEventArgs e)
        {
            // Utworzenie nowego obiektu SolidColorBrush o kolorze #FFC0BBBB
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC0BBBB"));

            // Ustawienie koloru ramki TextBoxa na brush
            Publickey.BorderBrush = brush;
        }

        private void Privatekey_GotFocus(object sender, RoutedEventArgs e)
        {
            // Utworzenie nowego obiektu SolidColorBrush o kolorze #4caf50
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4caf50"));

            // Ustawienie koloru ramki TextBoxa na brush
            Privatekey.BorderBrush = brush;
        }

        private void Privatekey_LostFocus(object sender, RoutedEventArgs e)
        {
            // Utworzenie nowego obiektu SolidColorBrush o kolorze #FFC0BBBB
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC0BBBB"));

            // Ustawienie koloru ramki TextBoxa na brush
            Privatekey.BorderBrush = brush;
        }

        private void Message_TextChanged(object sender, TextChangedEventArgs e)
        {
            Encrypted.Text = "";
        }

        private void Publickey_TextChanged(object sender, TextChangedEventArgs e)
        {
            Encrypted.Text = "";
        }

        private void Privatekey_TextChanged(object sender, TextChangedEventArgs e)
        {
            Encrypted.Text = "";
        }
    }
}
