<<<<<<< HEAD
﻿using Shop.Data.Models;

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
=======
﻿using Shop.Data.Models;

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
>>>>>>> 8b6b47e3c89a8b35f0c2c026b35485af92703192
