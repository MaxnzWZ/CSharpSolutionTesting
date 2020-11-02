using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KiwiSaverCalculatorTesting.Utils
{
    public class Utilities
    {
        // Perform the click operation in iframe
        public void ClickInIframe(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }

        // Take screenshot with selenium
        public static void TakeScreenshot(IWebDriver driver)
        {
            // Create output directory of screenshots
            string path = @"..\..\..\Screenshots\";

            try
            {
                // Check whether the directory exists.
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                }

                // Create the directory if it does not exist
                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            // Specify the target directory to store the screenshots
            string targetPath = @"..\..\..\Screenshots\";
            // Spedify the screenshot file name with timestamp
            DateTime time = DateTime.Now;
            string dateToday = "_date_" + time.ToString("yyyy-MM-dd") + "_time_" + time.ToString("HH-mm-ss");
            string screenShotFileName = "Failed" + dateToday + ".png";
            // Specify the target screenshot file name
            string targetScreenshotFileName = $"{targetPath}{screenShotFileName}";
            // Take the screenshot and save it to file
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotFile = Path.Combine(TestContext.CurrentContext.WorkDirectory, screenShotFileName);
            screenshot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Png);

            // Add the screenshot file to NUnit results
            TestContext.AddTestAttachment(screenshotFile, "My Screenshot");
            // Copy the screenshot file to target directory with the specified name
            File.Copy(screenshotFile, targetScreenshotFileName, true);

        }
    }
}
