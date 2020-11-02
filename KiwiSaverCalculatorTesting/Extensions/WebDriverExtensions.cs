using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace KiwiSaverCalculatorTesting.Extensions
{
    public static class WebDriverExtensions
    {
        // Locate element within timeout value
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        // Scroll to the located element
        public static IWebElement GetElementAndScrollTo(this IWebDriver driver, By by)
        {
            var js = (IJavaScriptExecutor)driver;
            try
            {
                var element = driver.FindElement(by);
                if (element.Location.Y > 200)
                {
                    js.ExecuteScript($"window.scrollTo({0}, {element.Location.Y - 200 })");
                }
                return element;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
