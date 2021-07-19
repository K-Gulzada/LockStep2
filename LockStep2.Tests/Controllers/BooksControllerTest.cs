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

        }
    }
}
