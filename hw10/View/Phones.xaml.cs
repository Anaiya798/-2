using System.Windows.Controls;
using WpfApp2;

namespace ApplicationNavigation.View
{
    public partial class Phones : Page
    {
        public Phones()
        {
            InitializeComponent();
            DataContext = new PhonesViewModel();
        }

    }
}
