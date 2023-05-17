using AngleSharp.Dom;
using ChemicalShop.Data.Repository;
using Shop.Data.Models;
namespace ChemicalShopTests.DbTests
{
    [TestFixture]
    internal class GetAllCategoriesTests
    {
        private MockDbContent _mockDbContent;
        private MockCategoryRepository _mockCategoryRepository;
        private List<Category> _categories; 
        
        [SetUp]
        public void Setup()
        {
            _mockDbContent = new MockDbContent();
            _mockCategoryRepository = new MockCategoryRepository(_mockDbContent);
            _categories = new List<Category>()
            {
                new Category { Name = "Неорганическая химия" },
                new Category { Name = "Редкие металлы"}
            };

        }
        [Test]
        public void EmptyDbTest()
        {
            var allDbCategories = _mockCategoryRepository.AllCategories.ToList();
            Assert.That(allDbCategories.Count, Is.EqualTo(0));
        }

        [Test]
        public void FilledDbTest()
        {
            _mockDbContent.Category.AddRange(_categories);
            _mockDbContent.SaveChanges();

            var allDbCategories = _mockCategoryRepository.AllCategories.ToList();
            Assert.IsTrue(allDbCategories.Contains(_categories[0]));
            Assert.IsTrue(allDbCategories.Contains(_categories[1]));
            Assert.That(allDbCategories.Count, Is.EqualTo(2));

            _mockDbContent.Category.RemoveRange(_categories);
            _mockDbContent.SaveChanges();
        }

    }
}
