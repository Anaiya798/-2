# REAXON
## Принципы SOLID
1. **Принцип единственной ответственности**. Реализован через паттерн "Цепочка обязанностей": последовательно проверяем корректность введенных покупателем данных 
(сначала номер телефона, затем e-mail и номер карты)
 ```C#
class CustomerDataProcessing
{
    void Main()
    {
        var phoneChecker = new PhoneChecker();
        var emailChecker = new EmailChecker();
        var creditCardChecker = new creditCardChecker();
        
        phoneChecker.Successor = emailChecker;
        emailChecker.Successor = creditCardChecker;
        phoneChecker.Check(customerData);
    }
}

abstract class CustomerDataChecker
{
    public CustomerDataChecker Successor { get; set; }
    public abstract void Check(List<string> customerData);
}
    
class PhoneChecker: CustomerDataChecker
{
    public override void Check(List<string> customerData)
    {
        bool correct = false;
        // провеока корректности номера телефона
         
        
        if (correct && Successor != null)
        {
            Successor.Check(customerData);
        }
    }
}


class EmailChecker: CustomerDataChecker
{
    public override void Check(List<string> customerData)
    {
        bool correct = false;
        // провеока корректности номера email
         
        
        if (correct && Successor != null)
        {
            Successor.Check(customerData);
        }
    }
}

class CreditCardChecker: CustomerDataChecker
{
    public override void Check(List<string> customerData)
    {
        bool correct = false;
        // проверка корректности номера карты
         
        
        if (correct && Successor != null)
        {
            Successor.Check(customerData);
        }
    }
}

   ```
2. **Принцип открыт/закрыт**. Допустим, покупатель успешно завершил оплату и хочет сохранить чек в формате xlsx/pdf.
```C#
public abstract class IPaymentReport
{
    public virtual void SaveReport(Order order)
    {
        // базовый класс
    }
}

public class XlsxReport : IPaymentReport
{
    public override void SaveReport(Order order)
    {
        // генерация отчета об операции в формате xlsx
    }
}

public class PdfReport : IPaymentReport
{
    public override void SaveReport(Order order)
    {
        // генерация отчета об операции в формате pdf
    }
}
   ```
   Если захотим добавить новый тип отчета, нужно создать новый класс и унаследоваться от *IPaymentReport*. Таким образом, класс *IPaymentReport* реализует
   закрыт от модификаций, но доступен для расширений.
 
 3. **Принцип подстановки Барбары Лисков**. У нас есть абстрактный класс *IAllReagents* и есть наследуемый от него класс *ReagentsRepositiry*, который отвечает за 
 хранение всех реактивов, имеющихся в базе данных.
 ```C#
    public abstract class IAllReagents {
      IEnumerable<Reagent> Reagents {get; set;} //список всех реактивов
      IEnumerable<Reagent> FavReagents {get; set;} //список "топовых" реактивов, которые будут отображаться
      Reagent getObjectReagent(int reagentId) //получение реактива по id
    }
    
    public class ReagentsRepositiry: IAllReagents {
      public IEnumerable<Reagent> Reagents =>... //достаем список реактивов из базы данных 
      public IEnumerable<Reagent> FavReagents =>... //достаем список "топовых" реактивов 
      Reagent getObjectReagent(int reagentId) {
       //реализуем метод, если реактив не найден, возвращаем пустой объект класса Reagent
     }
   ```
   Класс *ReagentsRepositiry* реализует все поля и методы базового класса, не усиливает предусловий, не ослабляет постусловий, не нарушает инвариантов и не 
   генерирует типов исключений, не описанных в базовом классе. Поэтому он не нарушает принцип подстановки Барбары Лисков.
   
 4. **Принцип разделения интерфейсов**. Допустим, для особо опасных реактивов мы хотим выводить во вкладке с товарами дополнительную информацию о том, что они особо опасны. Создадим для этой цели отдельный интерфейс, чтобы избежать лишних зависимостей:
 ```C#
    public interface IProductsInformation {
      void ShowProductsInfo(IAllReagents reagents); 
    }
    
    public interface IDangerInformation {
      void ShowHighDangerStatus(IAllReagents highDangerReagents); 
    }
    
    public class NormalReagentsInformation: IProductsInformation {
     //для обычных реактивов просто выводим информацию о них
    }
    
    public class DangerReagentsInformation: IProductsInformation, IDangerInformation {
     //для особо опасных выводим общую информацию + информацию об особой опасности
    }
   ```
5. **Принцип инверсии зависимостей**. Система Интернет-магазина периодически рассылает пользователям сообщения по e-mail: уведомление об успешном заказе, чек (возможно, что-то еще). Реализуем это с помощью следующего кода: 
 ```C#
public interface IEmail
{
    void Send();
}

public class SuccessOrderEmail : IEmail
{
    public void Send()
    {
        // отправка уведомления об успешном заказе
    }
}

public class ReceiptEmail : IEmail
{
    public void Send()
    {
        // отправка чека
    }
}

public class Notification
{
    public void Notify(IEmail email)
    {
        email.Send();
    }
}
   ```
Видим, что более высокоуровневый класс (*Notification*) не зависит от более низкоуровневых классов (*SuccessOrderEmail* и *ReceiptEmail*), но оба они зависят от абстракции (интерфейса) *IEmail*, а абстракция нигде не зависит от деталей. Это является примером реализации принципа инверсии зависимостей.
