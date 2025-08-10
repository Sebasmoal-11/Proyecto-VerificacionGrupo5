using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Selenium.TestAutomatizadas.Pages
{
    public class ProductoPage
    {
        private readonly IWebDriver driver;

        public ProductoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Localizadores para formulario (solo en add-product.html)
        public IWebElement InputNombre => driver.FindElement(By.Id("productName"));
        public IWebElement InputDescripcion => driver.FindElement(By.Id("productDescription"));
        public IWebElement InputPrecio => driver.FindElement(By.Id("productPrice"));
        public IWebElement BotonAgregar => driver.FindElement(By.CssSelector("button[type='submit']"));

        // Localizador para el enlace "Agregar Producto" en index.html
        public IWebElement LinkAgregarProducto => driver.FindElement(By.LinkText("Agregar Producto"));

        // Método para ir a la página principal (index.html)
        public void IrAIndex(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        // Método para hacer clic en el enlace Agregar Producto
        public void ClickAgregarProducto()
        {
            LinkAgregarProducto.Click();
        }

        // Métodos para completar formulario
        public void EscribirNombre(string nombre)
        {
            InputNombre.Clear();
            InputNombre.SendKeys(nombre);
        }

        public void EscribirDescripcion(string descripcion)
        {
            InputDescripcion.Clear();
            InputDescripcion.SendKeys(descripcion);
        }

        public void EscribirPrecio(string precio)
        {
            InputPrecio.Clear();
            InputPrecio.SendKeys(precio);
        }

        public void CompletarFormulario(string nombre, string descripcion, string precio)
        {
            EscribirNombre(nombre);
            EscribirDescripcion(descripcion);
            EscribirPrecio(precio);
        }

        public void EnviarFormularioProducto()
        {
            BotonAgregar.Click();
        }
        // GoToCreate(): usa tu flujo existente (index -> click "Agregar Producto")
        public void GoToCreate(string urlBase)
        {
            if (string.IsNullOrWhiteSpace(urlBase))
                throw new ArgumentException("urlBase no puede ser nula o vacía.", nameof(urlBase));

            IrAIndex(urlBase);
            ClickAgregarProducto();

            // espera a que cargue el formulario
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("productName")));
        }

        // CreateProduct(): envuelve tus métodos + espera a que vuelva al listado
        public void CreateProduct(string name, decimal price, string description)
        {
            CompletarFormulario(name, description, price.ToString("0.00"));
            EnviarFormularioProducto();

            // espera redirección o la aparición del contenedor de lista
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(d =>
                d.Url.Contains("products", StringComparison.OrdinalIgnoreCase) ||
                d.FindElements(By.CssSelector("#productsList, .products, table#grid-products")).Count > 0
            );
        }
    }
}

