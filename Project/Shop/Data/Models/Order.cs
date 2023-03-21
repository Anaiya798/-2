using Shop.Models;
using System;
using System.Collections.Generic;

namespace Shop.Data.Models
{
    public class Order
    {
        //класс, описывающий заказ покупателя (сведения о самом покупателе)
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }

       /* public override bool Equals(Object obj)
        {
            //сравниваем объекты заказы
        }*/

        //...
    }
}
