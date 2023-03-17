using Shop.Database;
using Shop.Models;

namespace MyShopTests.DatabaseTests
{
    public class GetAllCategoriesTests
    {
        private AppDBContent _dbStub;
        private CategoryRepository _categoryRepository;
        private List<Category> _categories;

        [SetUp]
        public void Setup()
        {
            _dbStub = new AppDBContent();

            _categories = new List<Category>() {
                new Category() { Id = 1, Name = "Inorganic chemistry", Desc=""},
                new Category() { Id = 2, Name = "Organic chemistry", Desc = ""},
                new Category() { Id = 3, Name = "Biologically active compounds", Desc = ""},
             };
        }

        [Test]
        public void EmptyDbTest()
        {

            _categoryRepository = new CategoryRepository(_dbStub);

            var allCategories = _categoryRepository.AllCategories.ToList();
            Assert.That(allCategories.Count, Is.EqualTo(0));
        }

        [Test]
        public void FilledDbTest()
        {
            _dbStub.Category.AddRange(_categories);
            _dbStub.SaveChanges();

            _categoryRepository = new CategoryRepository(_dbStub);

            var allCategories = _categoryRepository.AllCategories.ToList();
            Assert.IsTrue(allCategories.Contains(_categories[0])) ;
            Assert.IsTrue(allCategories.Contains(_categories[1]));
            Assert.IsTrue(allCategories.Contains(_categories[2]));
            Assert.That(allCategories.Count, Is.EqualTo(3));
        }
    }

}
