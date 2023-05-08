using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Mocks
{
    public class MockReagents : IAllReagents
    {
        private readonly IReagentsCategory _categoryReagents = new MockCategory();
        public IEnumerable<Reagent> Reagents { 
            get {
                return new List<Reagent> {
                    new Reagent{
                        Name = "Этанол",
                        Desc = "Этиловый спирт, 90%. Антисептик, растворитель многих органических веществ и некоторых неорганических солей. Объем: 100мл.",
                        Img = "/img/Solvents/ethanol.jpg",
                        Price = 15,
                        isFavourite = true,
                        Available = true,
                        Category = _categoryReagents.AllCategories.ElementAtOrDefault(1)
                    },
                    new Reagent{
                        Name = "Пищевая сода",
                        Desc = "Пищевая сода. Важный компонент пищевой и легкой промышленности, используется в медицине. Нейтрализатор кислотных ожогов. Масса: 100г.",
                        Img = "/img/Inorganic/soda.jpg",
                        Price = 25,
                        isFavourite= true,
                        Available = true,
                        Category= _categoryReagents.AllCategories.ElementAtOrDefault(0)
                    },
                    new Reagent{
                        Name = "Этанол",
                        Desc = "Этиловый спирт, 90%. Антисептик, растворитель многих органических веществ и некоторых неорганических солей. Объем: 100мл.",
                        Img = "/img/Solvents/ethanol.jpg",
                        Price = 15,
                        isFavourite = true,
                        Available = true,
                        Category = _categoryReagents.AllCategories.ElementAtOrDefault(1)
                    },
                     new Reagent{
                        Name = "Этанол",
                        Desc = "Этиловый спирт, 90%. Антисептик, растворитель многих органических веществ и некоторых неорганических солей. Объем: 100мл.",
                        Img = "/img/Solvents/ethanol.jpg",
                        Price = 15,
                        isFavourite = true,
                        Available = true,
                        Category = _categoryReagents.AllCategories.ElementAtOrDefault(1)
                    },
                };
            } 
        }
        public IEnumerable<Reagent> FavReagents { get; set ; }

        public Reagent getObjectReagent(int reagentId)
        {
            throw new System.NotImplementedException();
        }
    }
}
