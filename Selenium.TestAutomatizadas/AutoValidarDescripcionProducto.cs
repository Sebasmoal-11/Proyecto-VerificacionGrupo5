using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.TestAutomatizadas
{
    public class AutoValidarDescripcionProducto
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:5001/Product/Create"); // Cambia el puerto si es necesario
        }

        [Test]
        public void DescripcionMayorA500DebeMostrarError()
        {
            // Crear descripción de más de 500 caracteres
            string descripcionLarga = new string('a', 501);

            driver.FindElement(By.Id("Name")).SendKeys("Producto de prueba");
            driver.FindElement(By.Id("Description")).SendKeys(descripcionLarga);
            driver.FindElement(By.Id("Price")).SendKeys("100");
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            // Verificar que aparece el mensaje de error
            var body = driver.FindElement(By.TagName("body")).Text;
            Assert.IsTrue(body.Contains("La descripción no puede tener más de 500 caracteres"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
