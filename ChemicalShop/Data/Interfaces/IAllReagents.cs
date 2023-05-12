using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    public interface IAllReagents
    {
        IEnumerable<Reagent> Reagents { get;} 
        IEnumerable<Reagent> FavReagents { get; } 
        Reagent getObjectReagent(int reagentId);
    }
}
