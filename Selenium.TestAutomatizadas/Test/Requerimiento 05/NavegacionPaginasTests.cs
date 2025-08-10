using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium.TestAutomatizadas.Test.Caso01_Home
{
    [TestClass]
    public class NavegacionPaginasTests
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://tusitio.com");
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }

        [TestMethod]
        public void NavegacionEntrePaginas_DebeSerRapidaYSinErrores()
        {
            driver.FindElement(By.LinkText("Inicio")).Click();
            Assert.IsTrue(driver.Url.Contains("/inicio"));

            driver.FindElement(By.LinkText("Productos")).Click();
            Assert.IsTrue(driver.Url.Contains("/productos"));

            driver.FindElement(By.LinkText("Contacto")).Click();
            Assert.IsTrue(driver.Url.Contains("/contacto"));
        }
    }
}

