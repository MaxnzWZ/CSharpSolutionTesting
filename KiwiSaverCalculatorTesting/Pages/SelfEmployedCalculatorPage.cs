using KiwiSaverCalculatorTesting.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace KiwiSaverCalculatorTesting.Pages
{
    class SelfEmployedCalculatorPage: BasePage
    {
        public IWebElement EleInputCurrentAge => Driver.FindElements(By.CssSelector("input[type='text']"))[0];
        public IWebElement EleInputCurrentKiwiSaverBalance => Driver.FindElements(By.CssSelector("input[type='text']"))[1];
        public IWebElement EleInputVoluntaryContributions => Driver.FindElements(By.CssSelector("input[type='text']"))[2];
        public IWebElement EleInputSavingsGoalAtRetirement => Driver.FindElements(By.CssSelector("input[type='text']"))[3];

        public IWebElement EleOptionRiskProfileDefensive => Driver.FindElement(By.CssSelector("#radio-option-013"));
        public IWebElement EleOptionRiskProfileConservative => Driver.FindElement(By.CssSelector("#radio-option-016"));
        public IWebElement EleOptionRiskProfileBalanced => Driver.FindElement(By.CssSelector("#radio-option-019"));
        public IWebElement EleOptionRiskProfileGrowth => Driver.FindElement(By.CssSelector("#radio-option-01C"));

        public IWebElement EleButtonViewKiwiSaverRetirementProjections => Driver.GetElementAndScrollTo(By.CssSelector("button.btn-results-reveal.btn-has-chevron"));

        public IWebElement EleResultValue => Driver.GetElementAndScrollTo(By.CssSelector("span.result-value.result-currency"));
    }
}
