using System.Windows.Controls;
using WpfApp2;

namespace ApplicationNavigation.View
{
    public partial class TVs : Page
    {
        public TVs()
        {
            InitializeComponent();
            DataContext = new TVsViewModel();
        }
    }
}
