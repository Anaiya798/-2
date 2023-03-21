using Shop.Data.Abstractions;
using Shop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Database
{
    public class ReagentsRepository : AllReagents
    {
        //получение данных о товарах из базы

        private AppDBContent _appDbContent;

        public AppDBContent AppDbContent
        {
            get
            {
                return _appDbContent;
            }
            private set
            {
                _appDbContent = value;
            }
        }

        public ReagentsRepository (AppDBContent appDbContent)
        {
            AppDbContent = appDbContent;
        }

        public IEnumerable<Reagent> Reagents => AppDbContent.Reagent;
        public IEnumerable<Reagent> FavReagents => AppDbContent.Reagent.Where(regent => regent.IsFavourite);
        public override Reagent getObjectReagent(int reagentId) => AppDbContent.Reagent.FirstOrDefault(reagent => reagent.Id == reagentId);
    }
}
