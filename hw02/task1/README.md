# REAXON
## Архитектура проекта
1. Подразумеваемый функционал был подробно описан в [предыдущем задании](https://github.com/Anaiya798/CSharp-2/tree/main/hw01/task1). Теперь распишем основные структурные компоненты:
- **Модели**
   ```C#
    public class Category {
      //класс, описывающий категории товаров
      }
    public class Reagent {
      //класс, описывающий товары (реактивы)
    }
   ```
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
 - **Работа с БД** 
     ```C#
     public class AppDBContent: DbContent {
      //соединение с БД
     }
     public class ReagentsRepositiry: IAllReagents {
      //получение данных о товарах из базы
     }
     public class CategoryRepositiry: IReagentsCategory {
      //получение данных о категориях товаров из базы
     }
     ```
  - **Контроллеры** 
     ```C#
     public class ReagentsController: Controller {
      //возвращает представление товаров магазина в виде html-страницы
      ReagentsListViewModel obj = new ReagentsListViewModel();
      return View(obj);
     }
     ```
   - **ViewModels** (задают шаблоны объектов, которые необходимо передать в представления)
     ```C#
     public class RaegentsListViewModel {
         //шаблон объекта для представления Reagents/List.html
     }
     ```
   - **Представления (Views)** 
     ```C#
     Reagents/List.html //html-страница для отображения товаров магазина 
     ```
