using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;                         // By, IWebElement
using OpenQA.Selenium.Support.UI;              // WebDriverWait
using SeleniumExtras.WaitHelpers;              // ExpectedConditions
using Selenium.TestAutomatizadas.Pages;

namespace Selenium.TestAutomatizadas.Test.Caso03_Product
{
    [TestClass]
    [TestCategory("UI"), TestCategory("Products")]
    public class ProductCreationTests : BaseTest
    {
        [TestMethod]
        public void Product_Should_Appear_In_List_After_Create()
        {
            var page = new ProductoPage(Driver);   //  tu constructor actual

            // 1) Ir al index y abrir "Agregar Producto"
            page.IrAIndex(BaseUrl);                
            page.ClickAgregarProducto();

            // 2) Completar y enviar el formulario (usando tus métodos)
            var uniqueName = $"Zapato Deportivo {DateTime.UtcNow:yyyyMMddHHmmss}";
            page.CompletarFormulario(uniqueName, "Ligero y cómodo para correr.", "49.99");
            page.EnviarFormularioProducto();

            // 3) Esperar redirección/carga del listado
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(8));
            wait.Until(d =>
                d.Url.Contains("products", StringComparison.OrdinalIgnoreCase) ||
                d.FindElements(AnyListSelector).Count > 0
            );

            // 4) Buscar el contenedor de la lista y verificar el nuevo producto
            var listContainer = FindListContainerOrFail();
            var exists = listContainer.Text.Contains(uniqueName, StringComparison.OrdinalIgnoreCase);

            Assert.IsTrue(exists, $"El producto '{uniqueName}' no aparece en la lista después de crearlo.");
        }

        // --- Helpers específicos del test (no tocan tu Page) ---

        // English: Try several common selectors for product list container. Replace with your exact one if you know it.
        private static readonly By[] CandidateListSelectors = new[]
        {
            By.CssSelector("#productsList"),
            By.CssSelector("table#grid-products"),
            By.CssSelector("table#products"),
            By.CssSelector(".products"),
            By.CssSelector("#product-list")
        };

        private static By AnyListSelector => By.CssSelector("#productsList, table#grid-products, table#products, .products, #product-list");

        private IWebElement FindListContainerOrFail()
        {
            foreach (var by in CandidateListSelectors)
            {
                var found = Driver.FindElements(by);
                if (found.Count > 0) return found[0];
            }
            Assert.Fail("No se encontró el contenedor de la lista de productos. Ajusta el selector a tu HTML.");
            throw new InvalidOperationException(); // nunca se alcanza
        }
    }
}
