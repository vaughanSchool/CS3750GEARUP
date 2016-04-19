using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GearUp;
using GearUp.Controllers;

namespace GearUp.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void ReturnUrl()
        {
            // Arrange
            AccountController controller = new AccountController();

            //Act
            ViewResult result = controller.Login("TEST") as ViewResult;

            // Assert
            Assert.AreEqual("TEST", controller.ViewBag.ReturnUrl);
        }

        [TestMethod]
        public void Login()
        {
            // Arrange
            AccountController controller = new AccountController();

            //Act
            ViewResult result = controller.Login("Test") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
