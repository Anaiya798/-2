using Shop.Models;
using System.Collections.Generic;

namespace Shop.Data.Abstractions
{
    public abstract class ReagentsCategory
    {
        //вывод всех категорий товаров
        IEnumerable<Category> AllCategories { get; }
    }
   
}
