using System;
namespace Shop.Models
{
    public class Reagent
    {
        //класс, описывающий реактивы
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint Price { get; set; }
        public ushort Category { get; set; }
        public string Danger { get; set; }
        public string Purity { get; set; }
        public bool IsFavourite { get; set; }
        public string Img { get; set; }

        /*public override bool Equals(Object obj)
        {
            //сравниваем реагенты
        }*/
    }
}
