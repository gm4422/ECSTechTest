using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace qaTechTests.Helpers
{
    internal class Navigate
    {
        private IWebDriver driver = DriverManager.Driver;
        private readonly string _baseUrl = ConfigurationManager.AppSettings["BaseUrl"];

        public void NavigateToAppMainPage()
        {
            driver.Navigate().GoToUrl(_baseUrl);
        }
    }
}