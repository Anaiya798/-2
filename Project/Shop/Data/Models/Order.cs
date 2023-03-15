namespace Shop.Data.Models
{
    public class Order
    {
        //класс, описывающий заказ покупателя (сведения о самом покупателе)
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }
        //...
    }
}
