using Shop.Data.Abstractions;
using Shop.Models;
using System.Collections.Generic;

namespace Shop.Database
{
    public class CategoryRepository : ReagentsCategory
    {
        //получение данных о категориях товаров из базы
        private AppDBContent _appDbContent;

        public AppDBContent AppDbContent
        {
            get
            {
                return _appDbContent;
            }
            private set
            {
                _appDbContent = value;
            }
        }

        public CategoryRepository(AppDBContent appDbContent)
        {
            AppDbContent = appDbContent;
        }

        public IEnumerable<Category> AllCategories => AppDbContent.Category;

    }
}
