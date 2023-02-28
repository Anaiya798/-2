    class Weapon
    {
        private int _damagePower;

        int DamagePower => _damagePower; 
        public int WeaponStatus
        { get; set; }

        public int GetDamagePower()
        {
            return DamagePower;
        }

    }
    class Fighter
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Health
        { get; set; }
        public int Damage
        { get; set; }

        public Weapon Weapon
        { get; set;}
        
       
        void LogStatus(string name, int age, int health, int damage, int weaponStatus)
        {
            Console.WriteLine($"name:{name}, age:{age}, health:{health}, damage:{damage},weaponStatus:{weaponStatus}");
        }
        
        void Attack()
        {
            Console.WriteLine("Go Attack!");
            // TO DO: implement attack
        }
        public void TryAttack()
        {
            try
            {
                Attack();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Go Attack Exception: {e}");
                throw e;
            }
        }
    }

    



