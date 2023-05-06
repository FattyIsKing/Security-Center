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

using System.Collections;

using System.IO;

using System.Security.Cryptography;

using System.Threading;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;


namespace SafeCenter
{
    /// <summary>
    /// Logika interakcji dla klasy Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {

        


        public Registration()
        {
            InitializeComponent();
            
        }





        private void login_GotFocus(object sender, RoutedEventArgs e)
        {
            // Utworzenie nowego obiektu SolidColorBrush o kolorze #4caf50
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4caf50"));

            // Ustawienie koloru ramki TextBoxa na brush
            login.BorderBrush = brush;
        }

        private void login_LostFocus(object sender, RoutedEventArgs e)
        {
            // Utworzenie nowego obiektu SolidColorBrush o kolorze #FFC0BBBB
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC0BBBB"));

            // Ustawienie koloru ramki TextBoxa na brush
            login.BorderBrush = brush;
        }



        private void password_GotFocus(object sender, RoutedEventArgs e)
        {
            // Utworzenie nowego obiektu SolidColorBrush o kolorze #4caf50
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4caf50"));

            // Ustawienie koloru ramki TextBoxa na brush
            password.BorderBrush = brush;
        }


        private void password_LostFocus(object sender, RoutedEventArgs e)
        {
            // Utworzenie nowego obiektu SolidColorBrush o kolorze #FFC0BBBB
            SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC0BBBB"));

            // Ustawienie koloru ramki TextBoxa na brush
            password.BorderBrush = brush;
        }



        private void register_Click(object sender, RoutedEventArgs e)
        {
            //ścieżka folderu dokumenty
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //nazwa pliku
            string fileName = "users.txt";

            //ścieżka folderu, który tworzymy
            string folderPath = System.IO.Path.Combine(desktopPath, "Safe Center Premium Users");

            //pełna ścieżka pliku z cytatami
            string filePath = System.IO.Path.Combine(folderPath, fileName);

            this.Height = 560;

            if (password.Text == "" && login.Text == "")
            {
                result.Text = "Nie podano żadnych informacji!";
            }
            else if(password.Text == "")
            {
                result.Text = "Nie podano hasła!";
            }
            else if(login.Text == "")
            {
                result.Text = "Nie podano loginu!";
            }
            else
            {

                int checker = 0;
                string[] lines = File.ReadAllLines(filePath);
                List<string> users = new List<string>();


                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] == "" || lines[i] is null)
                    {
                        continue;
                    }
                    else
                    {
                        users.Add(lines[i]);
                    }
                }

                for (int i = 0; i < users.Count; i++)
                {
                    char separator = '_';


                    string[] parts = users[i].Split(separator);


                    string textBeforeSeparator = parts[0];
                    

                    if(login.Text == textBeforeSeparator)
                    {
                        checker++;
                    }


                }


                if(checker > 0)
                {
                    result.Text = "Taki użytkownik już istnieje!";
                }


                else
                {
                    if (!File.Exists(filePath))
                    {
                        noteCreate(folderPath, filePath);
                        noteAppend(filePath, $"{login.Text}_{password.Text}");
                    }
                    else
                    {
                        noteAppend(filePath, $"{login.Text}_{password.Text}");
                    }

                    result.Text = "Zarejestrowano pomyślnie!";
                }


            }
        }




        //funkcja tworząca plik z cytatami
        static void noteCreate(string folderPath, string filePath)
        {

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                File.WriteAllText(filePath, "");
            }
            else
            {
                File.WriteAllText(filePath, "");
            }
        }




        //funkcja nadpisująca plik z cytatami w przypadku istnienia takiego pliku
        static void noteAppend(string filePath, string receivedText)
        {
            string textToFile = receivedText + Environment.NewLine;

            File.AppendAllText(filePath, textToFile);
        }


        private void menuOpen(object sender, RoutedEventArgs e)
        {
            this.Hide(); // Ukrywamy bieżące okno
            MainWindow mainForm = new MainWindow(); // Tworzymy obiekt klasy MainWindow (główne okno)
            mainForm.Show(); // Otwieramy główne okno
        }



        private void exitApp(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                register_Click(sender, e);
            }
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            this.Hide(); // Ukrywamy bieżące okno
            Login mainForm = new Login(); // Tworzymy obiekt klasy MainWindow (główne okno)
            mainForm.Show(); // Otwieramy główne okno
        }
    }
}
