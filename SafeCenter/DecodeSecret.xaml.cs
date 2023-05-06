using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
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
    /// Logika interakcji dla klasy DecodeSecret.xaml
    /// </summary>
    public partial class DecodeSecret : Window
    {
        public DecodeSecret()
        {
            InitializeComponent();
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




        private void menuOpen(object sender, RoutedEventArgs e)
        {
            this.Hide(); // Ukrywamy bieżące okno
            SecretWindow mainForm = new(); // Tworzymy obiekt klasy MainWindow (główne okno)
            mainForm.Show(); // Otwieramy główne okno
        }



        public static string Decrypt(string publickey, string privatekey, string textToDecrypt)
        {
            try
            {
                // Tworzy pusty łańcuch znakowy, w którym zostanie przechowywany odszyfrowany tekst.
                string ToReturn = "";
                // Tworzy tablicę bajtów na podstawie klucza prywatnego i publicznego.
                byte[] privatekeyByte = { };
                privatekeyByte = Encoding.UTF8.GetBytes(privatekey);
                byte[] publickeybyte = { };
                publickeybyte = Encoding.UTF8.GetBytes(publickey);

                // Tworzy obiekt MemoryStream i CryptoStream.
                // CryptoStream służy do przekazywania bajtów do i z algorytmu kryptograficznego.
                MemoryStream ms;
                CryptoStream cs;

                // Tworzy tablicę bajtów wejściowych na podstawie tekstu do odszyfrowania i konwertuje ją z base64.
                byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));


                // Tworzy obiekt DESCryptoServiceProvider i zapisuje w nim algorytm DES.
                // Następnie tworzy obiekt CryptoStream z użyciem MemoryStream i CreateDecryptor.
                // CreateDecryptor jest używany do zdeszyfrowania tekstu.
                // Na koniec konwertuje odszyfrowany tekst z tablicy bajtów na łańcuch znakowy.
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    ToReturn = encoding.GetString(ms.ToArray());
                }

                // Zwraca odszyfrowany tekst.
                return ToReturn;
            }
            catch (Exception ae)
            {
               return ae.Message;
            }
        }


        string messageEncrypted = "";

        private void decodeBtn_Click(object sender, RoutedEventArgs e)
        {

            // Utworzenie nowego obiektu SolidColorBrush o kolorze #4caf50
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff5050"));


            string text = Message.Text;
            string publickey = Publickey.Text;
            string privatekey = Privatekey.Text;


            if (text == "")
            {
                this.Height = 570;
                result.Foreground = brush;
                result.Text = "Nie wpisano wiadomości!";
                copyMessage.Visibility = Visibility.Collapsed;
                result.Visibility = Visibility.Visible;
            }
            else if (publickey.Length != 8 || privatekey.Length != 8)
            {
                this.Height = 570;
                result.Foreground = brush;
                result.Text = "Klucze nie mają 8 znaków!";
                copyMessage.Visibility = Visibility.Collapsed;
                result.Visibility = Visibility.Visible;
            }
            else if (publickey.Length != 8 && text == "" && privatekey.Length != 8)
            {
                this.Height = 570;
                result.Foreground = brush;
                result.Text = "Nie podano wszystkich informacji!";
                copyMessage.Visibility = Visibility.Collapsed;
                result.Visibility = Visibility.Visible;
            }
            else
            {
                result.Foreground = new SolidColorBrush(Colors.White);
                string decrypted = Decrypt(publickey, privatekey, text);


                if (decrypted == "Padding is invalid and cannot be removed.")
                {
                    this.Height = 570;
                    result.Foreground = brush;
                    decrypted = "Wprowadzono zły klucz publiczny!";
                    result.Text = decrypted;
                    copyMessage.Visibility = Visibility.Collapsed;
                    result.Visibility = Visibility.Visible;
                }
                else if(decrypted == "The input is not a valid Base-64 string as it contains a non-base 64 character, more than two padding characters, or an illegal character among the padding characters." || decrypted == "The input data is not a complete block.")
                {
                    this.Height = 580;
                    result.Foreground = brush;
                    decrypted = "Wiadomość nie jest w odpowiednim formacie!";
                    result.Text = decrypted;
                    copyMessage.Visibility = Visibility.Collapsed;
                    result.Visibility = Visibility.Visible;
                }
                else
                {
                    result.Foreground = new SolidColorBrush(Colors.White);
                    copyMessage.Visibility = Visibility.Visible;
                    result.Visibility = Visibility.Collapsed;
                    messageEncrypted = decrypted;
                    this.Height = 610;
                }

                
            }
        }


        private void copyMessage_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(messageEncrypted);
        }


        private void result_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(result.Text);
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
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff5050"));

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
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff5050"));

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
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff5050"));

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
            if (copyMessage.Visibility == Visibility.Visible)
            {
                copyMessage.Visibility = Visibility.Collapsed;
                this.Height = 530;
            }
        }


        private void Publickey_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (copyMessage.Visibility == Visibility.Visible)
            {
                copyMessage.Visibility = Visibility.Collapsed;
                this.Height = 530;
            }
        }


        private void Privatekey_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (copyMessage.Visibility == Visibility.Visible)
            {
                copyMessage.Visibility = Visibility.Collapsed;
                this.Height = 530;
            }
        }
    }
}
