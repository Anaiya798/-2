using Shop.Data.Models;

namespace Shop.CustomerDataProcessing
{
    public class CustomerInfoVerification
    {
        Order customerOrder;
        public CustomerInfoVerification(Order order)
        {
            customerOrder = order;
        }
        void Main()
        {
            var phoneChecker = new PhoneChecker();
            var emailChecker = new EmailChecker();
            var creditCardChecker = new CreditCardChecker();

            phoneChecker.Successor = emailChecker;
            emailChecker.Successor = creditCardChecker;
            phoneChecker.Check(customerOrder);
        }
    }

    public abstract class CustomerDataChecker
    {
        public CustomerDataChecker Successor { get; set; }
        public abstract bool Check(Order customerOrder);
    }

    public class PhoneChecker : CustomerDataChecker
    {
        public override bool Check(Order customerOrder)
        {
            bool correct = false;
            // провеока корректности номера телефона

            if (correct)
            {
                if (Successor != null)
                {
                    Successor.Check(customerOrder);
                }
                return true;
            }

            else
            {
                //подсвечиваемв UI поле красным 
                return false;
            }
        }
    }


    public class EmailChecker : CustomerDataChecker
    {
        public override bool Check(Order customerOrder)
        {
            bool correct = false;
            // провеока корректности email

            if (correct)
            {
                if (Successor != null)
                {
                    Successor.Check(customerOrder);
                }
                return true;
            }

            else
            {
                //подсвечиваемв UI поле красным 
                return false;
            }
        }
    }

   public class CreditCardChecker : CustomerDataChecker
    {
        public override bool Check(Order customerOrder)
        {
            bool correct = false;
            // провеока корректности номера карты

            if (correct)
            {
                if (Successor != null)
                {
                    Successor.Check(customerOrder);
                }
                return true;
            }

            else
            {
                //подсвечиваемв UI поле красным 
                return false;
            }
        }
    }
}
