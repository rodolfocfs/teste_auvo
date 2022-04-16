using ClimaTempoSimples;
using ClimaTempoSimples.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ClimaTempoSimples.Tests.Controllers
{
    [TestClass]
    public class ClimaTempoControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            ClimaTempoController controller = new ClimaTempoController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            ClimaTempoController controller = new ClimaTempoController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

    }
}
