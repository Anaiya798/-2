using System;

namespace Shop.Models
{
    public class Category
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        public override bool Equals(Object obj)
        {
            //сравниваем категории
        }
    }
}
