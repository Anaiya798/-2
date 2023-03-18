using Shop.Database;
using Shop.Models;

namespace MyShopTests.DatabaseTests
{
    [TestFixture]
    public class GetAllReagentsTests
    {
        private AppDBContent _dbStub;
        private ReagentsRepositiry _reagentsRepository;
        private List<Reagent> _reagents;

        [SetUp]
        public void Setup()
        {
            _dbStub = new AppDBContent();

            _reagents = new List<Reagent>() {
                new Reagent() {Name = "Formic acid" , Category = 1, IsFavourite = false},
                new Reagent() { Name = "Ethanol", Category = 1, IsFavourite = true},
                new Reagent() { Name = "Distilled water", Category = 2, IsFavourite = true},
                new Reagent() { Name = "DNA", Category = 3, IsFavourite = false},

             };
            _reagentsRepository = new ReagentsRepositiry(_dbStub);
        }

        [Test]
        public void EmptyDbTest()
        { 
            var allReagents = _reagentsRepository.Reagents.ToList();
            Assert.That(allReagents.Count, Is.EqualTo(0));
        }

        [Test]
        public void FilledDbTest()
        {
           _reagentsRepository.AppDbContent.Reagent.AddRange(_reagents);
           _reagentsRepository.AppDbContent.SaveChanges();

            var allReagents = _reagentsRepository.Reagents.ToList();
            Assert.IsTrue(allReagents.Contains(_reagents[0]));
            Assert.IsTrue(allReagents.Contains(_reagents[1]));
            Assert.IsTrue(allReagents.Contains(_reagents[2]));
            Assert.IsTrue(allReagents.Contains(_reagents[3]));
            Assert.That(allReagents.Count, Is.EqualTo(4));
        }


    }
}
