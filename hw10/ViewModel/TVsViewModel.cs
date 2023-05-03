using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace WpfApp2
{
    public class TVsViewModel: INotifyPropertyChanged
    {
        private TV _selectedTV;

        public ObservableCollection<TV> TVs { get; set; }
        public TV SelectedTV
        {
            get { return _selectedTV; }
            set
            {
                _selectedTV = value;
                OnPropertyChanged("SelectedTV");
            }
        }

        public TVsViewModel()
        {
            TVs = new ObservableCollection<TV>
            {
                new TV { Title="Philips Smart TV", Size="1200x900", Price=70000, Img="Imgs/philipsSmart.jpg"},
                new TV {Title="Philips 58PUS", Size="1150x800", Price=60000, Img="Imgs/philips58.jpg" },
                new TV {Title="Philips 43PUS", Size="1100x850", Price=55000, Img="Imgs/philips43.jpg" },
                new TV {Title="Philips 65PUS", Size="1200x1100", Price=80000, Img="Imgs/philips65.jpg" }
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

