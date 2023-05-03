namespace WpfApp2
{
    public class TV: BaseProduct
    {
       
        private string _size;

        public string Size
        {
            get { return _size; }
            set
            {
                _size = value;
            }
        }
    }
}
