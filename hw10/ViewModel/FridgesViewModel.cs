using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp2
{
    public class FridgesViewModel: INotifyPropertyChanged
    {
        private Fridge _selectedFridge;

        public ObservableCollection<Fridge> Fridges { get; set; }
        public Fridge SelectedFridge
        {
            get { return _selectedFridge; }
            set
            {
                _selectedFridge = value;
                OnPropertyChanged("SelectedFridge");
            }
        }

        public FridgesViewModel()
        {
            Fridges = new ObservableCollection<Fridge>
            {
                new Fridge {Title="Bosh KGN39", Energy="A+", Price=80000, Img="Imgs/bosh39.jpg"},
                new Fridge {Title="Bosh KGN40", Energy="A+", Price=90000, Img="Imgs/bosh40.jpg" },
                new Fridge {Title="Bosh KGN36", Energy="B", Price=60000, Img="Imgs/bosh36.jpg" },
                new Fridge {Title="Bosh KGN76", Energy="A", Price=75000, Img="Imgs/bosh76.jpg" }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
