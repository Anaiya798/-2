 class DataDescription
 {
        private string _name, _date, _age;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Age
        {
            get { return _age; }
            set { _age = value; }
        }
 }
 class DataOrg
 {
        private string _name;
        private int _age, _score;

        internal int NameLen { get; private set; }


        const double AGE_PROPORTIONALITY_COEFFICIENT = 0.83;
        const int NAME_LENGTH_GROWTH = 4;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public DataDescription GetDescription()
        {
            if (Name != null)
            {
                DataDescription row = new DataDescription();
                row.Name = Name;
                row.Age = $"{age * AGE_PROPORTIONALITY_COEFFICIENT}";
                row.Date = DateTime.Now.ToString();
                return row;
            }
            return null;
        }

        protected bool PossibleToCalcNamelen()
        {
            return Name.Length >= 3 && Age >= 18 && Age <= 65 && Score != -1;
        }

        public int CalcNamlen()
        {
            if (name == null)
            {
                return -1;
            }
            else
            {
                if (PossibleToCalcNamelen())
                {
                    NameLen = name.Length * NAME_LENGTH_GROWTH;
                }
                
                return 0;
            }
        }

        public void SetAge(int arg)
        {
            Age = arg;
        }

        public void SetScore(int arg)
        {
            Score = arg;
        }
}


