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
   
    public class ShopCartItem {
      //описывает элемент (товар) в корзине покупателя
    }
     public class ShopCart {
      //класс, описывающий корзину покупателя
    }
    public class Order {
      //класс, описывающий заказ покупателя (сведения о самом покупателе)
    }
    
    public class OrderDetails {
      //класс, описывающий детали заказа покупателя (сведения о покупаемых товарах)
    }
    
   ```
- **Абстрактные классы** (возможно реализация в виде интерфейсов)
   ```C#
    public abstract class ReagentsCategory {
      //вывод всех категорий товаров
      IEnumerable<Category> AllCategories {get;}
    }
   ```
   ```C#
    public abstract class AllReagents {
      IEnumerable<Reagent> Reagents {get; set;} //список всех реактивов
      IEnumerable<Reagent> FavReagents {get; set;} //список "топовых" реактивов, которые будут отображаться
      public abstract Reagent getObjectReagent(int reagentId) //получение реактива по id
    }
    
    public abstract class AllOrders {
      public abstract void createOrder();
    }
   ```
 - **Работа с БД** (Database service)
     ```C#
     public class AppDBContent: DbContext {
      //соединение с БД
     }
     public class DBObjects {
      //загрузка данных в локальную базу при инициализации (запуске проекта)
     }
     public class ReagentsRepositiry: AllReagents {
      //получение данных о товарах из базы
     }
     public class CategoryRepositiry: ReagentsCategory {
      //получение данных о категориях товаров из базы
     }
     public class OrdersRepository: AllOrders {
      //запись данных о заказах в базу
     }
     ```
  - **Контроллеры**  (связывают модели и представления)
     ```C#
     public class ReagentsController: Controller {
       ReagentsController(AllReagents reagentsRep, ReagentsCategory categoryRep) {
       }
      //возвращает представление товаров магазина в виде html-страницы
      ReagentsListViewModel obj = new ReagentsListViewModel();
      return View(obj);
     }
     
     public class ShopCartController: Controller {
      ShopCartController(AllReagents reagentsRep, ShopCart shopCart) {
      }
      //возвращает представление корзины покупателя в виде html-страницы
      ShopCartViewModel obj = new ShopCartViewModel();
      return View(obj);
     }
     
     public class HomeController: Controller {
      HomeController(AllReagents reagentsRep) {
      }
      //возвращает представление главной страницы в виде html
      HomeViewModel obj = new HomeViewModel();
      return View(obj);
     }
     
     public class OrderController: Controller {
      OrderController(AllOrders orders,  ShopCart shopCart) {
      }
      //возвращает представление страницы  оформления заказа в виде html
      return View();
     }
     ```
   - **ViewModels** (задают шаблоны объектов, которые необходимо передать в представления)
     ```C#
     public class ReagentsListViewModel {
         //шаблон объекта для представления Reagents/List.html
     }
     public class ShopCartViewModel {
      //шаблон объекта для представления ShopCart/List.html
     }
     public class HomeViewModel {
      //шаблон объекта для представления Home/List.html
     }
     ```
   - **Представления (Views)** 
     ```C#
     Reagents/List.html //html-страница для отображения товаров магазина 
     ShopCart/List.html //html-страница для отображения корзины покупателя 
     Home/List.html //главная html-страница 
     Order/List.html //html-страница оформления 
     ```
   **Основные таблицы базы данных:**  
   
   ![db_tables](https://github.com/Anaiya798/CSharp-2/blob/main/hw02/task1/imgs/db_tables.png) 
2. Архитектура в виде диаграммы:
![project_scheme](https://github.com/Anaiya798/CSharp-2/blob/main/hw02/task1/imgs/project_scheme.png)  
3. Возможности использования паттернов: 
   - **Посредник**. Реализуется за счет шаблона MVC, лежащего в основе всей архитектуры приложения: контроллеры выступают посредником в общении UI и Database service,
   Database service играет роль посредника между контроллерами и БД.
   - **Декоратор**. Класс для загрузки данных из БД можем дополнить различными функциями для сбора статистики (например, времени загрузки при инициализации).
   - **Заместитель**. Создаем некий прокси-сервер, на который будут поступать заявки на оформление заказа. Прокси-сервер может отправить заказ в черынй список, если сочтет подозрительным (пользователь хочет купить слишком много особо опасных веществ и т.п.). Если ничего подозрительного не найдено, обработка заказа проксируется соответствующему контроллеру.  
   - **Цепочка событий**. При оформлении заказа последовательно проверяем корректность введенных данных: корректность номера телефона, email-а, банковской карты.
   - **Состояние**. Разная последовательность дальнейших действий в заисимости от того, выбрал пользователь оплату курьером или самовывоз.   
   - **Строитель**. Класс StatisticsLogBuilder собирает воедино информацию о различных собранных статистиках: время загрузки данных, общее коичество заказов, количество успешных, средняя стоимость чека и т.п. В наследниках StatisticsLogBuilder можно варьировать различные опции сохранения каждой из статистик.
   
