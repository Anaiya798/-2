using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    public interface IReagentsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
