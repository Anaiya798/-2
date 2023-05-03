using ApplicationNavigation.View;

using System.Windows;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Phones_Btn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new Phones());
        }

        private void TVs_Btn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new TVs());
        }

        private void Fridges_Btn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new Fridges());
        }

        private void Microwaves_Btn_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new Microwaves());
        }
    }
}
