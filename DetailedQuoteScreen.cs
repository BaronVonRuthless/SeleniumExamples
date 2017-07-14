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

    public class DQComparisonScreen : TestBase
    {
        #region Support Methods

        ////ROUTE TO EXTERNAL SCREEN
        //Bunbled methods to reach detailed quote excursion screen
        public string RouteToDetailedQuoteExcursion(IWebDriver driver, string benefitRequired, string browserName)
        {
            //Call route to results screen
            new SingleLifeResultsScreen().RouteToResultsSingleLife(driver, benefitRequired, browserName);

            //Click to open Premium Cell Menu
            int cellPosition = 0;
            new PremiumCellMenuObjects().PremiumCellMenuOpenSpecified(driver, cellPosition);

            //Click Detailed Quote
            string quoteType = "SingleBenefit";
            string benefitInstance = "";
            var detailed = new DetailedQuotePageObjects();
            string originalWindow = detailed.DetailedQuote(driver, quoteType, benefitInstance);

            return originalWindow;
        }

        ////ROUTE TO RETURN SCREEN
        //bundled method to get you to the return screen

        public void RouteToDetailedQuoteReturnScreen(IWebDriver driver, string originalWindow)
        {
            var detailed = new DetailedQuotePageObjects();

            //Quote
            detailed.PortalQuoteClick(driver);
            var common = new CommonSolutionBuilderPageObjects();
            {
                string pageValidator = "imgBtnHelp_IllusDocs";
                common.GenericWait(driver, pageValidator);
            }

            //Close Window
            new CommonSolutionBuilderPageObjects().NewWindowClose(driver, originalWindow);
            {
                string pageValidator = "detailedQuoteDialog";
                common.SpinnerWait(driver, pageValidator);
            }

            //Request quotes
            detailed.DetailedSaveApply(driver);
            {
                string pageValidator = "fullComparisonResultsButton";
                common.SpinnerWait(driver, pageValidator);
            }
        }

        #endregion

        #region Tests


        //***************************************************************************//
        //           ALL BASED AROUND SINGLE LIFE RESULTS SCREEN - FOR NOW!          //
        //***************************************************************************//





        ////TEST ONE
        //Perform a detailed quote and return to SB, collecting results and a Like & Save.
        [Test, Parallelizable, Description("Detailed Quote - return results and Like & Save")]
        public void DetailedQuoteLikeAndSave(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Route method to get to Detailed Quote RETURN screen
            string benefitRequired = "LTA";
            string originalWindow = RouteToDetailedQuoteExcursion(driver, benefitRequired, browserName);
            this.RouteToDetailedQuoteReturnScreen(driver, originalWindow);

            //Like first and close
            var detailed = new DetailedQuotePageObjects();
            detailed.DetailedLikeFirst(driver);

            //Assert that the screen updates as expected
            //Assert
            detailed.DetailedClose(driver);

            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST TWO
        //Detailed Quote WITHOUT QUOTING return to see the correct error message
        [Test, Parallelizable, Description("Detailed Quote - no quotes returned")]
        public void DetailedQuoteNoQuotesReturned(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Route method to get to Detailed Quote RETURN screen
            string benefitRequired = "LTA";
            string originalWindow = RouteToDetailedQuoteExcursion(driver, benefitRequired, browserName);

            var detailed = new DetailedQuotePageObjects();
            var common = new CommonSolutionBuilderPageObjects();

            //Close Window
            common.NewWindowClose(driver, originalWindow);
            {
                string pageValidator = "detailedQuoteDialog";
                common.SpinnerWait(driver, pageValidator);
            }

            //Request quotes
            detailed.DetailedSaveApply(driver);
            {
                string pageValidator = "detailedQuoteCloseButton";
                common.SpinnerWait(driver, pageValidator);
            }

            //Assert that screen is displayed correctly
            string errorMessage = driver.FindElement(By.XPath(".//*[@id='detailedQuoteDialog']/div/div/div[2]/div/span")).Text.Trim();
            Assert.AreEqual(errorMessage, "No detailed quotes have been found");

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST THREE
        //Hit the apply link on the first product
        [Test, Parallelizable, Description("Detailed Quote - Apply for First Return")]
        public void DetailedQuoteApplyForFirstReturn(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Route method to get to Detailed Quote RETURN screen
            string benefitRequired = "LTA";
            string originalWindow = RouteToDetailedQuoteExcursion(driver, benefitRequired, browserName);
            this.RouteToDetailedQuoteReturnScreen(driver, originalWindow);

            //Like first and close
            var detailed = new DetailedQuotePageObjects();
            detailed.DetailedApplyFirst(driver);

            //Wait and assert page is correct
            string pageValidator = "lifeQuoteApplyClose";
            new CommonSolutionBuilderPageObjects().SpinnerWait(driver, pageValidator);
            Assert.IsTrue(driver.FindElement(By.Id("lifeQuoteApplyTitle")).Displayed);

            //Assert that the screen updates as expected
            var lifeQuote = new LifeQuotePageObjects();
            string screenText = lifeQuote.ApplyOptionsMessageText(driver);
            string expectedMessage = Constants.LQ_CONTACT;
            Assert.AreEqual(screenText, expectedMessage);

            //Close
            lifeQuote.ApplyOptionsClose(driver);

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST FOUR
        //Perform a detailed quote and return to SB, then back again
        [Test, Parallelizable, Description("Detailed Quote - return to the comparison screen")]
        public void DetailedQuoteReturnToComp(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Route method to get to Detailed Quote RETURN screen
            {
                string benefitRequired = "LTA";
                string originalWindow = RouteToDetailedQuoteExcursion(driver, benefitRequired, browserName);
                this.RouteToDetailedQuoteReturnScreen(driver, originalWindow);
            }

            //Bounce back into Assureweb
            {
                string originalWindow = new DetailedQuotePageObjects().DetailedReturnToComp(driver);
                string pageTitle = driver.Title.ToString().Trim();
                Assert.Contains(pageTitle, "iPipeline - Multi-Benefit Comparison");
                new CommonSolutionBuilderPageObjects().NewWindowClose(driver, originalWindow);
            }

            //Call Cleanup
            CleanUp(driver);
        }

        

        #endregion
    }
}
