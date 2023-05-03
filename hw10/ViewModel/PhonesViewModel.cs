using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace WpfApp2
{
    public class PhonesViewModel : INotifyPropertyChanged
    {
        private Phone _selectedPhone;

        public ObservableCollection<Phone> Phones { get; set; }
        public Phone SelectedPhone
        {
            get { return _selectedPhone; }
            set
            {
                _selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public PhonesViewModel()
        {
            Phones = new ObservableCollection<Phone>
            {
                new Phone { Title="iPhone 7", Company="Apple", Price=56000, Img="Imgs/iphone7.jpg"},
                new Phone {Title="Galaxy S7 Edge", Company="Samsung", Price =60000, Img="Imgs/galaxy.jpg" },
                new Phone {Title="Elite x3", Company="HP", Price=56000, Img="Imgs/elitex3.jpg" },
                new Phone {Title="Mi5S", Company="Xiaomi", Price=35000, Img="Imgs/mi5s.jpg" }
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

