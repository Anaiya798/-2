using Shop.Database;
using Shop.Models;

namespace MyShopTests.DatabaseTests
{
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
                new Reagent() { Id = 1, Name = "Formic acid" , IsFavourite = false},
                new Reagent() { Id = 2, Name = "Ethanol", IsFavourite = true},
                new Reagent() { Id = 3, Name = "Distilled water", IsFavourite = true},

             };


            _dbStub.Reagent.AddRange(_reagents);
            _dbStub.SaveChanges();

            _reagentsRepository = new ReagentsRepositiry(_dbStub);
        }

        [Test]
        public void MixedReagentsTest()
        {
            var favReagents = _reagentsRepository.FavReagents.ToList();
            Assert.IsTrue(favReagents.Contains(_reagents[1]));
            Assert.IsTrue(favReagents.Contains(_reagents[2]));
            Assert.That(favReagents.Count, Is.EqualTo(2));    
        }

        [Test]
        public void AllFavReagentsTest()
        {
            _dbStub.Reagent.Remove(_reagents[0]);
            _dbStub.SaveChanges();

            var favReagents = _reagentsRepository.FavReagents.ToList();
            Assert.That(favReagents.Count, Is.EqualTo(2));
        }

        [Test]
        public void EmptyDbTest()
        {
            _dbStub.Reagent.RemoveRange(_reagents[1], _reagents[2]);
            _dbStub.SaveChanges();

            var favReagents = _reagentsRepository.FavReagents.ToList();
            Assert.That(favReagents.Count, Is.EqualTo(0));
        }

        [Test]
        public void NoFavReagentsTest()
        {
            _dbStub.Reagent.Add(_reagents[0]);
            _dbStub.SaveChanges();

            var favReagents = _reagentsRepository.FavReagents.ToList();
            Assert.That(favReagents.Count, Is.EqualTo(0));
        }



    }
}
