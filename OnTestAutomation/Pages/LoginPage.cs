using OnTestAutomation.Globals;
using OnTestAutomation.Helpers;
using OpenQA.Selenium;

namespace OnTestAutomation.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;
        private SeleniumHelper selenium;

        private By textfieldUsername = By.Name("username");
        private By textfieldPassword = By.Name("password");
        private By buttonLogin = By.XPath("//input[@value='Log In']");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            selenium = new SeleniumHelper(_driver);
        }

        public LoginPage Load()
        {
            _driver.Navigate().GoToUrl(Constants.URL_HOME_PAGE);
            return this;
        }

        public void LoginAs(string username, string password)
        {
            selenium.SendKeys(textfieldUsername, username);
            selenium.SendKeys(textfieldPassword, password);
            selenium.Click(buttonLogin);
        }
    }
}
