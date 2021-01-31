using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using WebApplication.Controllers;

namespace WebApi.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

        }
        [TestMethod]
        public void UsuarioIndexTest()
        {
            UsuarioController controller = new UsuarioController();
            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void UsuarioEditTest()
        {
            UsuarioController controller = new UsuarioController();
            ViewResult result = controller.Edit(2) as ViewResult;

            Assert.IsNotNull(result);

        }
    }
}
