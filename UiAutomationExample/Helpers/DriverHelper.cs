using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UiAutomationExample.Helpers
{
    public class DriverHelper
    {
        private IWebDriver driver;
        public DriverHelper()
        {
        }

        public IWebDriver CreateDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
