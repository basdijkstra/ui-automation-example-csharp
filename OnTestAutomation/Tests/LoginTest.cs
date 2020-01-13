using NUnit.Framework;
using OnTestAutomation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OnTestAutomation.Tests
{
    [TestFixture]
    public class LoginTest
    {
        private IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void LoginWithCorrectCredentials_ShouldRedirectToAccountsOverviewPage()
        {
            new LoginPage(driver)
                .Load()
                .LoginAs("john", "demo");

            Assert.IsTrue(
                new AccountsOverviewPage(driver)
                .IsLoaded()
            );
        }

        [Test]
        public void LoginWithIncorrectCredentials_ShouldRedirectToLoginErrorPage()
        {
            new LoginPage(driver)
                .Load()
                .LoginAs("john", "incorrectpassword");

            Assert.AreEqual(
                "The username and password could not be verified.",
                new LoginErrorPage(driver).GetErrorMessage()
            );
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
