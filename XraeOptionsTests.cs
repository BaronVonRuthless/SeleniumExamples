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

    public class XraeOptionsTests : TestBase
    {
        #region Support Methods

        //A bundle to quickly get you to the modal
        public void RouteToXraeModal(IWebDriver driver, string benefitRequired, string browserName)
        {
            //Call route to results screen
            new SingleLifeResultsScreen().RouteToResultsSingleLife(driver, benefitRequired, browserName);

            //Open XRAE Options:
            var xraeObjects = new XraePageObjects();
            xraeObjects.XraeLinkButton(driver);

            //Wait for modal to load
            string pageValidator = "xraeLifeDetailsFirstLife";
            new CommonSolutionBuilderPageObjects().SpinnerWait(driver, pageValidator);

        }

        #endregion

        #region Tests

        //***************************************************************************//
        //           ALL BASED AROUND SINGLE LIFE RESULTS SCREEN - FOR NOW!          //
        //***************************************************************************//

        ////TEST ONE
        //Open and CLose the XRAE options modal
        [Test, Parallelizable, Description("Open XRAE Options modal and close")]
        public void XraeOptionsOpenClose(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call route to results screen
            string benefitRequired = "LTA";
            RouteToXraeModal(driver, benefitRequired, browserName);

            //Assert that XRAE options have been reached
            string modalTitle = driver.FindElement(By.Id("xraeLifeDetailsTitle")).Text.Trim();
            Assert.AreEqual(modalTitle, "Select client for an indicative underwriting decision");

            //Close
            new XraePageObjects().XraeModalClose(driver);

            //Check that page is still active
            bool pageActive = driver.FindElement(By.Id("resultsSummaryBenefitAndClientDetails")).Displayed;
            Assert.IsTrue(pageActive);

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST TWO
        //Check the NEWS link
        [Test, Parallelizable, Description("Open XRAE Options modal and follow the NEWS link")]
        public void XraeOptionsNewsLink(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call route to results screen
            string benefitRequired = "LTA";
            RouteToXraeModal(driver, benefitRequired, browserName);

            //CLick the USER GUIDE link and follow through to the new page:
            string originalWindow = new XraePageObjects().XraeNews(driver);

            //Assert correct page reached
            string pageUrl = driver.Url.ToString();
            Assert.Contains(pageUrl, "xraenews");

            //Close window and return to existing page
            new CommonSolutionBuilderPageObjects().NewWindowClose(driver, originalWindow);
            
            //Confirm modal is still active - UNELIABLE DUE TO WEBDRIVER "CLOSE WINDOW" UTILITY
            //string modalTitle = driver.FindElement(By.Id("xraeLifeDetailsTitle")).Text.Trim();
            //Assert.AreEqual(modalTitle, "Select client for an indicative underwriting decision");

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST THREE
        //Check the User Guide link
        [Test, Parallelizable, Description("Open XRAE Options modal and link through to User Guide")]
        public void XraeOptionsUserGuide(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call route to results screen
            string benefitRequired = "LTA";
            RouteToXraeModal(driver, benefitRequired, browserName);

            //Click the USER GUIDE link and follow through to the new page:
            string originalWindow = new XraePageObjects().XraeUserGuide(driver);

            //Assert correct page reached
            string pageUrl = driver.Url.ToString();
            Assert.Contains(pageUrl, "xraeuserguide");

            //Close window and return to existing page
            new CommonSolutionBuilderPageObjects().NewWindowClose(driver, originalWindow);

            //Confirm modal is still active - UNELIABLE DUE TO WEBDRIVER "CLOSE WINDOW" UTILITY
            //string modalTitle = driver.FindElement(By.Id("xraeLifeDetailsTitle")).Text.Trim();
            //Assert.AreEqual(modalTitle, "Select client for an indicative underwriting decision");

            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST FOUR
        //First Life link to XRAE
        [Test, Parallelizable, Description("Open XRAE Options modal and click through for first life")]
        public void XraeOptionsFirstLife(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call route to results screen
            string benefitRequired = "LTA";
            RouteToXraeModal(driver, benefitRequired, browserName);

            //Click the USER GUIDE link and follow through to the new page:
            string originalWindow = new XraePageObjects().XraeFirstLife(driver);

            //Assert correct page reached
            string pageText = driver.FindElement(By.Id("cphForm_panPageDesc")).Text.Trim();
            Assert.Contains(pageText, "All results displayed are indicative based on the data entered into XRAE");

            //Close window and return to existing page
            new CommonSolutionBuilderPageObjects().NewWindowClose(driver, originalWindow);

            //Confirm modal is still active - UNELIABLE DUE TO WEBDRIVER "CLOSE WINDOW" UTILITY
            //string modalTitle = driver.FindElement(By.Id("xraeLifeDetailsTitle")).Text.Trim();
            //Assert.AreEqual(modalTitle, "Select client for an indicative underwriting decision");

            //Call Cleanup
            CleanUp(driver);
        }



        #endregion
    }
}
