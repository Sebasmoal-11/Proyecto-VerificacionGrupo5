using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Selenium.TestAutomatizadas.Pages
{
    public class ContactoPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public ContactoPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Campos del formulario (ajusta los IDs si son diferentes)
        private IWebElement Nombre => driver.FindElement(By.Id("nombre"));
        private IWebElement Correo => driver.FindElement(By.Id("correo"));
        private IWebElement Mensaje => driver.FindElement(By.Id("mensaje"));
        private IWebElement BtnEnviar => driver.FindElement(By.Id("btnEnviar"));

        // Mensajes de error para campos vacíos
        public IWebElement ErrorNombre => driver.FindElement(By.Id("errorNombre"));
        public IWebElement ErrorCorreo => driver.FindElement(By.Id("errorCorreo"));

        // Mensaje de éxito después de enviar
        public IWebElement MensajeExito => driver.FindElement(By.Id("mensajeExito"));

        // Navegar a una URL específica
        public void Navegar(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        // Completar el formulario
        public void CompletarFormulario(string nombre, string correo, string mensaje)
        {
            Nombre.Clear();
            Nombre.SendKeys(nombre);
            Correo.Clear();
            Correo.SendKeys(correo);
            Mensaje.Clear();
            Mensaje.SendKeys(mensaje);
        }

        // Hacer click en enviar
        public void EnviarFormulario()
        {
            BtnEnviar.Click();
        }

        // Verificar si el mensaje de éxito está visible
        public bool EstaMensajeExitoVisible()
        {
            try
            {
                wait.Until(d => MensajeExito.Displayed);
                return MensajeExito.Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}