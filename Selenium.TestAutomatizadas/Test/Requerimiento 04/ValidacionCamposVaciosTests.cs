using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.TestAutomatizadas;
using Selenium.TestAutomatizadas.Pages;  // Aquí se importa la carpeta Pages donde está ContactoPage

namespace Selenium.TestAutomatizadas.Test.Caso01_Home
{
    [TestClass]
    public class ValidacionCamposVaciosTests
    {
        private IWebDriver driver;
        private ContactoPage contactoPage;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            contactoPage = new ContactoPage(driver);
            contactoPage.Navegar("https://tusitio.com/contacto");
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void ValidarCamposVacios_NoPermiteEnviarFormulario()
        {
            contactoPage.CompletarFormulario("", "", "Mensaje de prueba");
            contactoPage.EnviarFormulario();

            Assert.IsTrue(contactoPage.ErrorNombre.Displayed, "No se mostró error para nombre vacío");
            Assert.IsTrue(contactoPage.ErrorCorreo.Displayed, "No se mostró error para correo vacío");
        }
    }
}
PruebaCargaCo