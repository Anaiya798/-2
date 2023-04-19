using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Mocks
{
    public class MockCategory : IReagentsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category {Name = "Неорганическая химия"},
                    new Category {Name = "Органическая химия"}
                };
            }
        }
    }
}
