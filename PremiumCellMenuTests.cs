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

    public class PremiumCellMenuTests : TestBase
    {
        #region Support Methods

        //Route to "menu open"
        public void MenuOpen(IWebDriver driver, string benefitRequired, string browserName)
        {
            //Call route to results screen
            new SingleLifeResultsScreen().RouteToResultsSingleLife(driver, benefitRequired, browserName);

            //Open dropdown menu
            var menuObjects = new PremiumCellMenuObjects();
            int cellPosition = 0;
            menuObjects.PremiumCellMenuOpenSpecified(driver, cellPosition);
        }

        #endregion

        #region Tests

        //***************************************************************************//
        //           ALL BASED AROUND SINGLE LIFE RESULTS SCREEN - FOR NOW!          //
        //***************************************************************************//



        ////TEST ONE
        //Open the Premium Cell Menu and through to report with com
        [Test, Parallelizable, Description("Open Premium Cell Menu, launch report with com")]
        public void PremiumCellMenuReportWithCom(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call route to menu
            string benefitRequired = "LTA";
            MenuOpen(driver, benefitRequired, browserName);

            //Select report option - MITT COM
            string quoteType = "SingleBenefit";
            string benefitInstance = null;
            new PremiumCellMenuObjects().ComparisonReportMitCom(driver, quoteType, benefitInstance);

            //Track to a new window and assert title
            var originalWindow = driver.WindowHandles[0];
            var newWindowHandle = driver.WindowHandles[1];
            driver.SwitchTo().Window(newWindowHandle);

            //Wait for pdf viewer to load
            driver.WaitForUpTo(60, "Didn't make it to pdf viewer")
                .Until(ExpectedConditions.UrlContains("ComparisonReport?modelId"));

            //Assert that the URL indicates we're in the right place
            string newUrl = driver.Url.Trim();
            Assert.Contains(newUrl, "ComparisonReport.pdf");

            //Close window,
            new CommonSolutionBuilderPageObjects().NewWindowClose(driver, originalWindow);

            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST TWO
        //Open the Premium Cell Menu and through to report without com
        [Test, Parallelizable, Description("Open Premium Cell Menu, launch report without com")]
        public void PremiumCellMenuReportWithoutCom(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call route to menu
            string benefitRequired = "LTA";
            MenuOpen(driver, benefitRequired, browserName);

            //Select report option - NON COM
            string quoteType = "SingleBenefit";
            string benefitInstance = null;
            new PremiumCellMenuObjects().ComparisonReportNonCom(driver, quoteType, benefitInstance);

            //Track to a new window and assert title
            var originalWindow = driver.WindowHandles[0];
            var newWindowHandle = driver.WindowHandles[1];
            driver.SwitchTo().Window(newWindowHandle);

            //Wait for pdf viewer to load
            driver.WaitForUpTo(60, "Didn't make it to pdf viewer")
                .Until(ExpectedConditions.UrlContains("ComparisonReport?modelId"));

            //Assert that the URL indicates we're in the right place
            string newUrl = driver.Url.Trim();
            Assert.Contains(newUrl, "ComparisonReport.pdf");

            //Close window,
            new CommonSolutionBuilderPageObjects().NewWindowClose(driver, originalWindow);

            //Call Cleanup
            CleanUp(driver);
        }





        ////TEST THREE
        //Open the Premium Cell Menu and through to Quote Details
        [Test, Parallelizable, Description("Open Premium Cell Menu, launch Quote Details")]
        public void PremiumCellMenuQuoteDetails(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call route to menu
            string benefitRequired = "LTA";
            MenuOpen(driver, benefitRequired, browserName);

            //Select Alternative - first option
            new SelectAlternativeScreen().RouteToAlternative(driver, benefitRequired, browserName);

            //Check the second product in the list
            int productInTable = 1;
            new SelectAlternativePageObjects().SelectAlternativeSelect(driver, productInTable);

            //Re-Open dropdown menu
            var menuObjects = new PremiumCellMenuObjects();
            int cellPosition = 0;
            menuObjects.PremiumCellMenuOpenSpecified(driver, cellPosition);

            //Quote Details
            var menuOptions = new PremiumCellMenuObjects();
            string quoteType = "SingleBenefit";
            string benefitInstance = null;
            menuOptions.QuoteDetailsOpen(driver, quoteType, benefitInstance);

            //Spinner wait - productDetailsDialog
            string pageValidator = "productDetailsCloseButton";
            new CommonSolutionBuilderPageObjects().SpinnerWait(driver, pageValidator);

            //Warnings
            menuOptions.QuoteDetailsWarnings(driver);

            //Underwriting
            menuOptions.QuoteDetailsXrae(driver);

            //Benefit (first only)
            menuOptions.QuoteDetailsBenefits(driver);

            //Literature
            menuOptions.QuoteDetailsLiterature(driver);

            //Commisison
            menuOptions.QuoteDetailsCommission(driver);

            //Assert?
            bool closeDisp = driver.FindElement(By.Id("productDetails_CommissionTitle")).Displayed;
            Assert.IsTrue(closeDisp);

            //Close
            menuOptions.QuoteDetailsClose(driver);

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST FOUR
        //Open the Premium Cell Menu and Apply
        [Test, Parallelizable, Description("Apply from Premium Cell Menu option")]
        public void PremiumCellMenuApply(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call route to menu
            string benefitRequired = "LTA";
            MenuOpen(driver, benefitRequired, browserName);

            //Select Alternative - first option
            new SelectAlternativeScreen().RouteToAlternative(driver, benefitRequired, browserName);

            //Check the second product in the list
            int productInTable = 1;
            new SelectAlternativePageObjects().SelectAlternativeSelect(driver, productInTable);

            //Re-Open dropdown menu
            var menuObjects = new PremiumCellMenuObjects();
            int cellPosition = 0;
            menuObjects.PremiumCellMenuOpenSpecified(driver, cellPosition);

            //Click Apply
            var menuOptions = new PremiumCellMenuObjects();
            string quoteType = "SingleBenefit";
            string benefitInstance = null;
            menuOptions.CellOptionsApply(driver, quoteType, benefitInstance);

            //Wait for ApplyOptions modal and select "Provider"
            string pageValidator = "lifeQuoteApplyClose";
            var commonObjects = new CommonSolutionBuilderPageObjects();
            commonObjects.SpinnerWait(driver, pageValidator);
            new LifeQuotePageObjects().ApplyOptionsProvider(driver);
            
            //New window/tab
            var originalWindow = driver.WindowHandles[0];
            var newWindowHandle = driver.WindowHandles[1];
            driver.SwitchTo().Window(newWindowHandle);

            //Wait for Apply to load
            //driver.WaitForUpTo(30, "Didn't make it to the External Provider")
            //    .Until(ExpectedConditions.ElementExists(By.Id("tab_ClientDetails")));

            //*********************************
            //***     REQUIRES ASSERTION    ***
            //*********************************

            //Close Window, for forms sake
            commonObjects.NewWindowClose(driver, originalWindow);

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST FIVE
        //Quote on Income Protection "All", select alternative and check tags are displayed
        [Test, Parallelizable, Description("IP All Premiums Results Screen")]
        public void AllPremiumResultsScreen(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Route in to IP - don't trust the default
            new IncomeProtectionPage().AddAllPremiumIncomeProtection(driver, browserName);

            //
            new BenefitSelectionPageObjects().QuoteNow(driver);

            //Open dropdown menu
            var menuObjects = new PremiumCellMenuObjects();
            int cellPosition = 0;
            menuObjects.PremiumCellMenuOpenSpecified(driver, cellPosition);

            //Open Select Alternative modal
            string quoteType = "SingleBenefit";
            string benefitInstance = null;
            var selectAlternative = new SelectAlternativePageObjects();
            selectAlternative.SelectAlternativeOpenMenu(driver, quoteType, benefitInstance);

            //Wait
            string pageValidator = "premiumCellResultsClose";
            new CommonSolutionBuilderPageObjects().SpinnerWait(driver, pageValidator);

            //Check the second product in the list
            int productInTable = 1;
            new SelectAlternativePageObjects().SelectAlternativeSelect(driver, productInTable);

            //Check if Reviewable/Guaranteed is present:
            string elementIdGee = "GuaranteedLabel";
            bool GuaranteedPresent = new CommonSupportObjects().ElementPresentConfirmById(driver, elementIdGee);

            string elementIdRee = "ReviewableLabel";
            bool ReviewablePresent = new CommonSupportObjects().ElementPresentConfirmById(driver, elementIdRee);

            //Check that one of the results are returned:
            if (GuaranteedPresent == true)
            {
                Assert.IsTrue(GuaranteedPresent);
            }
            else
            {
                Assert.IsTrue(ReviewablePresent);

            }

            //Call Cleanup
            CleanUp(driver);
        }


        #endregion
    }
}
