<<<<<<< HEAD
﻿using Shop.Data.Models;
using Shop.OrderProcessing;
using System.IO;

namespace MyShopTests.OrderProcessingTests
{
    [TestFixture]
    public class SavePaymentReportTests
    {
        private const string PATH = @"C::\Users\Anastasiia\Downloads";
        private Order _order;
        [SetUp]

        public void Setup()
        {
            _order = new Order() { Id = 1, Name = "", Phone = "+79110000000", Email = "a@gmail.com", CreditCardNumber = "0000000000000000" }; ;
        }

        [Test]
        public void XlsxTest()
        {
            var xlsxReport = new XlsxReport();
            xlsxReport.saveReport(_order);
            Assert.IsTrue(File.Exists(PATH + "\bill.xlsx"));
            
        }

        [Test]
        public void PdfTest()
        {
            var pdfReport = new PdfReport();
            pdfReport.saveReport(_order);
            Assert.IsTrue(File.Exists(PATH + "\bill.pdf"));

        }


    }
}
=======
﻿using Shop.CustomerDataProcessing;
using Shop.Data.Models;
using Shop.OrderProcessing;
using System.IO;

namespace MyShopTests.OrderProcessingTests
{
    [TestFixture]
    public class SavePaymentReportTests
    {
        private const string PATH = @"C::\Users\Anastasiia\Downloads";
        private Order _order;
        [SetUp]

        public void Setup()
        {
            _order = new Order() { Id = 1, Name = "", Phone = "+79110000000", Email = "a@gmail.com", CreditCardNumber = "0000000000000000" }; ;
        }

        [Test]
        public void XlsxTest()
        {
            var xlsxReport = new XlsxReport();
            xlsxReport.saveReport(_order);
            Assert.IsTrue(File.Exists(PATH + "\bill.xlsx"));
            
        }

        [Test]
        public void PdfTest()
        {
            var pdfReport = new PdfReport();
            pdfReport.saveReport(_order);
            Assert.IsTrue(File.Exists(PATH + "\bill.pdf"));

        }


    }
}
>>>>>>> 8b6b47e3c89a8b35f0c2c026b35485af92703192
