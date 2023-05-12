using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ChemicalShop.Data.Repository
{
    public class ReagentsRepository : IAllReagents
    {
        private readonly AppDbContent _appDbContent;

        public ReagentsRepository(AppDbContent appDbContent)
        {
            _appDbContent = appDbContent;
        }
        public IEnumerable<Reagent> Reagents => _appDbContent.Reagent.Include(reagent => reagent.Category);

        public IEnumerable<Reagent> FavReagents => _appDbContent.Reagent.Where(reagent => reagent.isFavourite).Include(reagent => reagent.Category);
        public Reagent getObjectReagent(int reagentId) => _appDbContent.Reagent.FirstOrDefault(reagent => reagent.Id == reagentId);
       
    }
}
