using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using qaTechTests.Helpers;
using TechTalk.SpecFlow;

namespace qaTechTests.Hooks
{
    [Binding]
    public class Hooks
    {
        private bool _isInvoked = false;

        //Here using MsTest textContext, so I can add the captured screenshots to the actual test.
        private TestContext _testContext;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            new AppHelper().StartReactApp();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            new DriverManager().SetDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                try
                {
                    //Always have a problem with capturing a the full screenshot, so here using javascript to capture screenshot
                    new TakeScreenShot().CaptureFullScreen(_testContext);
                    Console.WriteLine("Screenshot taken and saved to context");
                }
                catch (Exception e)
                {
                    try
                    {
                        //Using the native windows now to capture as the javascript one failed.
                        new TakeScreenShot().CaptureDesktop(_testContext);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Capture Desktop failed and could not save to context");
                        Console.WriteLine(ex.Message);
                    }
                }

                new DriverManager().ExitDriver();
            }
        }

        [BeforeStep]
        public void BeforeSteps()
        {
            //This is too add a TestContext to all Steps
            if (_isInvoked) return;
            _isInvoked = true;
            _testContext = ScenarioContext.Current.ScenarioContainer.Resolve<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            new DriverManager().ExitDriver();

            new AppHelper().EndApp();
        }
    }
}