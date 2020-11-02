using KiwiSaverCalculatorTesting.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace KiwiSaverCalculatorTesting.Pages
{
    class CalculatorHomePage: BasePage
    {
        // iframe locator
        public IWebElement IFrame => Driver.FindElement(By.XPath("//*[@id='calculator-embed']/iframe"));

        public IWebElement LabelCurrentAge => Driver.FindElements(By.XPath("//*[text()='Current age']"))[0];


        // Employment Dropdown options
        public IWebElement EleDropDownArrowEmploymentStatus => Driver.FindElements(By.CssSelector("i.dropdown-arrow"))[0];
        public IWebElement EleEmploymentStatusEmployedOption => Driver.FindElement(By.CssSelector("li[value='employed']"));
        public IWebElement EleEmploymentStatusSelfEmployedOption => Driver.FindElement(By.CssSelector("li[value='self-employed']"));
        public IWebElement EleEmploymentStatusNotEmployedOption => Driver.FindElement(By.CssSelector("li[value='not-employed']"));

        // Frequency Dropdown options
        public IWebElement EleDropDownArrowVoluntaryConditionsFrequency => Driver.FindElements(By.CssSelector("i.dropdown-arrow"))[1];
        public IWebElement EleVoluntaryContributionsWeeklyOption => Driver.FindElement(By.CssSelector("li[value='week']"));
        public IWebElement EleVoluntaryContributionsFortnightlyOption => Driver.FindElement(By.CssSelector("li[value='fortnight']"));
        public IWebElement EleVoluntaryContributionsMonthlyOption => Driver.FindElement(By.CssSelector("li[value='month']"));
        public IWebElement EleVoluntaryContributionsAnnuallyOption => Driver.FindElement(By.CssSelector("li[value='year']"));
    }
}
