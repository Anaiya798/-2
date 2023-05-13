using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;

namespace ChemicalShop.Data.Repository
{
    public class CategoryRepository : IReagentsCategory
    {
        private readonly AppDbContent _appDbContent;

        public CategoryRepository(AppDbContent appDbContent)
        {
            _appDbContent = appDbContent;
        }
        public IEnumerable<Category> AllCategories => _appDbContent.Category;
    }
}
