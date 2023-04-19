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
                        Img = "https://images.satu.kz/181043069_spirt-etilovyj-90.jpg",
                        Price = 15,
                        isFavourite = true,
                        Available = true,
                        Category = _categoryReagents.AllCategories.ElementAtOrDefault(1)
                    },
                    new Reagent{
                        Name = "Пищевая сода",
                        Desc = "Пищевая сода. Важный компонент пищевой и легкой промышленности, используется в медицине. Нейтрализатор кислотных ожогов. Масса: 100г.",
                        Img = "https://avatars.mds.yandex.net/get-mpic/4101287/img_id56832692990966801.jpeg/orig",
                        Price = 25,
                        isFavourite= true,
                        Available = true,
                        Category= _categoryReagents.AllCategories.ElementAtOrDefault(0)
                    }
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
