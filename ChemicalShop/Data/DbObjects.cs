using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace ChemicalShop.Data
{
    public class DbObjects
    {
        public static void Initial(AppDbContent content)
        {
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Reagent.Any())
            {
                content.AddRange(
                    new Reagent
                    {
                        Name = "Пищевая сода",
                        Desc = "Важный компонент пищевой и легкой промышленности, используется в медицине. Нейтрализатор кислотных ожогов. Масса: 450г.",
                        Img = "/img/Inorganic/soda.jpg",
                        Purity = "Химически чистый",
                        Price = 25,
                        isFavourite = true,
                        Available = true,
                        Category = Categories["Неорганическая химия"]
                    },

                     new Reagent
                     {
                         Name = "Диоксид марганца",
                         Desc = "Порошок тёмно-коричневого цвета, нерастворимый в воде. Применяется для промышленного производства марганца",
                         Img = "/img/Inorganic/manganeseDioxide.jpg",
                         Purity = "Химически чистый",
                         Price = 810,
                         isFavourite = false,
                         Available = true,
                         Category = Categories["Неорганическая химия"]
                     },

                     new Reagent
                       {
                           Name = "Азотная кислота",
                           Desc = "Порошок тёмно-коричневого цвета, нерастворимый в воде. Применяется для промышленного производства марганца",
                           Img = "/img/Inorganic/nitricAcid.jpg",
                           Purity = "Химически чистый",
                           Price = 950,
                           isFavourite = true,
                           Available = true,
                           Category = Categories["Неорганическая химия"]
                      },

                     new Reagent
                       {
                           Name = "Бромпропан",
                           Desc = "Незаменим для обезжиривания пластика, оптики и металлических поверхностей",
                           Img = "/img/Organic/brompropane.jpg",
                           Purity = "Технический",
                           Price = 2000,
                           isFavourite = false,
                           Available = false,
                           Category = Categories["Органическая химия"]
                       },


                      new Reagent
                       {
                           Name = "Бутанол",
                           Desc = "Подходит для получения пластификаторов, используется в синтезе многих органических соединений",
                           Img = "/img/Organic/butanol.jpg",
                           Purity = "Технический",
                           Price = 665,
                           isFavourite = true,
                           Available = true,
                           Category = Categories["Органическая химия"]
                       },

                       new Reagent
                        {
                            Name = "Резорцин",
                            Desc = "Обеззараживающее средство при лечении кожных заболеваний",
                            Img = "/img/Organic/resorcinol.jpg",
                            Purity = "Химически чистый",
                            Price = 674,
                            isFavourite = false,
                            Available = false,
                            Category = Categories["Органическая химия"]
                        },

                        new Reagent
                         {
                             Name = "Салициловая кислота",
                             Desc = "Обладает вырженным противовоспалительным действием, подходит для консервирования пищевых продуктов",
                             Img = "/img/Organic/resorcinol.jpg",
                             Purity = "Химически чистый",
                             Price = 18,
                             isFavourite = true,
                             Available = true,
                             Category = Categories["Органическая химия"]
                         },

                         new Reagent
                          {
                              Name = "Лакмус",
                              Desc = "Кислотно-основный индикатор",
                              Img = "/img/Indicators/litmus.jpg",
                              Purity = "Химически чистый",
                              Price = 246,
                              isFavourite = true,
                              Available = true,
                              Category = Categories["Индикаторы"]
                          },

                         new Reagent
                            {
                                Name = "Метиловый оранжевый",
                                Desc = "Кислотно-основный индикатор",
                                Img = "/img/Indicators/methylOrange.jpg",
                                Purity = "Химически чистый",
                                Price = 123,
                                isFavourite = true,
                                Available = true,
                                Category = Categories["Индикаторы"]
                          },

                         new Reagent
                          {
                              Name = "Фенолфталеин",
                              Desc = "Кислотно-основный индикатор",
                              Img = "/img/Indicators/phenolphtalein.jpg",
                              Purity = "Химически чистый",
                              Price = 100,
                              isFavourite = true,
                              Available = true,
                              Category = Categories["Индикаторы"]
                          },


                         new Reagent
                         {
                            Name = "Этанол",
                            Desc = "Антисептик, растворитель многих органических веществ и некоторых неорганических солей. Объем: 100мл.",
                            Img = "/img/Solvents/ethanol.jpg",
                            Purity = "Технический",
                            Price = 15,
                            isFavourite = true,
                            Available = true,
                            Category = Categories["Растворители"]
                          },

                          new Reagent
                          {
                              Name = "Диэтиловый эфир",
                              Desc = "Типичный алифатический простой эфир, широко используется в качестве растворителя",
                              Img = "/img/Solvents/ether.jpg",
                              Purity = "Технический",
                              Price = 1050,
                              isFavourite = true,
                              Available = true,
                              Category = Categories["Растворители"]
                          },

                          new Reagent
                          {
                              Name = "Тетрациклин",
                              Desc = "Антибиотик, входит в состав многих жизненно необходимых и важнейших лекарственных препаратов",
                              Img = "/img/BAC/tetracycline.jpg",
                              Purity = "Химически чистый",
                              Price = 36,
                              isFavourite = true,
                              Available = true,
                              Category = Categories["БАВ"]
                          }
                         
                    );
            }
            content.SaveChanges();
        }

        private static Dictionary<string, Category> _category;
        public static Dictionary<string, Category> Categories
        {
            get {
                if (_category == null)
                {
                    var list = new Category[]
                    {
                        new Category {Name = "Неорганическая химия"},
                        new Category {Name = "Органическая химия"},
                        new Category {Name = "Индикаторы"},
                        new Category {Name = "Растворители"},
                        new Category {Name = "БАВ"},

                    };
                    _category = new Dictionary<string, Category>();
                    foreach(Category category in list)
                    {
                        _category.Add(category.Name, category);
                    }
                }
                return _category;
            }
        }
    }
}
