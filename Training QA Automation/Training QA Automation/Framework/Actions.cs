using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Training_QA_Automation.Framework
{
    class Actions
    {
      
        public static void WaitForPageToFinishLoading(IWebDriver driver)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(
                d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

        }

        /// <summary>
        /// Pass in a driver and an element in order to click on it with the mouse.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        public static void ClickOn(IWebDriver driver, IWebElement element)
        {
            WaitForPageToFinishLoading(driver);
            try
            {
                element.Click();
                WaitForPageToFinishLoading(driver);
            }
            catch
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].click();", element);
                WaitForPageToFinishLoading(driver);
            }
        }

        /// <summary>
        /// Pass in a driver, and string value in order to type it as though typing with a keyboard.
        /// </summary>
        public static void Type(IWebDriver driver, IWebElement element, string value)
        {
            WaitForPageToFinishLoading(driver);
            element.SendKeys(value);
        }
    }
}
