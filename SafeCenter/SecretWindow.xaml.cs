using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SafeCenter
{
    /// <summary>
    /// Logika interakcji dla klasy SecretWindow.xaml
    /// </summary>
    public partial class SecretWindow : Window
    {

        private IncodeSecret window1;
        private DecodeSecret window2;
        

        public SecretWindow()
        {
            InitializeComponent();
            window1 = new IncodeSecret();
            window2 = new DecodeSecret();    
        }


        private void incodeBtn_Click(object sender, RoutedEventArgs e)
        {
            window1.Show();
            this.Close();
        }



        private void decodeBtn_Click(object sender, RoutedEventArgs e)
        {
            window2.Show();
            this.Close();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }


        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void menuOpen(object sender, RoutedEventArgs e)
        {
            this.Hide(); // Ukrywamy bieżące okno
            MainWindow mainForm = new(); // Tworzymy obiekt klasy MainWindow (główne okno)
            mainForm.Show(); // Otwieramy główne okno
        }

    


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var redPrimaryDictionary = new ResourceDictionary();
            redPrimaryDictionary.Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Red.xaml");

            Application.Current.Resources.MergedDictionaries.Add(redPrimaryDictionary);
        }

       
    }
}
