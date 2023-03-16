using Shop.Database;
using Shop.Models;

namespace MyShopTests.DatabaseTests
{
    [TestFixture]
    public class GetReagentByIdTests
    {
        private AppDBContent _dbStub;
        private ReagentsRepositiry _reagentsRepository;
        private List<Reagent> _reagents;

        [SetUp]
        public void Setup()
        {
            _dbStub = new AppDBContent();

            _reagents = new List<Reagent>() {
                new Reagent() { Id = 1, Name = "Formic acid" , Category = 1},
                new Reagent() { Id = 15, Name = "Ethanol", Category = 1 }
             };
     

            _dbStub.Reagent.AddRange(_reagents);
            _dbStub.SaveChanges();

            _reagentsRepository = new ReagentsRepositiry(_dbStub);
        }

        [Test]
        public void CorrectIdTest()
        {
            var desiredReagent = _reagentsRepository.getObjectReagent(1);
            Assert.That(desiredReagent.Name, Is.EqualTo(_reagents[0].Name));
            Assert.That(desiredReagent.Category, Is.EqualTo(_reagents[0].Category));

            desiredReagent = _reagentsRepository.getObjectReagent(15);
            Assert.That(desiredReagent.Name, Is.EqualTo(_reagents[1].Name));
            Assert.That(desiredReagent.Category, Is.EqualTo(_reagents[1].Category));
        }

        [Test]
        public void NonExistentIdTest()
        {
            var desiredReagent = _reagentsRepository.getObjectReagent(2);
            Assert.Null(desiredReagent);
   
            desiredReagent = _reagentsRepository.getObjectReagent(-100);
            Assert.Null(desiredReagent);

        }

    }
}
