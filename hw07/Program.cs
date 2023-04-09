using System;
using System.Collections.Generic;

namespace EF
{

    class Program
    {
        public static void Main(string[] args)
        {
            Category category1 = new Category { Name = "Organic" };
            
            CategoryFunctions.AddCategory(category1);
            
            Console.Read();
        }
    }
}