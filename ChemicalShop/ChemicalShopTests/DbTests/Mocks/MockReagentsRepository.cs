using ChemicalShop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Models;

namespace ChemicalShopTests.DbTests
{
    class MockReagentsRepository: IAllReagents
    {
        private readonly MockDbContent _mockDbContent;

        public MockReagentsRepository(MockDbContent mockDbContent)
        {
            _mockDbContent = mockDbContent;
        }
        public IEnumerable<Reagent> Reagents => _mockDbContent.Reagent;

        public IEnumerable<Reagent> FavReagents =>  _mockDbContent.Reagent.Where(reagent => reagent.isFavourite);
        public Reagent getObjectReagent(int reagentId) => _mockDbContent.Reagent.FirstOrDefault(reagent => reagent.Id == reagentId);
    }
}
