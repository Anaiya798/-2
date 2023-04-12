using System;
using System.Linq;

namespace dbfirst
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new OrdersEntities())
            {

                foreach (var product in db.Product)
                {
                    Console.WriteLine(product.Name);
                }

            }
            Console.Read();

        }

    }
}
