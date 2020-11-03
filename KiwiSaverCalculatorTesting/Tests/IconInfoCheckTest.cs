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
    //[TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    class IconInfoCheckTest<TWebDriver> : BasePage where TWebDriver : IWebDriver, new()
    {
        CalculatorHomePage calculatorHomePage = new CalculatorHomePage();
        EmployedCalculatorPage employedCalculatorPage = new EmployedCalculatorPage();
        Utilities utils = new Utilities();
        [SetUp]
        public void Setup()
        {
            Driver = new TWebDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl($"{baseUrl}/kiwisaver/calculators/kiwisaver-calculator/");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var eleIframe = calculatorHomePage.IFrame;

            Thread.Sleep(2000);
            Driver.SwitchTo().Frame(eleIframe);

            var wait1 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait1.Until(driver => calculatorHomePage.LabelCurrentAge.Displayed);

            Thread.Sleep(2000);
            utils.ClickInIframe(Driver, calculatorHomePage.EleDropDownArrowEmploymentStatus);

            Thread.Sleep(2000);
            utils.ClickInIframe(Driver, calculatorHomePage.EleEmploymentStatusEmployedOption);

            var wait2 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait2.Until(driver => employedCalculatorPage.EleOptionKiwiSaverMemberContribution3Percent.Displayed);
        }



        [Test]
        public void CurrentAgeInfoCheck()
        {
            UITest(() =>
            {
                // The actual current age info displayed is not as expected. 
                // The test case should fail as expected
                String expectedCurrentAgeInfo = "This calculator has an age limit of 64 years old as you need to be under the age of 65 to join KiwiSaver.";
                utils.ClickInIframe(Driver, employedCalculatorPage.EleCurrentAgeInfoIcon);

                // Check whether info is equal to the expected value
                Assert.That(employedCalculatorPage.EleCurrentAgeInfo.Text, Is.EqualTo(expectedCurrentAgeInfo));

                // Check whether there is only corresponding info displayed after click the info icon
                Assert.IsTrue(employedCalculatorPage.EleCurrentAgeInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleEmploymentStatusInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleSalaryPerYearInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleKiwiSaverMemberContributionInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleCurrentKiwiSaverBalanceInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleVoluntaryConditionsInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleRiskProfileInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleSavingGoalAtRetirementInfo.Displayed);
            });
        }

        [Test]
        public void EmploymentStatusInfoCheck()
        {
            UITest(() =>
            {
                String expectedEmploymentStatusInfo = "If you are earning a salary or wage, select ‘Employed’. Your employer contributions will be automatically calculated at a rate of 3% of your before-tax salary or wages. You can also select ‘Self-employed’ or ‘Not employed’ and then enter below (in the Voluntary contributions field), the amount and frequency of any contributions that you wish to make.";
                utils.ClickInIframe(Driver, employedCalculatorPage.EleEmploymentStatusInfoIcon);
                Assert.That(employedCalculatorPage.EleEmploymentStatusInfo.Text, Is.EqualTo(expectedEmploymentStatusInfo));

                Assert.IsFalse(employedCalculatorPage.EleCurrentAgeInfo.Displayed);
                Assert.IsTrue(employedCalculatorPage.EleEmploymentStatusInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleSalaryPerYearInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleKiwiSaverMemberContributionInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleCurrentKiwiSaverBalanceInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleVoluntaryConditionsInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleRiskProfileInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleSavingGoalAtRetirementInfo.Displayed);
            });
        }

        [Test]
        public void SalaryPerYearInfoCheck()
        {
            UITest(() =>
            {
                String expectedSalaryPerYearInfo = "Only include your total annual income that is paid to you by your employer(s). Other income sources such as rental income or dividends should not be included.";
                utils.ClickInIframe(Driver, employedCalculatorPage.EleSalaryPerYearInfoIcon);
                Assert.That(employedCalculatorPage.EleSalaryPerYearInfo.Text, Is.EqualTo(expectedSalaryPerYearInfo));

                Assert.IsFalse(employedCalculatorPage.EleCurrentAgeInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleEmploymentStatusInfo.Displayed);
                Assert.IsTrue(employedCalculatorPage.EleSalaryPerYearInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleKiwiSaverMemberContributionInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleCurrentKiwiSaverBalanceInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleVoluntaryConditionsInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleRiskProfileInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleSavingGoalAtRetirementInfo.Displayed);
            });

        }

        [Test]
        public void KiwiSaverMemberContributionInfoCheck()
        {
            UITest(() =>
            {
                String expectedKiwiSaverMemberContributionInfo = "You can choose to contribute a regular amount equal to 3%, 4%, 6%, 8% or 10% of your before-tax salary or wage. If you do not select a rate, your rate will be 3%.";
                utils.ClickInIframe(Driver, employedCalculatorPage.EleKiwiSaverMemberContributionInfoIcon);
                Assert.That(employedCalculatorPage.EleKiwiSaverMemberContributionInfo.Text, Is.EqualTo(expectedKiwiSaverMemberContributionInfo));

                Assert.IsFalse(employedCalculatorPage.EleCurrentAgeInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleEmploymentStatusInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleSalaryPerYearInfo.Displayed);
                Assert.IsTrue(employedCalculatorPage.EleKiwiSaverMemberContributionInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleCurrentKiwiSaverBalanceInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleVoluntaryConditionsInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleRiskProfileInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleSavingGoalAtRetirementInfo.Displayed);
            });
        }

        [Test]
        public void CurrentKiwiSaverBalanceInfoCheck()
        {
            UITest(() =>
            {
                String expectedCurrentKiwiSaverBalanceInfo = "If you do not have a KiwiSaver account, then leave this field blank.";
                utils.ClickInIframe(Driver, employedCalculatorPage.EleCurrentKiwiSaverBalanceInfoIcon);
                Assert.That(employedCalculatorPage.EleCurrentKiwiSaverBalanceInfo.Text, Is.EqualTo(expectedCurrentKiwiSaverBalanceInfo));

                Assert.IsFalse(employedCalculatorPage.EleCurrentAgeInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleEmploymentStatusInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleSalaryPerYearInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleKiwiSaverMemberContributionInfo.Displayed);
                Assert.IsTrue(employedCalculatorPage.EleCurrentKiwiSaverBalanceInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleVoluntaryConditionsInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleRiskProfileInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleSavingGoalAtRetirementInfo.Displayed);
            });
        }

        [Test]
        public void VoluntaryConditionsInfoCheck()
        {
            UITest(() =>
            {
                String expectedVoluntaryConditionsInfo = "If you are 'Self-Employed' or 'Not employed', you can make direct contributions to your KiwiSaver account. If you are 'Employed', you can make voluntary contributions in addition to your regular employee contributions.";
                utils.ClickInIframe(Driver, employedCalculatorPage.EleVoluntaryConditionsInfoIcon);
                Assert.That(employedCalculatorPage.EleVoluntaryConditionsInfo.Text, Is.EqualTo(expectedVoluntaryConditionsInfo));

                Assert.IsFalse(employedCalculatorPage.EleCurrentAgeInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleEmploymentStatusInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleSalaryPerYearInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleKiwiSaverMemberContributionInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleCurrentKiwiSaverBalanceInfo.Displayed);
                Assert.IsTrue(employedCalculatorPage.EleVoluntaryConditionsInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleRiskProfileInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleSavingGoalAtRetirementInfo.Displayed);
            });
        }

        [Test]
        public void RiskProfileInfoCheck()
        {
            UITest(() =>
            {
                String expectedRiskProfileInfo1 = "The risk profile affects your potential investment returns:";
                String expectedRiskProfileInfo2 = "Low risk investments usually contain mostly income assets. Generally, investments of this nature can be expected to deliver modest but more consistent returns. They are less likely to go up and down, but will usually provide lower returns over the long term.";
                String expectedRiskProfileInfo3 = "Medium risk investments are spread more evenly between income assets and growth assets. Generally, these types of investments can be expected to provide moderate levels of returns with moderate levels of investment risk. Returns will vary and may be low or negative in some years.";
                String expectedRiskProfileInfo4 = "High risk investments usually contain mostly growth assets. Investments with more exposure to growth assets have the potential for higher long-term returns, but they are more likely to go up and down in the short term and will experience periods of negative returns.";
                String expectedRiskProfileInfo5 = "You can also use our ";
                String expectedRiskProfileInfo6 = "KiwiSaver Risk Profiler";
                String expectedRiskProfileInfo7 = " to help determine your tolerence to risk.";

                utils.ClickInIframe(Driver, employedCalculatorPage.EleRiskProfileInfoIcon);
                Assert.IsTrue(Driver.PageSource.Contains(expectedRiskProfileInfo1));
                Assert.IsTrue(Driver.PageSource.Contains(expectedRiskProfileInfo2));
                Assert.IsTrue(Driver.PageSource.Contains(expectedRiskProfileInfo3));
                Assert.IsTrue(Driver.PageSource.Contains(expectedRiskProfileInfo4));
                Assert.IsTrue(Driver.PageSource.Contains(expectedRiskProfileInfo5));
                Assert.IsTrue(Driver.PageSource.Contains(expectedRiskProfileInfo6));
                Assert.IsTrue(Driver.PageSource.Contains(expectedRiskProfileInfo7));

                Assert.IsFalse(employedCalculatorPage.EleCurrentAgeInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleEmploymentStatusInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleSalaryPerYearInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleKiwiSaverMemberContributionInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleCurrentKiwiSaverBalanceInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleVoluntaryConditionsInfo.Displayed);
                Assert.IsTrue(employedCalculatorPage.EleRiskProfileInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleSavingGoalAtRetirementInfo.Displayed);

                Assert.IsTrue(employedCalculatorPage.EleLinkKiwiSaverRiskProfile.Displayed);
            });
        }

        [Test]
        public void SavingGoalAtRetirementInfoCheck()
        {
            UITest(() =>
            {
                String expectedSavingGoalAtRetirementInfo1 = "Enter the amount you would like to have saved when you reach your intended retirement age. If you aren’t sure what this amount is, you can leave it blank or use the";
                String expectedSavingGoalAtRetirementInfo2 = "Sorted Retirement Planner";

                utils.ClickInIframe(Driver, employedCalculatorPage.EleSavingGoalAtRetirementInfoIcon);
                Assert.IsTrue(Driver.PageSource.Contains(expectedSavingGoalAtRetirementInfo1));
                Assert.IsTrue(Driver.PageSource.Contains(expectedSavingGoalAtRetirementInfo2));

                Assert.IsFalse(employedCalculatorPage.EleCurrentAgeInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleEmploymentStatusInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleSalaryPerYearInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleKiwiSaverMemberContributionInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleCurrentKiwiSaverBalanceInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleVoluntaryConditionsInfo.Displayed);
                Assert.IsFalse(employedCalculatorPage.EleRiskProfileInfo.Displayed);
                Assert.IsTrue(employedCalculatorPage.EleSavingGoalAtRetirementInfo.Displayed);

                Assert.IsTrue(employedCalculatorPage.EleLinkKiwiSortedRetirementPlanner.Displayed);
            });
        }

        [TearDown]
        public void Close()
        {
            Driver.Quit();
        }

    }

}
