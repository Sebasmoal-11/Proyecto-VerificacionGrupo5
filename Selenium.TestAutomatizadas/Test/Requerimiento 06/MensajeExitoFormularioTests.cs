using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.TestAutomatizadas.Pages;  // Ajusta si tu carpeta Pages está en otro lugar

namespace Selenium.TestAutomatizadas.Test.Caso01_Home
{
    [TestClass]
    public class MensajeExitoFormularioTests
    {
        private IWebDriver driver;
        private ContactoPage contactoPage;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            contactoPage = new ContactoPage(driver);
            contactoPage.Navegar("https://tusitio.com/contacto"); // Cambia por la URL correcta
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void Automatizado2_VerificarMensajeExitoDespuesDeEnviarFormulario()
        {
            contactoPage.CompletarFormulario("Juan Pérez", "juan.perez@example.com", "Mensaje de prueba correcto");
            contactoPage.EnviarFormulario();

            Assert.IsTrue(contactoPage.EstaMensajeExitoVisible(), "No se mostró el mensaje de éxito después de enviar el formulario");
        }
    }
}