using Shop.Database;
using Shop.Models;

namespace MyShopTests.DatabaseTests
{
    internal class GetAllReagentsTests
    {
        private AppDBContent _dbStub;
        private ReagentsRepositiry _reagentsRepository;
        private List<Reagent> _reagents;

        [SetUp]
        public void Setup()
        {
            _dbStub = new AppDBContent();

            _reagents = new List<Reagent>() {
                new Reagent() { Id = 1, Name = "Formic acid" , Category = 1, IsFavourite = false},
                new Reagent() { Id = 2, Name = "Ethanol", Category = 1, IsFavourite = true},
                new Reagent() { Id = 3, Name = "Distilled water", Category = 2, IsFavourite = true},
                new Reagent() { Id = 4, Name = "DNA", Category = 3, IsFavourite = false},

             };
        }

        [Test]
        public void EmptyDbTest()
        {
            _reagentsRepository = new ReagentsRepositiry(_dbStub);

            var allReagents = _reagentsRepository.Reagents.ToList();
            Assert.That(allReagents.Count, Is.EqualTo(0));
        }

        [Test]
        public void FilledDbTest()
        {
            _dbStub.Reagent.AddRange(_reagents);
            _dbStub.SaveChanges();

            _reagentsRepository = new ReagentsRepositiry(_dbStub);

            var allReagents = _reagentsRepository.Reagents.ToList();
            Assert.IsTrue(allReagents.Contains(_reagents[0]));
            Assert.IsTrue(allReagents.Contains(_reagents[1]));
            Assert.IsTrue(allReagents.Contains(_reagents[2]));
            Assert.IsTrue(allReagents.Contains(_reagents[3]));
            Assert.That(allReagents.Count, Is.EqualTo(4));
        }


    }
}
