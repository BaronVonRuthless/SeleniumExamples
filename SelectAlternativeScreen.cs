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
using System.Drawing.Imaging;


namespace SolutionBuilderQuoteDetailsTESTS
{
    //
    //
    //

    public class SelectAlternativeScreen :TestBase
    {
        #region Support Methods

        //A bunble of methods to take you to the results screen; select alternative already open
        public void RouteToAlternative(IWebDriver driver, string benefitRequired, string browserName)
        {
            //Call route to menu
            new PremiumCellMenuTests().MenuOpen(driver, benefitRequired, browserName);

            //Open PNQ modal
            string quoteType = "SingleBenefit";
            string benefitInstance = null;
            var selectAlternative = new SelectAlternativePageObjects();
            selectAlternative.SelectAlternativeOpenMenu(driver, quoteType, benefitInstance);

            //Wait
            string pageValidator = "quoteResultsCount";
            new CommonSolutionBuilderPageObjects().SpinnerWait(driver, pageValidator);
        }

        //SR51 - A bunble of methods to take you to the results screen; select alternative already open - SR51
        public void RouteToAlternativeSR51(IWebDriver driver, string benefitRequired, string browserName)
        {
            //Call route to menu
            new PremiumCellMenuTests().MenuOpen(driver, benefitRequired, browserName);

            //Open PNQ modal
            string quoteType = "SingleBenefit";
            string benefitInstance = null;
            var selectAlternative = new SelectAlternativePageObjects();
            selectAlternative.SelectAlternativeOpenMenu(driver, quoteType, benefitInstance);

            //Wait
            string pageValidator = "backToBenefitsButton";
            new CommonSolutionBuilderPageObjects().SpinnerWait(driver, pageValidator);
        }





        #endregion

        #region Tests

        //***************************************************************************//
        //           ALL BASED AROUND SINGLE LIFE RESULTS SCREEN - FOR NOW!          //
        //***************************************************************************//


        ////TEST ONE
        //Open the Premium Cell Menu, Select Alternative and then close
        [Test, Parallelizable, Description("Select Alternatives, open modal, close modal")]
        public void SelectAlternativesOpenClose(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup + required objects
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var selectAlternative = new SelectAlternativePageObjects();

            //Call route to alternative
            string benefitRequired = "LTA";
            RouteToAlternative(driver, benefitRequired, browserName);

            //Close
            selectAlternative.SelectAlternativeClose(driver);


            //backToBenefitsButton??

            //Assert return to the Results screen, all displayed
            bool returnResults = driver.FindElement(By.Id("resultsSummaryBenefitAndClientDetails")).Displayed;
            Assert.IsTrue(returnResults);

            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST TWO
        //Open the Premium Cell Menu, Select Alternative and then test inputs
        [Test, Parallelizable, Description("Select Alternatives from Premium Menu Cell")]
        public void SelectAlternativesAllInputs(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup + required objects
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var selectAlternative = new SelectAlternativePageObjects();

            //Call route to alternative
            string benefitRequired = "LTA";
            RouteToAlternative(driver, benefitRequired, browserName);

            //Pop into PNQ
            selectAlternative.ProvidersNotQuotingSelect(driver);
            
            //Assert PNQ reached okay
            bool reachedPnq = driver.FindElement(By.Id("providersNotQuotingModalBody")).Displayed;
            Assert.IsTrue(reachedPnq);

            //Come back to Select Alternative
            new ProvidersNotQuotingPageObjects().PNQSelectAlternative(driver);
            
            //Assert return to Select Alternative
            bool returnedSelect = driver.FindElement(By.Id("alternativeProductsRows")).Displayed;
            Assert.IsTrue(returnedSelect);

            //Check the second product in the list
            int productInTable = 1;
            selectAlternative.SelectAlternativeSelect(driver, productInTable);
            
            //Assert return to the Results screen, all displayed
            bool returnResults = driver.FindElement(By.Id("resultsSummaryBenefitAndClientDetails")).Displayed;
            Assert.IsTrue(returnResults);

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST THREE
        //Open the Premium Cell Menu, Select Alternative and then test Xrae link
        [Test, Parallelizable, Description("Select Alternatives from Premium Menu Cell, XRAE Link")]
        public void SelectAlternativesXraeLink(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup + required objects
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var selectAlternative = new SelectAlternativePageObjects();

            //Call route to alternative
            string benefitRequired = "LTA";
            RouteToAlternative(driver, benefitRequired, browserName);

            //Expand the first row and check for default content (displayed)
            int productInTable = 1;
            selectAlternative.SelectAlternativeExpandRow(driver, productInTable);
            //Assert...

            //Select the Xrae icon and check the pop-up appears  - UNELIABLE DUE TO UNRELIABLE XRAE RETURN UTILITY
            //selectAlternative.SelectAlternativeXRAEInfo(driver);
            //string popText = driver.FindElement(By.XPath(".//*[@id='xraeDetailsResult_0']/div/div/div[2]/div/div/div[2]/div")).Text.Trim();
            //Assert.Contains(popText, "For XRAE underwriting purposes");

            //Select XRAE Underwriting options
            string pageValidator = "xraeLifeDetailsFirstLife";
            selectAlternative.XRAEUnderwritingSelect(driver);
            new CommonSolutionBuilderPageObjects().SpinnerWait(driver, pageValidator);

            //Assert that XRAW options have been reached
            string modalTitle = driver.FindElement(By.Id("xraeLifeDetailsTitle")).Text.Trim();
            Assert.AreEqual(modalTitle, "Select client for an indicative underwriting decision");

            //Call Cleanup
            CleanUp(driver);
        }





        #region SR51 - Select Alternative SCREEN

        //***************************************************************************//
        //              SR51 Select Alternative SCREEN - Rewrite Project             //
        //***************************************************************************//

        ////TEST FOUR POINT ONE [4.1]
        //Open the Premium Cell Menu, Select Alternative and then close
        [Test, Parallelizable, Description("Select Alternatives, open screem, close screen")]
        public void SelectAlternativesOpenMenuSR51(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup + required objects
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var selectAlternative = new SelectAlternativePageObjects();
            var commonSupport = new CommonSupportObjects();

            //Call route to alternative
            string benefitRequired = "LTA";
            RouteToAlternativeSR51(driver, benefitRequired, browserName);

            //Screenshot
            string testName = TestContext.CurrentContext.Test.ToString().Trim();
            commonSupport.ScreenshotToFile(driver, testName, browserName, version, platform, deviceName, deviceOrientation);

            //Close
            selectAlternative.SelectAlternativeCloseSR51(driver);

            //Wait
            string pageValidator = "resultsSummaryBenefitAndClientDetails";
            new CommonSolutionBuilderPageObjects().SpinnerWait(driver, pageValidator);

            //Assert return to the Results screen, all displayed
            bool returnResults = driver.FindElement(By.Id("resultsSummaryBenefitAndClientDetails")).Displayed;
            Assert.IsTrue(returnResults);

            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST FOUR POINT ONE [4.2]
        //Open Select Alternatives from the icon and then close.
        [Test, Parallelizable, Description("Select Alternatives, open screem, close screen")]
        public void SelectAlternativesOpenIconSR51(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup + required objects
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var selectAlternative = new SelectAlternativePageObjects();

            //Call route to single life results screen
            string benefitRequired = "DTA";
            new SingleLifeResultsScreen().RouteToResultsSingleLife(driver, benefitRequired, browserName);

            //Open select alterntaice scree using ICON
            string quoteType = "SingleBenefit";
            string benefitInstance = null;
            selectAlternative.SelectAlternativeOpenIcon(driver, quoteType, benefitInstance);

            //Wait
            string pageValidator = "backToBenefitsButton";
            new CommonSolutionBuilderPageObjects().SpinnerWait(driver, pageValidator);

            //Assert screen displayed
            bool selectionScreen = driver.FindElement(By.Id("selectProductRow_0")).Displayed;
            Assert.IsTrue(selectionScreen);

            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST FIVE
        //Check Client History Link
        [Test, Parallelizable, Description("Link to Dashboard")]
        public void LinkToDashboardSelectAlternativeSR51(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup + required objects
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var selectAlternative = new SelectAlternativePageObjects();

            //Call route to alternative
            string benefitRequired = "FIB";
            RouteToAlternativeSR51(driver, benefitRequired, browserName);

            //Click Client Search Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.ClientSearchButton(driver);

            //Validate dashboard page reached.
            Assert.IsTrue(driver.FindElement(By.Id("resultsSearchTitle")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST SIX
        //Client History
        [Test, Parallelizable, Description("Client History Button")]
        public void ClientHistoryButtonSelectAlternativeSR51(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup + required objects
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var selectAlternative = new SelectAlternativePageObjects();

            //Call route to alternative
            string benefitRequired = "IP";
            RouteToAlternativeSR51(driver, benefitRequired, browserName);

            //Click client history Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.ClientHistoryButton(driver);

            //Validate client histroy page reached.
            Assert.IsTrue(driver.FindElement(By.Id("client-history")).Displayed);

            driver.Navigate().GoToUrl("");

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST SEVEN
        //Add client button
        [Test, Parallelizable, Description("Add Client Button")]
        public void AddClientButtonSelectAlternativeSR51(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup + required objects
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var selectAlternative = new SelectAlternativePageObjects();

            //Call route to alternative
            string benefitRequired = "LTA";
            RouteToAlternativeSR51(driver, benefitRequired, browserName);

            //Click add client Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.AddClientButton(driver);

            //Validate client details reached and page blank
            string attribute = driver.FindElement(By.Id("firstlifetitle")).GetAttribute("value");
            Assert.AreEqual(attribute, "");

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST EIGHT
        //Back to My Services using header button
        [Test, Parallelizable, Description("Link Back to Services")]
        public void MyServicesLinkSelectAlternativeSR51(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup + required objects
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var selectAlternative = new SelectAlternativePageObjects();

            //Call route to alternative
            string benefitRequired = "DTA";
            RouteToAlternativeSR51(driver, benefitRequired, browserName);

            //Click my services Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.MyServicesButton(driver);

            //Validate my services page reached.
            Assert.IsTrue(driver.FindElement(By.Id("Assureweb-btn")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST NINE
        //Logout
        [Test, Parallelizable, Description("Header Logout Button")]
        public void LogoutButtonSelectAlternativeSR51(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup + required objects
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var selectAlternative = new SelectAlternativePageObjects();

            //Call route to alternative
            string benefitRequired = "FIB";
            RouteToAlternativeSR51(driver, benefitRequired, browserName);

            //Click Logout Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.LogoutButton(driver);

            //Summon Validator, Lord of Validation
            string messageText = Constants.LOGOUT;
            common.ValidateDialogueDisplayText(driver, messageText);

            //Cancel dialogue
            common.DialogueClose(driver);

            //Re-select logout and exit
            common.LogoutButton(driver);
            common.DialogueYes(driver);
            string pageValidator = "username";
            common.GenericWait(driver, pageValidator);

            //Validate login page reached.
            Assert.IsTrue(driver.FindElement(By.Id("signin-btn")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST TEN
        //Click the View/Edit client button
        [Test, Parallelizable, Description("View Edit Client Button")]
        public void ViewEditClientButtonSelectAlternativeSR51(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup + required objects
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var selectAlternative = new SelectAlternativePageObjects();

            //Call route to alternative
            string benefitRequired = "IP";
            RouteToAlternativeSR51(driver, benefitRequired, browserName);

            //Click view edit client Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.EditClientButton(driver);

            //Validate client details page reached - Find field and ensure contains "Mr"
            string forenamePresent = driver.FindElement(By.Id("firstlifeforename")).GetAttribute("value");
            Assert.IsNotEmpty(forenamePresent);

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST ELEVEN
        //Click the View/Edit client button
        [Test, Parallelizable, Description("View Edit Client Button")]
        public void NewQuoteButtonSelectAlternativeSR51(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup + required objects
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var selectAlternative = new SelectAlternativePageObjects();

            //Call route to alternative
            string benefitRequired = "LTA";
            RouteToAlternativeSR51(driver, benefitRequired, browserName);

            //Click view edit client Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.NewQuoteButton(driver);

            //Validate client details page reached - Find field and ensure contains "Mr"
            Assert.IsTrue(driver.FindElement(By.Id("benefit-summary")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }



        //TEST TWELVE - .1
        //Help Overlay - SELECT ALTERNATIVE
        [Test, Parallelizable, Description("Link to Help Overlay")]
        public void HelpLinkSelectAlternativeSR51(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            /// Call Setup + required objects
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var selectAlternative = new SelectAlternativePageObjects();

            //Call route to alternative
            string benefitRequired = "IP";
            RouteToAlternativeSR51(driver, benefitRequired, browserName);

            //Click help icon & validate arrival
            var common = new CommonSolutionBuilderPageObjects();
            string validationElement = "filter-premium-type-col";
            common.HelpOverlayOpenValidateById(driver, validationElement);
            Assert.IsTrue(driver.FindElement(By.Id(validationElement)).Displayed);

            //Then return to Select Alternative screen
            string pageValidator = "backToBenefitsButton";
            string buttonPath = "html/body/div[2]/hidden/div/div/button";
            common.HelpOverlayCloseSpecified(driver, pageValidator, buttonPath);
            Assert.IsTrue(driver.FindElement(By.Id(pageValidator)).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        //TEST TWELVE - .2
        //Help Overlay - PRODUCTS NOT QUOTING
        [Test, Parallelizable, Description("Link to Help Overlay")]
        public void HelpLinkProvidersNotQuotingSR51(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            /// Call Setup + required objects
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var selectAlternative = new SelectAlternativePageObjects();

            //Call route to alternative
            string benefitRequired = "IP";
            RouteToAlternativeSR51(driver, benefitRequired, browserName);

            //Transition to PNQ
            selectAlternative.ProvidersNotQuotingSelectSR51(driver);

            //Click help icon & validate arrival
            var common = new CommonSolutionBuilderPageObjects();
            string validationPath = "html/body/div[2]/hidden/div/div/button";
            common.HelpOverlayOpenValidateByPath(driver, validationPath);
            Assert.IsTrue(driver.FindElement(By.XPath(validationPath)).Displayed);

            //Then return to Select Alternative screen
            string pageValidator = "backToBenefitsButton";
            string buttonPath = "html/body/div[2]/hidden/div/div/button";
            common.HelpOverlayCloseSpecified(driver, pageValidator, buttonPath);
            Assert.IsTrue(driver.FindElement(By.Id(pageValidator)).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }



        //TEST THIRTEEN
        //Actually select an alternative - return to results screen
        [Test, Parallelizable, Description("Open SA Screen and Select Second Option")]
        public void ActuallySelectAnAlternativeSR51(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup + required objects
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var selectAlternative = new SelectAlternativePageObjects();
            var commonObjects = new CommonSupportObjects();

            //Call route to alternative
            string benefitRequired = "LTA";
            RouteToAlternativeSR51(driver, benefitRequired, browserName);

            //Choose second option
            int productInTable = 1;
            selectAlternative.SelectAlternativeSelect(driver, productInTable);

            //Assert return to the Results screen, all displayed
            string pageValidator = "premiumCellMenuButton";
            new CommonSolutionBuilderPageObjects().GenericWait(driver, pageValidator);
            
            //bool returnResults = driver.FindElement(By.Id("premiumCellMenuButton")).Displayed;
            bool returnResults = driver.FindElement(By.Id("resultsSummaryBenefitAndClientDetails")).Displayed;
            Assert.IsTrue(returnResults);

            //Call Cleanup
            CleanUp(driver);
        }


        //TEST FOURTEEN
        //All IP Premium Options Validation
        [Test, Parallelizable, Description("PHI Select Alternative Premium Filters")]
        public void PhiPremiumFiltersSelectAlternativeSR51(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup + required objects
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var selectAlternative = new SelectAlternativePageObjects();
            var commonObjects = new CommonSupportObjects();

            //Call route to alternative
            string benefitRequired = "IP";
            RouteToAlternativeSR51(driver, benefitRequired, browserName);

            //Hit Guaranteed and check redraw
            selectAlternative.SelectAlternativeFilterGuaranteedSR51(driver);
            bool reDrawG = driver.FindElement(By.Id("quote-result-guaranteed_0")).Displayed;
            Assert.IsTrue(reDrawG);

            //Hit Reviewable and check redraw
            selectAlternative.SelectAlternativeFilterReviewableSR51(driver);
            bool reDrawR = driver.FindElement(By.Id("quote-result-reviewable_0")).Displayed;
            Assert.IsTrue(reDrawR);

            //Hit ALL Premiums and check redraw
            selectAlternative.SelectAlternativeFilterAllSR51(driver);
            
            //Check if Reviewable/Guaranteed is present:
            string elementIdG = "quote-result-guaranteed_0";
            bool GuaranteedPresent = commonObjects.ElementPresentConfirmById(driver, elementIdG);

            string elementIdR = "quote-result-reviewable_0";
            bool ReviewablePresent = commonObjects.ElementPresentConfirmById(driver, elementIdR);

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


        //TEST FIFTEEN
        //Providers Not Quoting Navigation
        [Test, Parallelizable, Description("Navigate to PNQ")]
        public void PNQNavigationSelectAlternativeSR51(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup + required objects
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var selectAlternative = new SelectAlternativePageObjects();
            var commonObjects = new CommonSupportObjects();

            //Call route to alternative
            string benefitRequired = "LTA";
            RouteToAlternativeSR51(driver, benefitRequired, browserName);

            //Select PNQ...
            selectAlternative.ProvidersNotQuotingSelectSR51(driver);
            
            //...and validate
            int rowInstance = 0;
            bool hitPnq = driver.FindElement(By.Id("pnqExclusionType_" + rowInstance)).Displayed;
            Assert.IsTrue(hitPnq);

            //Select to expand first row
            selectAlternative.ProvidersNotQuotingExpandDetailsSR51(driver, rowInstance);

            //Validate that detailsa re displayed
            bool expandOkay = driver.FindElement(By.Id("pnq-more-details_" + rowInstance)).Displayed;
            Assert.IsTrue(expandOkay);
 
            //Hit quote results to navigate back & check okay
            selectAlternative.ProvidersQuotingSelectSR51(driver);
            bool returnToQuotes = driver.FindElement(By.Id("quote-results-quote-button_0")).Displayed;
            Assert.IsTrue(returnToQuotes);

            //Call Cleanup
            CleanUp(driver);
        }


        //TEST SIXTEEN
        //IP Age Banded + Limited Payment Options Validation
        [Test, Parallelizable, Description("PHI Select Alternative Age & Payment Filters")]
        public void PhiAgePaymentFiltersSelectAlternativeSR51(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup + required objects
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var selectAlternative = new SelectAlternativePageObjects();
            var commonObjects = new CommonSupportObjects();

            //Call route to alternative
            string benefitRequired = "IP";
            RouteToAlternativeSR51(driver, benefitRequired, browserName);

            //Hit Age Banded only and check redraw
            selectAlternative.SelectAlternativeFilterAgeBandedSR51(driver);
            bool reDrawAge = driver.FindElement(By.Id("quote-result-age-banded_0")).Displayed;
            Assert.IsTrue(reDrawAge);
            
            //Hit Limited Payment only and check redraw
            selectAlternative.SelectAlternativeFilterAgeBandedSR51(driver);
            selectAlternative.SelectAlternativeFilterLimitedPaymenSR51(driver);
            bool reDrawPay = driver.FindElement(By.Id("quote-result-limited-payment-period_0")).Displayed;
            Assert.IsTrue(reDrawPay);

            //Clear options and check page redraws okay
            selectAlternative.SelectAlternativeFilterLimitedPaymenSR51(driver);
            //string firstElementId = "quote-result-age-banded_0";
            //string secondElementId = "quote-result-limited-payment-period_0";
            //BUT WITH ANY INT:
            //bool reDrawAll = commonObjects.ElementOneOrElementTwoPresentById(driver, firstElementId, secondElementId)
            //Assert.IsTrue(reDrawAll);
            
            //Call Cleanup
            CleanUp(driver);
        }



        #endregion

        #endregion
    }
}
