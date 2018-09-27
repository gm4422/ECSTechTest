using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace qaTechTests.Pages
{
    internal class WelcomePage : BasePage
    {
        //So added
        private IWebElement renderChallengeButton => Driver.FindElement(By.CssSelector("[data-test-id=render-challenge]"));

        public WelcomePage()
        {
            Wait.Until(x => renderChallengeButton.Displayed && renderChallengeButton.Enabled);
        }

        public ArrayChallengePage GoToRender()
        {
            renderChallengeButton.Click();
            return new ArrayChallengePage();
        }
    }
}