using KiwiSaverCalculatorTesting.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace KiwiSaverCalculatorTesting
{
    //[TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    public class HomePagePathCheckTest<TWebDriver> : BasePage where TWebDriver : IWebDriver, new()
    {
        [SetUp]
        public void Setup()
        {
            Driver = new TWebDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            Driver.Navigate().GoToUrl(baseUrl);
        }

        [Test]
        public void PathCheck()
        {
            UITest(() =>
            {
                // Check the path to Calculator page in home page
                HomePage homePage = new HomePage();
                homePage.EleKiwiSaver.Click();

                // Wait Risk Profile Retirement Calculator to display in side navigation
                var wait1 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait1.Until(driver => homePage.EleRiskProfileRetirementCalculatorIcon.Displayed);

                Assert.That(homePage.EleMenuTitle.Displayed, Is.True, "The element of Risk profile and retirement calculator is not found");

                // Find the side navigation link of KiwiSaver Retirement Calculator and click it to enter Calculator
                homePage.EleRiskProfileRetirementCalculatorIcon.Click();

                Assert.That(homePage.EleKiwiSaverRetirementCalculator.Displayed, Is.True, "The element of KiwiSaver Retirement Calculator is not found");

                homePage.EleKiwiSaverRetirementCalculator.Click();

                Assert.That(Driver.Url, Is.EqualTo("https://www.westpac.co.nz/kiwisaver/calculators/kiwisaver-calculator/"), "The url is not the expected url");
            });
        }

        [TearDown]
        public void Close()
        {
            Driver.Quit();
        }
    }
}