using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using qaTechTests.Helpers;

namespace qaTechTests.Pages
{
    internal class BasePage
    {
        protected IWebDriver Driver = DriverManager.Driver;
        protected WebDriverWait Wait = new WebDriverWait(DriverManager.Driver, TimeSpan.FromSeconds(30));

        public BasePage()
        {
            Wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException), typeof(StaleElementReferenceException));
        }
    }
}