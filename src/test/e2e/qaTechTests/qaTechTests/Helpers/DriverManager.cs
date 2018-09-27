using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

namespace qaTechTests.Helpers
{
    internal class DriverManager
    {
        //Making this static as I have found that having this start up once for the whole test run improves performance.
        //Obviously for any tests that do require a clean session this driver can be closed down and re-opened.
        public static IWebDriver Driver = null;

        public void SetDriver()
        {
            if (Driver == null)
            {
                switch (ConfigurationManager.AppSettings["Browser"].ToLower())
                {
                    case "ie":
                        var ieoptions = new InternetExplorerOptions();
                        ieoptions.EnsureCleanSession = true;
                        Driver = new InternetExplorerDriver(ieoptions);
                        break;

                    case "chrome":
                        Driver = new ChromeDriver();
                        break;

                    default:
                        throw new Exception("BrowserType Unsupported");
                }

                Driver.Manage().Window.Maximize();
                Driver.Manage().Cookies.DeleteAllCookies();
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }
        }

        public void ExitDriver()
        {
            if (Driver != null)
            {
                Console.WriteLine("Exiting Driver ......");
                Driver.Quit();
                Driver.Dispose();
                Driver = null;
            }
        }
    }
}