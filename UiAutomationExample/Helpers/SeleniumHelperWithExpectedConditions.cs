using System;
using OpenQA.Selenium;
using UiAutomationExample.Globals;
using WebDriverWait = OpenQA.Selenium.Support.UI.WebDriverWait;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;

namespace UiAutomationExample.Helpers
{
    public class SeleniumHelperWithExpectedConditions
    {
        private IWebDriver _driver;

        public SeleniumHelperWithExpectedConditions(IWebDriver driver)
        {
            _driver = driver;
        }

        public void SendKeys(By by, string valueToType)
        {
            try
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(Constants.DEFAULT_TIMEOUT)).Until(ExpectedConditions.ElementToBeClickable(by));
                _driver.FindElement(by).Clear();
                _driver.FindElement(by).SendKeys(valueToType);
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                Assert.Fail($"Exception occurred in SeleniumHelper.SendKeys(): element located by {by.ToString()} could not be located within {Constants.DEFAULT_TIMEOUT} seconds.");
            }
        }

        public void Click(By by)
        {
            try
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(Constants.DEFAULT_TIMEOUT)).Until(ExpectedConditions.ElementToBeClickable(by));
                _driver.FindElement(by).Click();
            }
            catch (Exception ex) when (ex is WebDriverTimeoutException || ex is NoSuchElementException)
            {
                Assert.Fail($"Exception occurred in SeleniumHelper.Click(): element located by {by.ToString()} could not be located within {Constants.DEFAULT_TIMEOUT} seconds.");
            }
        }

        public bool CheckElementIsVisible(By by)
        {
            try
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(Constants.DEFAULT_TIMEOUT)).Until(ExpectedConditions.ElementIsVisible((by)));
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                return false;
            }
            return true;
        }

        public string GetElementText(By by)
        {
            string returnValue = "";

            try
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(Constants.DEFAULT_TIMEOUT)).Until(ExpectedConditions.ElementIsVisible(by));
                returnValue = _driver.FindElement(by).Text;
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
            {
                Assert.Fail($"Exception occurred in SeleniumHelper.GetElementText(): element located by {by.ToString()} could not be located within {Constants.DEFAULT_TIMEOUT} seconds.");
            }

            return returnValue;
        }
    }
}
