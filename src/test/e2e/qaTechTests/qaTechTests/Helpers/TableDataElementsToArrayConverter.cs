using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace qaTechTests.Helpers
{
    internal class TableDataElementsToArrayConverter
    {
        public List<int> ConvertElementRowsValueToArray(IReadOnlyCollection<IWebElement> tablerowValues)
        {
            var arrayList = new List<int>();

            foreach (var tdElement in tablerowValues)
            {
                arrayList.Add(Convert.ToInt32(tdElement.Text));
            }

            return arrayList;
        }
    }
}