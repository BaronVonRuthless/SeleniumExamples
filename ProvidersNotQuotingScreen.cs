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

    public class ProvidersNotQuotingScreen : TestBase
    {
        #region Support Methods

        //A bundle to quickly get you to the New Client Page
        public void RouteToBenefits(IWebDriver driver)
        {
            // Use login methods to call page, validate and attempt login
            var support = new DashboardPage();
            support.RouteToDashboard(driver);

            //Click through to New Quote
            var dashboard = new DashboardPageObjects();
            dashboard.NewQuote(driver);

        }

        #endregion

        #region Tests

        //***************************************************************************//
        //           ALL BASED AROUND SINGLE LIFE RESULTS SCREEN - FOR NOW!          //
        //***************************************************************************//



        ////TEST ONE
        //Open the Premium Cell Menu, PNQ Modal and then test inputs
        [Test, Parallelizable, Description("PNQ Modal from Premium Menu Cell")]
        public void ProvidersNotQuotingAllInputs(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call route to menu
            string benefitRequired = "LTA";
            new PremiumCellMenuTests().MenuOpen(driver, benefitRequired, browserName);

            //Open PNQ modal
            string quoteType = "SingleBenefit";
            string benefitInstance = null;
            var providersNon = new ProvidersNotQuotingPageObjects();
            providersNon.PNQOpenMenu(driver, quoteType, benefitInstance);

            //Wait
            string pageValidator = "premiumCellResultsClose";
            new CommonSolutionBuilderPageObjects().SpinnerWait(driver, pageValidator);

            //Expand and pop into Select Alternative, assert:
            //providersNon.PNQExpand(driver);
            providersNon.PNQSelectAlternative(driver);
            bool selectPage = driver.FindElement(By.Id("alternativeProductsRows")).Displayed;
            Assert.IsTrue(selectPage);

            //Come back to PNQ and assert:
            new SelectAlternativePageObjects().ProvidersNotQuotingSelect(driver);
            bool returnPnq = driver.FindElement(By.Id("providersNotQuotingModalBody")).Displayed;
            Assert.IsTrue(returnPnq);

            //Close
            providersNon.PNQClose(driver);

            //Call Cleanup
            CleanUp(driver);
        }



        #endregion
    }
}
