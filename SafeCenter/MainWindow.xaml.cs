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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using System.Windows.Media.Animation;

namespace SafeCenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Incode window1;
        private Decode window2;
        private RandomPassword window3;
        private Login window4;
        private PasswordChecker window5;


        public MainWindow()
        {
            InitializeComponent();
            window1 = new Incode();
            window2 = new Decode();
            window3 = new RandomPassword();
            window4 = new Login();
            window5 = new PasswordChecker();
        }



        private void exitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }



        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            DragMove();
        }



        private void incodeBtn_Click(object sender, RoutedEventArgs e)
        {
            window1.Show();
            this.Hide();
        }



        private void decodeBtn_Click(object sender, RoutedEventArgs e)
        {
            window2.Show();
            this.Hide();
        }




        private void passBtn_Click(object sender, RoutedEventArgs e)
        {
            window3.Show();
            this.Hide();
        }



        private void passcheckBtn_Click(object sender, RoutedEventArgs e)
        {
            window5.Show();
            this.Hide();
        }



        private void secretCode(object sender, RoutedEventArgs e)
        {
            window4.Show();
            this.Hide();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var greenPrimaryDictionary = new ResourceDictionary();
            greenPrimaryDictionary.Source = new Uri("pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Green.xaml");

            Application.Current.Resources.MergedDictionaries.Add(greenPrimaryDictionary);
        }
    }
}
