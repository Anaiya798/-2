using System.Windows.Controls;
using WpfApp2;

namespace ApplicationNavigation.View
{
    public partial class Microwaves : Page
    {
        public Microwaves()
        {
            InitializeComponent();
            DataContext = new MicrowavesViewModel();
        }
    }
}
