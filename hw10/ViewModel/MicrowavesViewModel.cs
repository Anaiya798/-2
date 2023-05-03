using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp2
{
    public class MicrowavesViewModel : INotifyPropertyChanged
    {
        private Microwave _selectedMicrowave;

        public ObservableCollection<Microwave> Microwaves { get; set; }
        public Microwave SelectedMicrowave
        {
            get { return _selectedMicrowave; }
            set
            {
                _selectedMicrowave = value;
                OnPropertyChanged("SelectedMicrowave");
            }
        }

        public MicrowavesViewModel()
        {
            Microwaves = new ObservableCollection<Microwave>
            {
                new Microwave {Title="Microwave Media", Heating="45-50", Price=5600, Img="Imgs/media.jpg"},
                new Microwave {Title="Microwave Ozon Micro", Heating="30-35", Price=3500, Img="Imgs/micro.jpg" },
                new Microwave {Title="Microwave Gorenje", Heating="60-65", Price=10000, Img="Imgs/gorenje.jpg" },
                new Microwave {Title="Elephant Bone Luxuary", Heating="55-60", Price=15000, Img="Imgs/elephantBone.jpg" }
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
