using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OnTestAutomation.Helpers
{
    public class DriverMethods
    {
        public static IWebDriver GetDriver()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
