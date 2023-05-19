using Shop.Data.Models;
using System.IO;

namespace ChemicalShopTests.DbTests
{
    [TestFixture]
    internal class GetFavReagentsTests
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
                new Reagent { Name = "Муравьиная кислота", Category = _stubCategories[0], isFavourite = false},
                new Reagent { Name = "Этанол", Category = _stubCategories[0], isFavourite = true},
                new Reagent { Name = "ДНК", Category = _stubCategories[1], isFavourite = true}
            };
           

        }

        [Test]
        public void EmptyDbTest()
        {
            var favReagents = _mockReagentsRepository.FavReagents.ToList();
            Assert.That(favReagents.Count, Is.EqualTo(0));
        }

        [Test]
        public void NoFavReagentsTest()
        {
            _mockDbContent.Category.AddRange(_stubCategories);
            _mockDbContent.SaveChanges();

            _mockDbContent.Reagent.Add(_reagents[0]);
            _mockDbContent.SaveChanges();

            var favReagents = _mockReagentsRepository.FavReagents.ToList();
            Assert.That(favReagents.Count, Is.EqualTo(0));

            _mockDbContent.Reagent.Remove(_reagents[0]);
            _mockDbContent.Category.RemoveRange(_stubCategories);
            _mockDbContent.SaveChanges();
        }

        [Test]
        public void MixedReagentsTest()
        {
            _mockDbContent.Category.AddRange(_stubCategories);
            _mockDbContent.SaveChanges();

            _mockDbContent.Reagent.AddRange(_reagents);
            _mockDbContent.SaveChanges(); 

            var favReagents = _mockReagentsRepository.FavReagents.ToList();
            Assert.IsTrue(favReagents.Contains(_reagents[1]));
            Assert.IsTrue(favReagents.Contains(_reagents[2]));
            Assert.That(favReagents.Count, Is.EqualTo(2));

            _mockDbContent.Reagent.RemoveRange(_reagents);
            _mockDbContent.Category.RemoveRange(_stubCategories);
            _mockDbContent.SaveChanges();
        }

        [Test]
        public void AllFavReagentsTest()
        {
            _mockDbContent.Category.AddRange(_stubCategories);
            _mockDbContent.SaveChanges();

            _mockDbContent.Reagent.Add(_reagents[1]);
            _mockDbContent.Reagent.Add(_reagents[2]);
            _mockDbContent.SaveChanges();

            var favReagents = _mockReagentsRepository.FavReagents.ToList();
            Assert.IsTrue(favReagents.Contains(_reagents[1]));
            Assert.IsTrue(favReagents.Contains(_reagents[2]));
            Assert.That(favReagents.Count, Is.EqualTo(2));

            _mockDbContent.Reagent.Remove(_reagents[1]);
            _mockDbContent.Reagent.Remove(_reagents[2]);
            _mockDbContent.Category.RemoveRange(_stubCategories);
            _mockDbContent.SaveChanges();
        }


    }
}
