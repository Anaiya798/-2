using Shop.Models;
using System.Collections.Generic;

namespace Shop.Data.Abstractions
{
    public abstract class AllReagents
    {
        IEnumerable<Reagent> Reagents { get; set; } //список всех реактивов
        IEnumerable<Reagent> FavReagents { get; set; } //список "топовых" реактивов, которые будут отображаться
        public abstract Reagent getObjectReagent(int reagentId) ; //получение реактива по id
 }

}
