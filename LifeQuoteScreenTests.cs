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

    public class LifeQuoteScreenTests : TestBase
    {
        #region Support Methods

        //Route to the modal
        public void RouteToModal(IWebDriver driver, string benefitRequired, string browserName)
        {
            //Call route to results screen
            new SingleLifeResultsScreen().RouteToResultsSingleLife(driver, benefitRequired, browserName);

            //Open the solution summary
            var summary = new SolutionSummaryPageObjects();
            summary.OpenSolutionSummary(driver);

            //Open the LifeQuote modal
            var lifeQuote = new LifeQuotePageObjects();
            lifeQuote.LifeQuoteModalOpen(driver);

            //Assert
            string modalTitle = driver.FindElement(By.Id("lifeQuoteRegistrationTitle")).Text.ToString();
            Assert.AreEqual(modalTitle, "LifeQuote");
        }

        #endregion

        #region Tests

        //***************************************************************************//
        //           ALL BASED AROUND SINGLE LIFE RESULTS SCREEN - FOR NOW!          //
        //***************************************************************************//




        ////TEST ONE
        //Open the LifeQuote modal and close with OKAY
        [Test, Parallelizable, Description("Open/Close LifeQuote modal (okay)")]
        public void LifeQuoteModalOpenOkay(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Route to Modal
            string benefitRequired = "LTA";
            RouteToModal(driver, benefitRequired, browserName);

            //Modal OKAY
            new LifeQuotePageObjects().LifeQuoteModalOkay(driver);

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST TWO
        //Open the LifeQuote modal and close with CLOSE
        [Test, Parallelizable, Description("Open/Close LifeQuote modal (close)")]
        public void LifeQuoteModalOpenClose(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Route to Modal
            string benefitRequired = "LTA";
            RouteToModal(driver, benefitRequired, browserName);

            //Modal CLOSE
            new LifeQuotePageObjects().LifeQuoteModalClose(driver);

            //Call Cleanup
            CleanUp(driver);
        }



        #endregion
    }
}
