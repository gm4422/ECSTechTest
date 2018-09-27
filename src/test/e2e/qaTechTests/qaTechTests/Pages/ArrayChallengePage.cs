using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using qaTechTests.Helpers;

namespace qaTechTests.Pages
{
    internal class ArrayChallengePage : BasePage
    {
        //Here I could change the app to have an Id, which would be ideal and easier to find but I thought I would leave it as is,
        //to show how I would find the element if I was not allowed to change the app
        private IWebElement SubmitButton =>
            Driver.FindElements(By.TagName("button")).First(x => x.Text.Contains("SUBMIT"));

        private IWebElement TitlePage => Driver.FindElement(By.Id("challenge")).FindElement(By.TagName("h1"));

        private IReadOnlyCollection<IWebElement> Tables =>
            Driver.FindElements(By.TagName("table"));

        public ArrayChallengePage()
        {
            Wait.Until(x => SubmitButton.Displayed && SubmitButton.Enabled);
        }

        public string GetSectionTitle()
        {
            return TitlePage.Text;
        }

        public List<int> GetRowList(int rowItemRequired)
        {
            var table = Tables.Single(x => !string.IsNullOrEmpty(x.Text));
            var getrows = table.FindElements(By.TagName("tr"));
            var rowrequired = getrows.ElementAt(rowItemRequired).FindElements(By.TagName("td"));

            var listRows = new TableDataElementsToArrayConverter().ConvertElementRowsValueToArray(rowrequired);
            return listRows;
        }
    }
}