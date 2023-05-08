using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    public interface IAllReagents
    {
        IEnumerable<Reagent> Reagents { get;} 
        IEnumerable<Reagent> FavReagents { get; set; } 
        Reagent getObjectReagent(int reagentId);
    }
}
