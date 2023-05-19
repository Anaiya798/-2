using ChemicalShop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace ChemicalShopTests.DbTests
{
    class MockCategoryRepository: IReagentsCategory
    {
        private readonly MockDbContent _mockDbContent;

        public MockCategoryRepository(MockDbContent mockDbContent)
        {
            _mockDbContent = mockDbContent;
        }
        public IEnumerable<Category> AllCategories => _mockDbContent.Category;
    }
}
