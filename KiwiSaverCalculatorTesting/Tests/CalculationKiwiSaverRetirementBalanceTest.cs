using KiwiSaverCalculatorTesting.Pages;
using KiwiSaverCalculatorTesting.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace KiwiSaverCalculatorTesting.Tests
{
    [TestFixture(typeof(ChromeDriver))]
    //[TestFixture(typeof(FirefoxDriver))]
    class CalculationKiwiSaverRetirementBalanceTest<TWebDriver> : BasePage where TWebDriver: IWebDriver, new()
    {
        CalculatorHomePage calculatorHomePage = new CalculatorHomePage();
        EmployedCalculatorPage employedCalculatorPage = new EmployedCalculatorPage();
        SelfEmployedCalculatorPage selfEmployedCalculatorPage = new SelfEmployedCalculatorPage();
        NotEmployedCalculatorPage notEmployedCalculatorPage = new NotEmployedCalculatorPage();
        Utilities utils = new Utilities();

        [SetUp]
        public void Setup()
        {
            // Open Kiwi Saver Calculator
            Driver = new TWebDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl($"{baseUrl}/kiwisaver/calculators/kiwisaver-calculator/");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var eleIframe = calculatorHomePage.IFrame;

            Thread.Sleep(3000);
            Driver.SwitchTo().Frame(eleIframe);

            var wait1 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait1.Until(driver => calculatorHomePage.LabelCurrentAge.Displayed);
        }

        [Test]
        public void EmployedCustomerCalculationTest()
        {
            UITest(() =>
            {
                // Open the calculator for Employed customers 
                utils.ClickInIframe(Driver, calculatorHomePage.EleDropDownArrowEmploymentStatus);

                Thread.Sleep(3000);
                utils.ClickInIframe(Driver, calculatorHomePage.EleEmploymentStatusEmployedOption);

                var wait2 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait2.Until(driver => employedCalculatorPage.EleInputSalaryPerYear.Displayed);

                // Make sure the calculator button is not enabled before filling the related fields
                Assert.IsFalse(employedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Enabled);

                // Fill the fields for the calculation
                employedCalculatorPage.EleInputCurrentAge.SendKeys("30");
                employedCalculatorPage.EleInputSalaryPerYear.SendKeys("82000");
                employedCalculatorPage.EleOptionKiwiSaverMemberContribution4Percent.Click();
                employedCalculatorPage.EleOptionRiskProfileDefensive.Click();

                var wait3 = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                wait3.Until(driver => employedCalculatorPage.EleResultValue.Enabled);

                // Make sure the calculator button is enabled after the fields filling
                Assert.IsTrue(employedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Enabled);

                // Click the calculator button to calculator
                employedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Click();

                // Check whether the calculator button will disappear after clicking the calculator button
                Assert.IsFalse(employedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Displayed);

                // Check whether there is calculated value 
                Assert.IsTrue(employedCalculatorPage.EleResultValue.Displayed);

                // Check whether the calcuted value is as expected
                Assert.IsTrue(employedCalculatorPage.EleResultValue.Text.Contains("436,365"));
            });
        }

        [Test]
        public void SelfEmployedCustomerCalculationTest()
        {
            UITest(() =>
            {
                // Calculation for self-employed customers
                utils.ClickInIframe(Driver, calculatorHomePage.EleDropDownArrowEmploymentStatus);

                Thread.Sleep(3000);
                utils.ClickInIframe(Driver, calculatorHomePage.EleEmploymentStatusSelfEmployedOption);

                Assert.IsFalse(selfEmployedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Enabled);

                selfEmployedCalculatorPage.EleInputCurrentAge.SendKeys("45");
                selfEmployedCalculatorPage.EleInputCurrentKiwiSaverBalance.SendKeys("100000");
                selfEmployedCalculatorPage.EleInputVoluntaryContributions.SendKeys("90");

                utils.ClickInIframe(Driver, calculatorHomePage.EleDropDownArrowVoluntaryConditionsFrequency);

                Thread.Sleep(3000);
                utils.ClickInIframe(Driver, calculatorHomePage.EleVoluntaryContributionsFortnightlyOption);

                selfEmployedCalculatorPage.EleOptionRiskProfileConservative.Click();

                selfEmployedCalculatorPage.EleInputSavingsGoalAtRetirement.SendKeys("290000");

                var wait3 = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                wait3.Until(driver => employedCalculatorPage.EleResultValue.Enabled);

                Assert.IsTrue(selfEmployedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Enabled);

                selfEmployedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Click();

                Assert.IsFalse(selfEmployedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Displayed);

                Assert.IsTrue(selfEmployedCalculatorPage.EleResultValue.Displayed);

                Assert.IsTrue(selfEmployedCalculatorPage.EleResultValue.Text.Contains("259,581"));
            });

        }

        [Test]
        public void NotEmployedCustomerCalculationTest()
        {
            UITest(() =>
            {
                // Calculation for not-employed customers
                utils.ClickInIframe(Driver, calculatorHomePage.EleDropDownArrowEmploymentStatus);

                Thread.Sleep(3000);
                utils.ClickInIframe(Driver, calculatorHomePage.EleEmploymentStatusNotEmployedOption);

                Assert.IsFalse(notEmployedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Enabled);

                notEmployedCalculatorPage.EleInputCurrentAge.SendKeys("55");
                notEmployedCalculatorPage.EleInputCurrentKiwiSaverBalance.SendKeys("140000");
                notEmployedCalculatorPage.EleInputVoluntaryContributions.SendKeys("10");

                utils.ClickInIframe(Driver, calculatorHomePage.EleDropDownArrowVoluntaryConditionsFrequency);

                Thread.Sleep(3000);
                utils.ClickInIframe(Driver, calculatorHomePage.EleVoluntaryContributionsAnnuallyOption);

                notEmployedCalculatorPage.EleOptionRiskProfileBalanced.Click();

                notEmployedCalculatorPage.EleInputSavingsGoalAtRetirement.SendKeys("200000");

                var wait3 = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
                wait3.Until(driver => employedCalculatorPage.EleResultValue.Enabled);

                Assert.IsTrue(notEmployedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Enabled);

                notEmployedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Click();

                Assert.IsFalse(notEmployedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Displayed);

                Assert.IsTrue(notEmployedCalculatorPage.EleResultValue.Displayed);

                Assert.IsTrue(notEmployedCalculatorPage.EleResultValue.Text.Contains("197,679"));
            });
        }

        [TearDown]
        public void Close()
        {
            Driver.Quit();
        }
    }
}
