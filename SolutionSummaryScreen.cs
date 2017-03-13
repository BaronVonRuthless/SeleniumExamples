using Gallio.Framework;
using Gallio.Model;
using MbUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using Common;
using RegManagerPageObjects;
using SolutionBuilderClientDetailsPageObjects;
using SolutionBuilderClientDetailsTESTS;
using SolutionBuilderQuoteDetailsPageObjects;


namespace SolutionBuilderQuoteDetailsTESTS
{
    //
    //
    //

    public class SolutionSummaryScreen : TestBase
    {
        #region Support Methods

        //Nested methods to reach the Summary Screen - SINGLE LIFE QUOTE
        public void RouteToSummary(IWebDriver driver, string benefitRequired, string browserName)
        {
            //Select Alternative - first option
            new SelectAlternativeScreen().RouteToAlternative(driver, benefitRequired, browserName);

            //Check the second product in the list
            int productInTable = 1;
            new SelectAlternativePageObjects().SelectAlternativeSelect(driver, productInTable);

            //Like the on screen product
            string quoteTypeLower = "quickQuote";
            new CommonResultsPageObjects().SelectFirstFlag(driver, quoteTypeLower);

            //Assert popOver
            string popOver = driver.FindElement(By.ClassName("popover-content")).Text.Trim();
            Assert.AreEqual(popOver, "Solution Added – Click here to review");

            //Assert CountBadge
            var solutionSummaryObjects = new SolutionSummaryPageObjects();
            int countBadge = solutionSummaryObjects.SummaryExternalGetCount(driver);
            Assert.AreEqual(1, countBadge);

            //Click to open the summary tab
            solutionSummaryObjects.OpenSolutionSummary(driver);
        }

        #endregion

        #region Tests

        //***************************************************************************//
        //           ALL BASED AROUND SINGLE LIFE RESULTS SCREEN - FOR NOW!          //
        //***************************************************************************//



        ////TEST ONE
        //Check that a liked product can be saved
        [Test, Parallelizable, Description("Save the liked product")]
        public void SolutionSummarySaveForLater(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call route to an open Sumamry (single LIKE)
            string benefitRequired = "LTA";
            RouteToSummary(driver, benefitRequired, browserName);

            //Save For Later
            var summaryObjects = new SolutionSummaryPageObjects();
            summaryObjects.SummarySaveForLater(driver);

            //Check that the button has disabled
            string buttonState = driver.FindElement(By.Id("solutionSummarySaveChangesButton")).GetAttribute("disabled").Trim().ToString();
            Assert.AreEqual(buttonState, "true");

            //Close
            summaryObjects.SummaryClose(driver);

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST TWO
        //Deletes the first product in the list and confirms page update
        [Test, Parallelizable, Description("Delete the first product in the list")]
        public void SolutionSummaryDeleteEntry(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call route to an open Sumamry (single LIKE)
            string benefitRequired = "LTA";
            RouteToSummary(driver, benefitRequired, browserName);

            //Note the number of products in list
            var summaryObjects = new SolutionSummaryPageObjects();
            int productsOnEntry = summaryObjects.SummaryInternalGetCount(driver);

            //Delete first entry in list
            string listInstance = "0";
            summaryObjects.SummaryDeleteEntry(driver, listInstance);

            //Get new count of products:
            int productsOnDelete = summaryObjects.SummaryInternalGetCount(driver);

            //Compare two counts to ensure update has occured
            Assert.IsTrue(productsOnEntry > productsOnDelete);

            //Close using Open/CLose tab
            summaryObjects.OpenSolutionSummary(driver);

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST THREE
        //CHecks that ApplyOptions is reached from the solution summary
        [Test, Parallelizable, Description("Apply Option triggers ApplyOptions menu")]
        public void SolutionSummaryApply(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call route to an open Sumamry (single LIKE)
            string benefitRequired = "LTA";
            RouteToSummary(driver, benefitRequired, browserName);

            //Apply + Wait
            string listInstance = "0";
            new SolutionSummaryPageObjects().ClickFirstApply(driver, listInstance);

            //Wait for ApplyOptions to Open
            string pageValidator = "lifeQuoteApplyClose";
            new CommonSolutionBuilderPageObjects().SpinnerWait(driver, pageValidator);

            //Assert
            string pageCheck = driver.FindElement(By.Id("lifeQuoteApplyTitle")).Text.Trim();
            Assert.AreEqual(pageCheck, "Apply options");

            //Call Cleanup
            CleanUp(driver);
        }



        //***************************************************************************//
        //                           APPLICATION PACKS POP-UP                        //
        //***************************************************************************//

        ////TEST FOUR
        //Opens Application Pack Pop-Up and validates returns (single policy solution)
        [Test, Parallelizable, Description("ApplicationPacks pop-up")]
        public void SolutionSummaryApplicationPacks(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var summaryObjects = new SolutionSummaryPageObjects();
            var commonObjects = new CommonSolutionBuilderPageObjects();

            //Call route to an open Sumamry (single LIKE)
            string benefitRequired = "LTA";
            RouteToSummary(driver, benefitRequired, browserName);

            //Open Application packs pop-up (for only solution)
            int solutionInstance = 0;
            summaryObjects.SummaryGetApplicationPack(driver, solutionInstance);

            //Wait for pop-up
            string pageValidator = "applicationPackModalTitle";
            commonObjects.SpinnerWait(driver, pageValidator);
            
            //Assert in order: Key Features
            {
                int waitTime = 10;
                string documentType = "applicationPackKeyFeaturesComplete";
                string testText = "Key features retrieved successfully";
                bool resultsText = summaryObjects.SummaryValidateApplicationPack(driver, waitTime, documentType, testText);
                Assert.IsTrue(resultsText);
            }

            //Assert in order: Illustrations
            {
                int waitTime = 120;
                string documentType = "applicationPackIllustrationsComplete";
                string testText = "Illustrations retrieved successfully";
                bool resultsText = summaryObjects.SummaryValidateApplicationPack(driver, waitTime, documentType, testText);
                Assert.IsTrue(resultsText);
            }

            //Assert in order: Comparison Reports
            {
                int waitTime = 10;
                string documentType = "applicationPackComparisonReportsComplete";
                string testText = "Comparison reports retrieved successfully";
                bool resultsText = summaryObjects.SummaryValidateApplicationPack(driver, waitTime, documentType, testText);
                Assert.IsTrue(resultsText);
            }

            //READ TEXT??

            //DOWNLOAD??

            //Close dialogue
            summaryObjects.SummaryCloseApplicationPack(driver);

            //Call Cleanup
            CleanUp(driver);
        }

        #endregion
    }
}
