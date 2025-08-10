using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Selenium.TestAutomatizadas.Pages
{
    
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly string _url;

        private By BannerLogo => By.CssSelector("header img, header .logo, .site-logo");

        public HomePage(IWebDriver driver, string baseUrl)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            _url = baseUrl.TrimEnd('/') + "/";
        }

        public void Go() => _driver.Navigate().GoToUrl(_url);

        public bool IsLoaded()
        {
            try { _wait.Until(ExpectedConditions.ElementExists(BannerLogo)); return true; }
            catch { return false; }
        }

        public bool HasNoClientErrors()
        {
            try
            {
                var logs = _driver.Manage().Logs.GetLog(LogType.Browser);
                return logs.All(e => !e.Level.ToString().Equals("SEVERE", StringComparison.OrdinalIgnoreCase));
            }
            catch { return true; } // si el driver no expone logs, no fallamos por eso
        }
    }
}