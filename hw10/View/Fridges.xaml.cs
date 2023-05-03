using System.Windows.Controls;
using WpfApp2;

namespace ApplicationNavigation.View
{
    public partial class Fridges : Page
    {
        public Fridges()
        {
            InitializeComponent();
            DataContext = new FridgesViewModel();
        }
    }
}
