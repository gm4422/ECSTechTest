using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssert;
using qaTechTests.Helpers;
using qaTechTests.Pages;
using TechTalk.SpecFlow;

namespace qaTechTests.Steps
{
    [Binding]
    public sealed class NavigateToSection
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [Given(@"I have the ECS Digital Tech app open")]
        public void GivenIHaveTheECSDigitalTechAppOpen()
        {
            new Navigate().NavigateToAppMainPage();
        }

        [When(@"I press the render challenge button")]
        public void WhenIPressTheRenderChallengeButton()
        {
            var welcomepage = new WelcomePage();
            welcomepage.GoToRender();
        }

        [Then(@"I should be taken to the Arrays Challenge section")]
        public void ThenIShouldBeTakenToTheArraysChallengeSection()
        {
            var welcomePageTitle = new ArrayChallengePage().GetSectionTitle();

            welcomePageTitle.ShouldBeEqualTo("Arrays Challenge");
        }
    }
}