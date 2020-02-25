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

            IWebElement element = wait.Until<IWebElement>(condition => {
                try
                {
                    IWebElement tempElement = _driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                catch
                {
                    return null;
                }
            });

            try
            {
                element.Clear();
                element.SendKeys(valueToType);
            }
            catch (NullReferenceException)
            {
                Assert.Fail($"Exception occurred in SeleniumHelper.SendKeys(): element located by {by.ToString()} could not be located within 10 seconds.");
            }
        }

        public void Click(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Constants.DEFAULT_TIMEOUT));

            IWebElement element = wait.Until<IWebElement>(condition => {
                try
                {
                    IWebElement tempElement = _driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                catch
                {
                    return null;
                }
            });

            try
            {
                element.Click();
            }
            catch (NullReferenceException)
            {
                Assert.Fail($"Exception occurred in SeleniumHelper.Click(): element located by {by.ToString()} could not be located within 10 seconds.");
            }
        }

        public bool CheckElementIsVisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Constants.DEFAULT_TIMEOUT));

            return wait.Until(condition => {
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

            IWebElement element = wait.Until<IWebElement>(condition => {
                try
                {
                    IWebElement tempElement = _driver.FindElement(by);
                    return tempElement.Displayed ? tempElement : null;
                }
                catch
                {
                    return null;
                }
            });

            try
            {
                returnValue = element.Text;
            }
            catch (NullReferenceException)
            {
                Assert.Fail($"Exception occurred in SeleniumHelper.Click(): element located by {by.ToString()} could not be located within 10 seconds.");
            }

            return returnValue;
        }
    }
}
