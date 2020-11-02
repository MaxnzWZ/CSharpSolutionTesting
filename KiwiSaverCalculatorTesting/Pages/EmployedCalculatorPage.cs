using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace KiwiSaverCalculatorTesting.Pages
{
    class EmployedCalculatorPage: BasePage
    {
        // info icons' locators
        public IWebElement EleCurrentAgeInfoIcon => Driver.FindElements(By.CssSelector("i.icon"))[0];
        public IWebElement EleEmploymentStatusInfoIcon => Driver.FindElements(By.CssSelector("i.icon"))[1];
        public IWebElement EleSalaryPerYearInfoIcon => Driver.FindElements(By.CssSelector("i.icon"))[2];
        public IWebElement EleKiwiSaverMemberContributionInfoIcon => Driver.FindElements(By.CssSelector("i.icon"))[3];
        public IWebElement EleCurrentKiwiSaverBalanceInfoIcon => Driver.FindElements(By.CssSelector("i.icon"))[4];
        public IWebElement EleVoluntaryConditionsInfoIcon => Driver.FindElements(By.CssSelector("i.icon"))[5];
        public IWebElement EleRiskProfileInfoIcon => Driver.FindElements(By.CssSelector("i.icon"))[6];
        public IWebElement EleSavingGoalAtRetirementInfoIcon => Driver.FindElements(By.CssSelector("i.icon"))[7];

        // icon info locators
        public IWebElement EleCurrentAgeInfo => Driver.FindElements(By.CssSelector("div.field-message.message-info"))[0];
        public IWebElement EleEmploymentStatusInfo => Driver.FindElements(By.CssSelector("div.field-message.message-info"))[1];
        public IWebElement EleSalaryPerYearInfo => Driver.FindElements(By.CssSelector("div.field-message.message-info"))[2];
        public IWebElement EleKiwiSaverMemberContributionInfo => Driver.FindElements(By.CssSelector("div.field-message.message-info"))[3];
        public IWebElement EleCurrentKiwiSaverBalanceInfo => Driver.FindElements(By.CssSelector("div.field-message.message-info"))[4];
        public IWebElement EleVoluntaryConditionsInfo => Driver.FindElements(By.CssSelector("div.field-message.message-info"))[5];
        public IWebElement EleRiskProfileInfo => Driver.FindElements(By.CssSelector("div.field-message.message-info"))[6];
        public IWebElement EleSavingGoalAtRetirementInfo => Driver.FindElements(By.CssSelector("div.field-message.message-info"))[7];

        public IWebElement EleLinkKiwiSaverRiskProfile => Driver.FindElement(By.LinkText("KiwiSaver Risk Profiler"));
        public IWebElement EleLinkKiwiSortedRetirementPlanner => Driver.FindElement(By.LinkText("Sorted Retirement Planner"));

        // input type locators
        public IWebElement EleInputCurrentAge => Driver.FindElements(By.CssSelector("input[type='text']"))[0];
        public IWebElement EleInputSalaryPerYear => Driver.FindElements(By.CssSelector("input[type='text']"))[1];
        public IWebElement EleInputCurrentKiwiSaverBalance => Driver.FindElements(By.CssSelector("input[type='text']"))[2];
        public IWebElement EleInputVoluntaryContributions => Driver.FindElements(By.CssSelector("input[type='text']"))[3];
        public IWebElement EleInputSavingsGoalAtRetirement => Driver.FindElements(By.CssSelector("input[type='text']"))[4];

        // kiwi saver member contribution radio options
        public IWebElement EleOptionKiwiSaverMemberContribution3Percent => Driver.FindElement(By.CssSelector("#radio-option-04C"));
        public IWebElement EleOptionKiwiSaverMemberContribution4Percent => Driver.FindElement(By.CssSelector("#radio-option-04F"));
        public IWebElement EleOptionKiwiSaverMemberContribution6Percent => Driver.FindElement(By.CssSelector("#radio-option-04I"));
        public IWebElement EleOptionKiwiSaverMemberContribution8Percent => Driver.FindElement(By.CssSelector("#radio-option-04L"));
        public IWebElement EleOptionKiwiSaverMemberContribution10Percent => Driver.FindElement(By.CssSelector("#radio-option-04O"));

        // risk profile radio options
        public IWebElement EleOptionRiskProfileDefensive => Driver.FindElement(By.CssSelector("#radio-option-013"));
        public IWebElement EleOptionRiskProfileConservative => Driver.FindElement(By.CssSelector("#radio-option-016"));
        public IWebElement EleOptionRiskProfileBalanced => Driver.FindElement(By.CssSelector("#radio-option-019"));
        public IWebElement EleOptionRiskProfileGrowth => Driver.FindElement(By.CssSelector("#radio-option-01C"));

        public IWebElement EleButtonViewKiwiSaverRetirementProjections => Driver.FindElement(By.CssSelector("button.btn-results-reveal.btn-has-chevron"));

        public IWebElement EleResultValue => Driver.FindElement(By.CssSelector("span.result-value.result-currency"));
    }
}
