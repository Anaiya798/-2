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
2. **Принцип открыт/закрыт**. Допустим, покупатель успешно завершил оплату и хочет сохранить информацию о выполненной операции в формате xlsx/pdf.
```C#
public class IPaymentReport
{
    public virtual void SaveReport(Bill bill)
    {
        // базовый класс
    }
}

public class XlsxReport : IPaymentReport
{
    public override void SaveReport(Bill bill)
    {
        // генерация отчета об операции в формате xlsx
    }
}

public class PdfReport : IPaymentReport
{
    public override void GenerateReport(Bill bill)
    {
        // генерация отчета об операции в формате pdf
    }
}
   ```
 Если захотим добавить новый тип отчета, нужно создать новый класс и унаследоваться от IPaymentReport. Таким образом, класс IPaymentReport реализует
 закрыт от модификаций, но доступен для расширений.
