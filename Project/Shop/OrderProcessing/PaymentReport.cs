using Shop.Data.Models;

namespace Shop.OrderProcessing
{
    public abstract class IPaymentReport
    {
        public virtual void saveReport(Order order)
        {
            
        }
    }

    public class XlsxReport : IPaymentReport
    {
        public override void saveReport(Order order)
        {
            // генерация отчета об операции в формате xlsx
        }
    }

    public class PdfReport : IPaymentReport
    {
        public override void saveReport(Order order)
        {
            // генерация отчета об операции в формате pdf
        }
    }
}
