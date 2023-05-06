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
    /// Logika interakcji dla klasy Information.xaml
    /// </summary>
    public partial class Information : Window
    {
        public Information()
        {
            InitializeComponent();
        }

        private void into_Click(object sender, RoutedEventArgs e)
        {
            Hide(); // Ukrywamy bieżące okno
            MainWindow mainForm = new MainWindow(); // Tworzymy obiekt klasy MainWindow (główne okno)
            mainForm.Show(); // Otwieramy główne okno
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var greenPrimaryDictionary = new ResourceDictionary();
            greenPrimaryDictionary.Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Green.xaml");

            Application.Current.Resources.MergedDictionaries.Add(greenPrimaryDictionary);
        }

        
    }
    
}
