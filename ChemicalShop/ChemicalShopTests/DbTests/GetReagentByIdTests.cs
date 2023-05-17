using ChemicalShop.Data.Repository;
using Shop.Data.Models;

namespace ChemicalShopTests.DbTests
{
    [TestFixture]
    internal class GetReagentByIdTests
    {
        private MockDbContent _mockDbContent;
        private MockReagentsRepository _mockReagentsRepository;
        private List<Category> _categories;
        private List<Reagent> _reagents;

        [SetUp]
        public void Setup()
        {
            _mockDbContent = new MockDbContent();
            _mockReagentsRepository = new MockReagentsRepository(_mockDbContent);

            _categories = new List<Category>()
            {
                new Category { Name = "Органическая химия" },
            };
            _reagents = new List<Reagent>()
            {
                new Reagent { Name = "Муравьиная кислота", Category = _categories[0]},
                new Reagent { Name = "Этанол", Category = _categories[0]}
            };

        }

       [Test]
        public void NonExistentIdTest()
        {
            _mockDbContent.Category.AddRange(_categories);
            _mockDbContent.SaveChanges();

            _mockDbContent.Reagent.Add(_reagents[0]);
            _mockDbContent.SaveChanges();

            var desiredReagent = _mockReagentsRepository.getObjectReagent(0);
            Assert.Null(desiredReagent);


            desiredReagent = _mockReagentsRepository.getObjectReagent(-100);
            Assert.Null(desiredReagent);

            _mockDbContent.Reagent.Remove(_reagents[0]);
            _mockDbContent.Category.RemoveRange(_categories);
            _mockDbContent.SaveChanges();

        }

        [Test]
        public void CorrectIdTest()
        {
            _mockDbContent.Category.AddRange(_categories);
            _mockDbContent.SaveChanges();

            _mockDbContent.Reagent.AddRange(_reagents);
            _mockDbContent.SaveChanges();

            int reagentId1 = _mockReagentsRepository.Reagents.FirstOrDefault(reg => reg.Name == _reagents[0].Name).Id;
            int reagentId2 = _mockReagentsRepository.Reagents.FirstOrDefault(reg => reg.Name == _reagents[1].Name).Id;

            var desiredReagent = _mockReagentsRepository.getObjectReagent(reagentId1);
            Assert.That(desiredReagent.Name, Is.EqualTo(_reagents[0].Name));

            desiredReagent = _mockReagentsRepository.getObjectReagent(reagentId2);
            Assert.That(desiredReagent.Name, Is.EqualTo(_reagents[1].Name));
           

            _mockDbContent.Reagent.RemoveRange(_reagents);
            _mockDbContent.Category.RemoveRange(_categories);
            _mockDbContent.SaveChanges();
        }
    }
}
