using System;
using System.Collections.Generic;
using FluentAssert;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using qaTechTests.Helpers;
using qaTechTests.Pages;
using qaTechTests.Steps;

namespace qaTechTests.UnitTests
{
    [TestClass]
    public class ArrayUnitTests
    {
        [TestInitialize]
        public void TestSetup()
        {
            //I could call the hooks but thought I would keep these independent
            new AppHelper().StartReactApp();
            new DriverManager().SetDriver();
        }

        [TestMethod]
        public void GetIndexOfArrayWhereSumOfLeftEqualsRight()
        {
            //Setup
            var buttonFeaturePage = new NavigateToSection();
            buttonFeaturePage.GivenIHaveTheECSDigitalTechAppOpen();
            buttonFeaturePage.WhenIPressTheRenderChallengeButton();

            //Act
            var arrayPage = new ArrayChallengePage();
            var rowList1 = arrayPage.GetRowList(0);
            var rowList2 = arrayPage.GetRowList(1);
            var rowList3 = arrayPage.GetRowList(2);

            var findIndexOfSumLeftEqualsRightRow1 = GetCorrectIndex(rowList1);
            var findIndexOfSumLeftEqualsRightRow2 = GetCorrectIndex(rowList2);
            var findIndexOfSumLeftEqualsRightRow3 = GetCorrectIndex(rowList3);

            //Assert
            findIndexOfSumLeftEqualsRightRow1.ShouldBeEqualTo(4);
            findIndexOfSumLeftEqualsRightRow2.ShouldBeEqualTo(3);
            findIndexOfSumLeftEqualsRightRow3.ShouldBeEqualTo(5);
        }

        private int? GetCorrectIndex(List<int> rowvalues)
        {
            var equalIndex = false;
            //Start on second index
            for (int indexCounter = 1; indexCounter < rowvalues.Count; indexCounter++)
            {
                //GetLeftValue
                var leftvalues = 0;
                for (int leftIndexCounter = indexCounter - 1; leftIndexCounter > -1; leftIndexCounter--)
                {
                    leftvalues = rowvalues[leftIndexCounter] + leftvalues;
                }

                var rightvalues = 0;
                //Get Right values
                for (int rightIndexCounter = indexCounter + 1; rightIndexCounter < rowvalues.Count; rightIndexCounter++)
                {
                    rightvalues = rowvalues[rightIndexCounter] + rightvalues;
                }

                if (rightvalues == leftvalues)
                {
                    return indexCounter;
                }
            }

            return null;
        }

        [TestCleanup]
        public void TestCleanupMethod()
        {
            new DriverManager().ExitDriver();
            new AppHelper().EndApp();
        }
    }
}