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
        // провеока корректности номера карты
         
        
        if (correct && Successor != null)
        {
            Successor.Check(customerData);
        }
    }
}

   ```
