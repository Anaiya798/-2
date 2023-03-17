using Shop.Data.Abstractions;
using Shop.Models;
using System.Collections.Generic;

namespace Shop.Database
{
    public class CategoryRepository : ReagentsCategory
    {
        //получение данных о категориях товаров из базы
        private readonly AppDBContent appDbContent;

        public CategoryRepository(AppDBContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<Category> AllCategories => appDbContent.Category;

    }
}
