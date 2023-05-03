namespace WpfApp2
{
    public class Microwave: BaseProduct
    {
        private string _heating;

        public string Heating
        {
            get { return _heating; }
            set
            {
                _heating = value;

            }
        }
    }
}
