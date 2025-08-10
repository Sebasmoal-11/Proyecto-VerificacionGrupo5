using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using TiendaVirtualMVC.Controllers;

namespace TiendaVirtualMVC.Tests
{
    [TestClass]
    public class ValidarMensajeExitoTests
    {
        [TestMethod]
        public void MensajeExito_SeAlmacenaYSeMuestraEnVista()
        {
            var tempDataMock = new Mock<ITempDataDictionary>();

            var controller = new ContactController();
            controller.TempData = tempDataMock.Object;

            var result = controller.ContactSuccess() as ViewResult;

            tempDataMock.VerifySet(t => t["SuccessMessage"] = "Mensaje enviado con éxito", Times.Once);

            Assert.IsNotNull(result, "No se devolvió una vista");
        }
    }
}
//Prueba unitaria 8