using ChemicalShop.Data.Repository;
using Shop.Data.Models;

namespace ChemicalShopTests.DbTests
{
    [TestFixture]
    internal class GetAllReagentsTests
    {
        private MockDbContent _mockDbContent;
        private MockReagentsRepository _mockReagentsRepository;
        private List<Category> _stubCategories;
        private List<Reagent> _reagents;


        [SetUp]
        public void Setup()
        {
            _mockDbContent = new MockDbContent();
            _mockReagentsRepository = new MockReagentsRepository(_mockDbContent);

            _stubCategories = new List<Category>()
            {
                new Category { Name = "Органическая химия" },
                new Category { Name = "БАВ"}
            };
           

            _reagents = new List<Reagent>()
            {
                new Reagent { Name = "Муравьиная кислота", Category = _stubCategories[0]},
                new Reagent { Name = "Этанол", Category = _stubCategories[0]},
                new Reagent { Name = "ДНК", Category = _stubCategories[1]}
            };
            
        }

        [Test]
        public void EmptyDbTest()
        {
            var allDbReagents = _mockReagentsRepository.Reagents.ToList();
            Assert.That(allDbReagents.Count, Is.EqualTo(0));
        }

       [Test]
        public void FilledDbTest()
        {
            _mockDbContent.Category.AddRange(_stubCategories);
            _mockDbContent.SaveChanges();
            

            _mockDbContent.Reagent.AddRange(_reagents);
            _mockDbContent.SaveChanges();

            var allDbReagents = _mockReagentsRepository.Reagents.ToList();
            Assert.IsTrue(allDbReagents.Contains(_reagents[0]));
            Assert.IsTrue(allDbReagents.Contains(_reagents[1]));
            Assert.IsTrue(allDbReagents.Contains(_reagents[2]));
            Assert.That(allDbReagents.Count, Is.EqualTo(3));

            _mockDbContent.Reagent.RemoveRange(_reagents);
            _mockDbContent.Category.RemoveRange(_stubCategories);
            _mockDbContent.SaveChanges();
        }

    }
}
