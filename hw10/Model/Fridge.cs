namespace WpfApp2
{
    public class Fridge: BaseProduct
    {
        private string _energy;
        public string Energy 
        {
            get { return _energy; }
            set
            {
                _energy = value;

            }
        }   
    }
}
