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

    public class SingleLifeResultsScreen : TestBase
    {
        #region Support Methods

        ////ROUTE TO RESULTS
        //A simple single life quote (LTA or IP)  - Get to Results!
        public void RouteToResultsSingleLife(IWebDriver driver, string benefitRequired, string browserName)
        {
            //Use Route to Benefit Selection to login + add client
            new BenefitSelectionPage().RouteToBenefits(driver);

            //Add IP
            if (benefitRequired == "IP")
            {
                //Add IP using minimal details (will default to ALL PREMIUMS)
                new CommonSupportObjects().AddBasicIncomeProtectionBenefit(driver, browserName);
            }
            //Add LTA
            else if (benefitRequired == "LTA")
            {
                //Add IP using minimal details (will default to ALL PREMIUMS)
                new CommonSupportObjects().AddBasicLevelTermBenefit(driver);
            }
            //Add DTA
            else if (benefitRequired == "DTA")
            {
                //Add IP using minimal details (will default to ALL PREMIUMS)
                new CommonSupportObjects().AddBasicDecreasingTermBenefit(driver);
            }
            //Add FIB
            else if (benefitRequired == "FIB")
            {
                //Add IP using minimal details (will default to ALL PREMIUMS)
                new CommonSupportObjects().AddBasicFamilyIncomeBenefit(driver);
            }
            //Add BP
            else if (benefitRequired == "BP")
            {
                //Add IP using minimal details (will default to ALL PREMIUMS)
                new CommonSupportObjects().AddBasicBusinessProtectionBenefit(driver);
            }
            //Add WOL
            else if (benefitRequired == "WOL")
            {
                //Add IP using minimal details (will default to ALL PREMIUMS)
                new CommonSupportObjects().AddBasicWholeOfLifeBenefit(driver);
            }

            //Quote!
            new BenefitSelectionPageObjects().QuoteNow(driver);
        }

        #endregion

        #region Tests

        ////TEST ONE
        //Check Client History Link
        [Test, Parallelizable, Description("Link to Dashboard")]
        public void LinkToDashboardSingleLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To SingleLifeResults to get to SingleLifeResults Page:
            var setupRoute = new SingleLifeResultsScreen();
            string benefitRequired = "LTA";
            setupRoute.RouteToResultsSingleLife(driver, benefitRequired, browserName);

            //Click Client Search Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.ClientSearchButton(driver);

            //Validate dashboard page reached.
            Assert.IsTrue(driver.FindElement(By.Id("resultsSearchTitle")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST TWO
        //Client History
        [Test, Parallelizable, Description("Client History Button")]
        public void ClientHistoryButtonSingleLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To SingleLifeResults to get to SingleLifeResults Page:
            var setupRoute = new SingleLifeResultsScreen();
            string benefitRequired = "LTA";
            setupRoute.RouteToResultsSingleLife(driver, benefitRequired, browserName);

            //Click client history Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.ClientHistoryButton(driver);

            //Validate client histroy page reached.
            Assert.IsTrue(driver.FindElement(By.Id("client-history")).Displayed);

            driver.Navigate().GoToUrl("");

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST THREE
        //Add client button
        [Test, Parallelizable, Description("Add Client Button")]
        public void AddClientButtonSingleLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To SingleLifeResults to get to SingleLifeResults Page:
            var setupRoute = new SingleLifeResultsScreen();
            string benefitRequired = "LTA";
            setupRoute.RouteToResultsSingleLife(driver, benefitRequired, browserName);

            //Click add client Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.AddClientButton(driver);

            //Validate client details reached and page blank
            string attribute = driver.FindElement(By.Id("firstlifetitle")).GetAttribute("value");
            Assert.AreEqual(attribute, "");

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST FOUR
        //Back to My Services using header button
        [Test, Parallelizable, Description("Link Back to Services")]
        public void MyServicesLinkSingleLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To SingleLifeResults to get to SingleLifeResults Page:
            var setupRoute = new SingleLifeResultsScreen();
            string benefitRequired = "LTA";
            setupRoute.RouteToResultsSingleLife(driver, benefitRequired, browserName);

            //Click my services Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.MyServicesButton(driver);

            //Validate my services page reached.
            Assert.IsTrue(driver.FindElement(By.Id("Assureweb-btn")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST FIVE
        //Logout
        [Test, Parallelizable, Description("Header Logout Button")]
        public void LogoutButtonSingleLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To SingleLifeResults to get to SingleLifeResults Page:
            var setupRoute = new SingleLifeResultsScreen();
            string benefitRequired = "LTA";
            setupRoute.RouteToResultsSingleLife(driver, benefitRequired, browserName);

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

        ////TEST SIX
        //Click the View/Edit client button
        [Test, Parallelizable, Description("View Edit Client Button")]
        public void ViewEditClientButtonSingleLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To SingleLifeResults to get to SingleLifeResults Page:
            var setupRoute = new SingleLifeResultsScreen();
            string benefitRequired = "LTA";
            setupRoute.RouteToResultsSingleLife(driver, benefitRequired, browserName);

            //Click view edit client Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.EditClientButton(driver);

            //Validate client details page reached - Find field and ensure contains "Mr"
            Assert.AreEqual(driver.FindElement(By.Id("firstlifetitle")).GetAttribute("value"), "Mr");

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST SEVEN
        //Click the View/Edit client button
        [Test, Parallelizable, Description("View Edit Client Button")]
        public void NewQuoteButtonSingleLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To SingleLifeResults to get to SingleLifeResults Page:
            var setupRoute = new SingleLifeResultsScreen();
            string benefitRequired = "LTA";
            setupRoute.RouteToResultsSingleLife(driver, benefitRequired, browserName);

            //Click view edit client Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.NewQuoteButton(driver);

            //Validate client details page reached - Find field and ensure contains "Mr"
            Assert.IsTrue(driver.FindElement(By.Id("benefit-summary")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        //TEST EIGHT
        //Help Overlay
        [Test, Parallelizable, Description("Link to Help Overlay")]
        public void HelpLinkSingleLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To SingleLifeResults to get to SingleLifeResults Page:
            var setupRoute = new SingleLifeResultsScreen();
            string benefitRequired = "LTA";
            setupRoute.RouteToResultsSingleLife(driver, benefitRequired, browserName);

            //Click help icon
            var common = new CommonSolutionBuilderPageObjects();
            string validationPath = "html/body/div[7]/div";
            common.HelpOverlayOpenValidateByPath(driver, validationPath);
            string pageValidator = "resultsSummaryFullDetails";
            common.HelpOverlayCloseGeneric(driver, pageValidator);
            Assert.IsTrue(driver.Title.Equals("Solution Builder"));

            //Call Cleanup
            CleanUp(driver);
        }


        //QUICK QUOTE
        //quoteType = SingleBenefit
        //benefitInstance = ""
        //quoteTypeIcons = quickQuote
        //solutionType = quickQuote


        //TEST NINE
        //Link back to Benefit Details, assert benefit optiosns retained.
        [Test, Parallelizable, Description("Link to Benefit Input (Requote)")]
        public void RequoteSingleLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To SingleLifeResults to get to SingleLifeResults Page:
            var setupRoute = new SingleLifeResultsScreen();
            string benefitRequired = "LTA";
            setupRoute.RouteToResultsSingleLife(driver, benefitRequired, browserName);

            //Click Requote icon
            new CommonResultsPageObjects().Requote(driver);

            //Wait for page to load
            string pageValidator = "benefit-summary";
            new CommonSolutionBuilderPageObjects().SpinnerWait(driver, pageValidator);

            //Are we in the right place?
            string wholeOfLifeOption = driver.FindElement(By.Id("select-benefit-wol")).GetAttribute("disabled");
            Assert.AreEqual(wholeOfLifeOption, "true");

            //Call Cleanup
            CleanUp(driver);
        }



        //TEST TEN
        //Link to new Print Window, check and close.
        [Test, Parallelizable, Description("Link to Print - New Window")]
        public void PrintSingleLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Select Alternative - first option
            string benefitRequired = "LTA";
            new SelectAlternativeScreen().RouteToAlternative(driver, benefitRequired, browserName);

            //Check the second product in the list
            int productInTable = 1;
            new SelectAlternativePageObjects().SelectAlternativeSelect(driver, productInTable);

            //Click PRINT icon *****ASSUMES PRINT ICON IS ACTIVE*****
            string thisWindow = new CommonResultsPageObjects().Print(driver);

            //Generic wait
            driver.WaitForUpTo(60, "Didn't make it to the expected page. Did not find: results PDF.")
            .Until(ExpectedConditions.UrlContains("GetResultsPagePdfPrint"));

            //Validate print page by address
            string getUrl = driver.Url.ToString().Trim();
            Assert.Contains(getUrl, "ResultsSnapshot");

            //Close Window and validate return
            new CommonSolutionBuilderPageObjects().NewWindowClose(driver, thisWindow);

            //Call Cleanup
            CleanUp(driver);
        }


        //TEST ELEVEN
        //Open FUll Details screen , check and close.
        [Test, Parallelizable, Description("Full Details modal")]
        public void FullDetailsSingleLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To SingleLifeResults to get to SingleLifeResults Page:
            var setupRoute = new SingleLifeResultsScreen();
            string benefitRequired = "LTA";
            setupRoute.RouteToResultsSingleLife(driver, benefitRequired, browserName);

            //Click FIRST Full Details icon
            var commonResults = new CommonResultsPageObjects();
            commonResults.FullDetailsSingleOpen(driver);

            //Wait to load, just in case:
            string pageValidator = "resultsSummaryInputs";
            new CommonSolutionBuilderPageObjects().GenericWait(driver, pageValidator);

            //Confirm details:
            string benefitTitle = commonResults.FullDetailsReadTitleSingle(driver);
            Assert.Contains(benefitTitle, "Level Term Assurance");

            //Close with this:
            commonResults.FullDetailsClose(driver);

            //Call Cleanup
            CleanUp(driver);
        }


        //TEST TWELVE
        //Open select alternative from results screen icon
        [Test, Parallelizable, Description("Glyph Icon link to Select Alternatives")]
        public void SelectAlternativesIconSingleLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To SingleLifeResults to get to SingleLifeResults Page:
            var setupRoute = new SingleLifeResultsScreen();
            string benefitRequired = "LTA";
            setupRoute.RouteToResultsSingleLife(driver, benefitRequired, browserName);

            //Click SelectAlternative icon
            var commonResults = new CommonResultsPageObjects();
            string quoteType = "SingleBenefit";
            string benefitInstance = "";
            commonResults.SelectAlternativeIcon(driver, quoteType, benefitInstance);

            //Wait for SelectAlternative to load
            string pageValidator = "premiumCellResultsClose";
            new CommonSolutionBuilderPageObjects().GenericWait(driver, pageValidator);

            //Close
            new SelectAlternativePageObjects().SelectAlternativeClose(driver);

            //Call Cleanup
            CleanUp(driver);
        }


        //TEST THIRTEEN
        //Open PNQ from results screen icon
        [Test, Parallelizable, Description("Glyph Icon link to Products not Quoting")]
        public void PNQIconSingleLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To SingleLifeResults to get to SingleLifeResults Page:
            var setupRoute = new SingleLifeResultsScreen();
            string benefitRequired = "LTA";
            setupRoute.RouteToResultsSingleLife(driver, benefitRequired, browserName);

            //Click Products Not Quoting  icon
            var commonResults = new CommonResultsPageObjects();
            string quoteType = "SingleBenefit";
            string benefitInstance = "";
            commonResults.ProductsNotQuotingIcon(driver, quoteType, benefitInstance);

            //Wait for SelectAlternative to load
            string pageValidator = "providersNotQuotingModalBody";
            new CommonSolutionBuilderPageObjects().GenericWait(driver, pageValidator);

            //Close
            new SelectAlternativePageObjects().SelectAlternativeClose(driver);

            //Call Cleanup
            CleanUp(driver);
        }





        //TEST SIXTEEN
        //Check for Reviewable or Guaranteed Icon in results pane
        [Test, Parallelizable, Description("REviewable OR Guaranteed Icon Displayed")]
        public void PremiumTypeIconSingleLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To SingleLifeResults to get to SingleLifeResults Page:
            string benefitRequired = "IP";
            new SingleLifeResultsScreen().RouteToResultsSingleLife(driver, benefitRequired, browserName);

            //Check results page for one icon or the other
            string firstElementId = "ReviewableLabel";
            string secondElementId = "GuaranteedLabel";
            bool presentResultsPage = new CommonSupportObjects().ElementOneOrElementTwoPresentById(driver, firstElementId, secondElementId);
            Assert.IsTrue(presentResultsPage);

            //Click SelectAlternative icon
            string quoteType = "SingleBenefit";
            string benefitInstance = "";
            new CommonResultsPageObjects().SelectAlternativeIcon(driver, quoteType, benefitInstance);

            //Wait for SelectAlternative to load
            string pageValidator = "premiumCellResultsClose";
            new CommonSolutionBuilderPageObjects().GenericWait(driver, pageValidator);

            //Check for one icon or the other by base class
            var presentSelectAlternativePage = driver.FindElement(By.ClassName("label")).Displayed.ToString();
            Assert.IsNotNull(presentSelectAlternativePage);

            //Close
            new SelectAlternativePageObjects().SelectAlternativeClose(driver);

            //Call Cleanup
            CleanUp(driver);
        }





        //TEST FOURTEEN
        //Open XRAE product infomration from results screen icon (if present)
        [Test, Parallelizable, Description("Glyph Icon link to XRAE details")]
        public void XraeIconSingleLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Select Alternative - first option
            string benefitRequired = "LTA";
            new SelectAlternativeScreen().RouteToAlternative(driver, benefitRequired, browserName);

            //Check the second product in the list
            int productInTable = 1;
            new SelectAlternativePageObjects().SelectAlternativeSelect(driver, productInTable);

            //Click XRAE Icon..
            string quoteTypeLower = "quickQuote";

            //...but only if it's displayed...
            string elementPath = ".//*[@id='" + quoteTypeLower + "PremiumCell" + "']/div/div[2]/div[1]/div[2]/div/span/span/i[2]";
            bool elementPresent = new CommonSupportObjects().ElementPresentConfirmByXpath(driver, elementPath);

            //...then go get it.
            if (elementPresent == true)
            {
                new CommonResultsPageObjects().XraeIconSingleJoint(driver, quoteTypeLower);

                //Wait for Quote Details to load
                string pageValidator = "productDetailsDialog";
                new CommonSolutionBuilderPageObjects().SpinnerWait(driver, pageValidator);

                //Assert...
                Assert.IsTrue(driver.FindElement(By.Id("xraeRatings_ProviderWarningsChevron")).Displayed);

                //Close
                new PremiumCellMenuObjects().QuoteDetailsClose(driver);
            }

            //Call Cleanup
            CleanUp(driver);
        }


        //TEST FIFTEEN
        //Open Product Warnings from results screen icon (if present)
        [Test, Parallelizable, Description("Glyph Icon link to Product Warnings")]
        public void WarningsIconSingleLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Select Alternative - first option
            string benefitRequired = "LTA";
            new SelectAlternativeScreen().RouteToAlternative(driver, benefitRequired, browserName);

            //Check the second product in the list
            int productInTable = 1;
            new SelectAlternativePageObjects().SelectAlternativeSelect(driver, productInTable);

            //Set variables for click action
            string quoteType = "SingleBenefit";
            string benefitInstance = "";

            //Check if Warning is present:
            string elementId = "premiumCellQuoteWarning_" + quoteType + "_" + benefitInstance;
            bool warningsPresent = new CommonSupportObjects().ElementPresentConfirmById(driver, elementId);

            if (warningsPresent == true)
            {
                new CommonResultsPageObjects().ProductWarningsIcon(driver, quoteType, benefitInstance);

                //Wait for Quote Details to load
                string pageValidator = "productDetailsDialog";
                new CommonSolutionBuilderPageObjects().SpinnerWait(driver, pageValidator);

                //Assert...
                Assert.IsTrue(driver.FindElement(By.Id("productDetails_ProviderWarningsChevron")).Displayed);
                
                //Close
                new PremiumCellMenuObjects().QuoteDetailsClose(driver);
            }

            //Call Cleanup
            CleanUp(driver);
        }

        #endregion
    }
}
