using UiAutomationExample.Helpers;
using OpenQA.Selenium;

namespace UiAutomationExample.Pages
{
    public class LoginErrorPage
    {
        private IWebDriver _driver;
        private SeleniumHelper selenium;

        private By textlabelErrorMessage = By.XPath("//p[@class='error']");

        public LoginErrorPage(IWebDriver driver)
        {
            _driver = driver;
            selenium = new SeleniumHelper(_driver);
        }
        
        public string GetErrorMessage()
        {
            return selenium.GetElementText(textlabelErrorMessage);
        }
    }
}
