using Shop.Data.Abstractions;
using Shop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Database
{
    public class ReagentsRepositiry : AllReagents
    {
        //получение данных о товарах из базы

        private readonly AppDBContent appDbContent;

        public ReagentsRepositiry (AppDBContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<Reagent> Reagents => appDbContent.Reagent;
        public IEnumerable<Reagent> FavReagents => appDbContent.Reagent.Where(regent => regent.IsFavourite);
        public override Reagent getObjectReagent(int reagentId) => appDbContent.Reagent.FirstOrDefault(reagent => reagent.Id == reagentId);
    }
}
