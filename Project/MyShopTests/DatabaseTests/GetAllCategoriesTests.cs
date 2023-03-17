using Shop.Database;
using Shop.Models;

namespace MyShopTests.DatabaseTests
{
    [TestFixture]
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
                new Category() {Name = "Inorganic chemistry", Desc=""},
                new Category() {Name = "Organic chemistry", Desc = ""},
                new Category() {Name = "Biologically active compounds", Desc = ""},
             };

            _categoryRepository = new CategoryRepository(_dbStub);
        }

        [Test]
        public void EmptyDbTest()
        {
            var allCategories = _categoryRepository.AllCategories.ToList();
            Assert.That(allCategories.Count, Is.EqualTo(0));
        }

        [Test]
        public void FilledDbTest()
        {
            _categoryRepository.AppDbContent.Category.AddRange(_categories);
            _categoryRepository.AppDbContent.SaveChanges();

            var allCategories = _categoryRepository.AllCategories.ToList();
            Assert.IsTrue(allCategories.Contains(_categories[0])) ;
            Assert.IsTrue(allCategories.Contains(_categories[1]));
            Assert.IsTrue(allCategories.Contains(_categories[2]));
            Assert.That(allCategories.Count, Is.EqualTo(3));
        }
    }

}
