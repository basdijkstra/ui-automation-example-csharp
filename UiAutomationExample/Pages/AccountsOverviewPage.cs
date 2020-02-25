using OnTestAutomation.Helpers;
using OpenQA.Selenium;

namespace OnTestAutomation.Pages
{
    public class AccountsOverviewPage
    {
        private IWebDriver _driver;
        private SeleniumHelper selenium;

        private By textlabelPageHeader = By.XPath("//h1[@class='title' and text()='Accounts Overview']");

        public AccountsOverviewPage(IWebDriver driver)
        {
            _driver = driver;
            selenium = new SeleniumHelper(_driver);
        }

        public bool IsLoaded()
        {
            return selenium.CheckElementIsVisible(textlabelPageHeader);
        }
    }
}
