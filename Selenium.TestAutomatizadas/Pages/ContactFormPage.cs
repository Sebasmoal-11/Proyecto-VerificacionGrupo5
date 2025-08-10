using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Selenium.TestAutomatizadas.Pages
{
    
    public class ContactFormPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly string _url;

        
        private By NameInput => By.Id("name");
        private By EmailInput => By.Id("email");
        private By MessageTextArea => By.Id("message");
        private By SubmitBtn => By.CssSelector("button[type='submit'], #submit");
        private By SuccessAlert => By.CssSelector(".alert-success, .success, #success-message");

        public ContactFormPage(IWebDriver driver, string baseUrl)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(6));
            _url = baseUrl.TrimEnd('/') + "/contact"; 
        }

        public void Go() => _driver.Navigate().GoToUrl(_url);

        public void FillAndSubmit(string name, string email, string message)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(NameInput)).SendKeys(name);
            _driver.FindElement(EmailInput).SendKeys(email);
            _driver.FindElement(MessageTextArea).SendKeys(message);
            _driver.FindElement(SubmitBtn).Click();
        }

        public bool IsSuccessDisplayed()
        {
            try { _wait.Until(ExpectedConditions.ElementIsVisible(SuccessAlert)); return true; }
            catch { return false; }
        }
    }
}

