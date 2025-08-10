
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Selenium.TestAutomatizadas.Pages;
using Selenium.TestAutomatizadas.Test.Caso03_Product;

namespace Selenium.TestAutomatizadas.Test.Caso02_Contact
{
    [TestClass]
    [TestCategory("UI"), TestCategory("Contact")]
    public class ContactFormTests : BaseTest
    {
        [TestMethod]
        public void ContactForm_Should_Submit_And_Show_Success()
        {
            var contact = new ContactFormPage(Driver, BaseUrl);
            contact.Go();

            contact.FillAndSubmit(
                name: "Juan Pérez",
                email: "juan.perez@example.com",
                message: "Hola, este es un mensaje de prueba automatizada."
            );

            Assert.IsTrue(contact.IsSuccessDisplayed(), "No se mostró el mensaje de éxito tras enviar el formulario.");
        }
    }
}

