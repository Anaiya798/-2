# REAXON
## Архитектура проекта
1. Подразумеваемый функционал был подробно описан в [предыдущем задании](https://github.com/Anaiya798/CSharp-2/tree/main/hw01/task1). Теперь распишем основные структурные компоненты:
- **Интерфейсы**
   ```C#
    public interface IReagentsCategory {
      //вывод всех категорий товаров
      IEnumerable<Category> AllCategories {get;}
    }
   ```
   ```C#
    public interface IAllReagents {
      IEnumerable<Reagent> Reagents {get; set;} //список всех реактивов
      IEnumerable<Reagent> FavReagents {get; set;} //список "топовых" реактивов, которые загружаются автоматически при переходе на соответсвующую страницу товаров
      Reagent getObjectReagent(int reagentId) //получение реактива по id
    }
   ```
 - **Mock-классы** (реализуют соответствующие интерфейсы)
     ```C#
     public class MockCategory: IReagentsCategory {}
     public class MockReagents: IAllReagents {}
     ```
