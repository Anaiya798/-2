using Shop.Database;
using Shop.Models;

namespace MyShopTests.DatabaseTests
{
    [TestFixture]
    public class GetFavouriteReagentsTests
    {
        private AppDBContent _dbStub;
        private ReagentsRepositiry _reagentsRepository;
        private List<Reagent> _reagents;

        [SetUp]
        public void Setup()
        {
            _dbStub = new AppDBContent();

            _reagents = new List<Reagent>() {
                new Reagent() { Name = "Formic acid" , IsFavourite = false},
                new Reagent() { Name = "Ethanol", IsFavourite = true},
                new Reagent() { Name = "Distilled water", IsFavourite = true},

             };

            _reagentsRepository = new ReagentsRepositiry(_dbStub);
        }

        [Test]
        public void MixedReagentsTest()
        {
            _reagentsRepository.AppDbContent.Reagent.AddRange(_reagents);
            _reagentsRepository.AppDbContent.SaveChanges();

            var favReagents = _reagentsRepository.FavReagents.ToList();
            Assert.IsTrue(favReagents.Contains(_reagents[1]));
            Assert.IsTrue(favReagents.Contains(_reagents[2]));
            Assert.That(favReagents.Count, Is.EqualTo(2));    
        }

        [Test]
        public void AllFavReagentsTest()
        {
            _reagentsRepository.AppDbContent.Reagent.Remove(_reagents[0]);
            _reagentsRepository.AppDbContent.SaveChanges();

            _reagentsRepository = new ReagentsRepositiry(_dbStub);

            var favReagents = _reagentsRepository.FavReagents.ToList();
            Assert.That(favReagents.Count, Is.EqualTo(2));
        }

        [Test]
        public void EmptyDbTest()
        {
            _reagentsRepository.AppDbContent.Reagent.RemoveRange(_reagents[1], _reagents[2]));
            _reagentsRepository.AppDbContent.SaveChanges();

            _reagentsRepository = new ReagentsRepositiry(_dbStub);

            var favReagents = _reagentsRepository.FavReagents.ToList();
            Assert.That(favReagents.Count, Is.EqualTo(0));
        }

        [Test]
        public void NoFavReagentsTest()
        {
            _reagentsRepository.AppDbContent.Reagent.Add(_reagents[0]);
            _reagentsRepository.AppDbContent.SaveChanges();
           
            _reagentsRepository = new ReagentsRepositiry(_dbStub);

            var favReagents = _reagentsRepository.FavReagents.ToList();
            Assert.That(favReagents.Count, Is.EqualTo(0));
        }



    }
}
