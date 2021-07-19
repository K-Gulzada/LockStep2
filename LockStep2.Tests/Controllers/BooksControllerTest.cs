using LockStep2.Controllers.Simple;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LockStep2.Tests.Controllers
{
    public class BooksControllerTest
    {
        [TestMethod]// arrange - подготовка act - воздействие assert - утверждение которое мы хотим проверить
        public void Index()
        {
            var controller = new BookController();

            ViewResult result = controller.Index() as ViewResult;
            if (result is null)
                Assert.Fail("Empty result");
            var model = (List<Book>)result.ViewData.Model;
            if (model is null)
                Assert.Fail("empty Model");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details()
        {
            var controller = new BookController();

            var result = controller.Details(1) as ViewResult;

            if (result is null) Assert.Fail("Empty result");

            var book = (Book)result.ViewData.Model;
            if (book is null) Assert.Fail("Empty model");

            Assert.IsNotNull(result);
        }
    }
}
