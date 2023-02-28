   public class GameMethods
    {
        private string _name;
        private int _price;
        private int _amount;
        private string _platform;

        const double DISCOUNT = 0.8;
        const double AMOUNT_DECREASE_COEFFICIENT = 0.956;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        int Price => _price;
        int Amount => _amount;
        string Platform => _platform;

        public void PrintDetails()
        {
            Console.WriteLine("name: " + Name);
            Console.WriteLine("amount: " + Amount);
            Console.WriteLine("price: " + Price);
            Console.WriteLine("platform: " + Platform);
        }

        public void PrintPack()
        {
            this.PrintBanner();
            this.PrintDetails();
            
        }
        float getAmount()
        {
            bool isPC = Platform.ToUpper().IndexOf("PC") > -1;
            bool isXX = Name.ToUpper().IndexOf("XX") > -1;
            bool positiveAmount = Amount > 0;

            if ((isPC) && (isXX) && positiveAmount)
                return Amount * AMOUNT_DECREASE_COEFFICIENT;

            double bill = Amount * price;
            Console.WriteLine(bill);
            double discountBill = DISCOUNT * Amount * price;
            Console.WriteLine(discountBill);

            return -1;
        }
    }


