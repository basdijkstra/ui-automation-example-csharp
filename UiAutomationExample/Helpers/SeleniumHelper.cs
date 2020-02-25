using System;
using OpenQA.Selenium;
using UiAutomationExample.Globals;
using WebDriverWait = OpenQA.Selenium.Support.UI.WebDriverWait;
using NUnit.Framework;

namespace UiAutomationExample.Helpers
{
    public class SeleniumHelper
    {
        private IWebDriver _driver;

        public SeleniumHelper(IWebDriver driver)
        {
            _driver = driver;
        }

        public void SendKeys(By by, string valueToType)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Constants.DEFAULT_TIMEOUT));
            
            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = _driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
                myElement.Clear();
                myElement.SendKeys(valueToType);
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in SendKeys(): element located by {by.ToString()} not visible and enabled within {Constants.DEFAULT_TIMEOUT} seconds.");
            }
        }

        public void Click(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Constants.DEFAULT_TIMEOUT));

            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = _driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
                myElement.Click();
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in Click(): element located by {by.ToString()} not visible and enabled within {Constants.DEFAULT_TIMEOUT} seconds.");
            }
        }

        public bool CheckElementIsVisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Constants.DEFAULT_TIMEOUT));

            return wait.Until(driver => {
                try
                {
                    IWebElement tempElement = _driver.FindElement(by);
                    return tempElement.Displayed;
                }
                catch
                {
                    return false;
                }
            });
        }
        
        public string GetElementText(By by)
        {
            string returnValue = "";

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Constants.DEFAULT_TIMEOUT));

            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = _driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
                returnValue = myElement.Text;
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in GetElementText(): element located by {by.ToString()} not visible and enabled within {Constants.DEFAULT_TIMEOUT} seconds.");
            }

            return returnValue;
        }
    }
}
