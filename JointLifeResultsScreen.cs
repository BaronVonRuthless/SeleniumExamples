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

    public class JointLifeResultsScreen : TestBase
    {
        #region Support Method

        ////ROUTE TO RESULTS
        //A simple joint life quote (LTA)  - Get to Results!
        public void RouteToResultsJointLife(IWebDriver driver)
        {   
            //Specify required pages:
            var level = new LevelTermPageObjects();
            var benefitPage = new BenefitSelectionPageObjects();
            
            //Use Route to Benefit Selection to login + add client
            new BenefitSelectionPage().RouteToBenefits(driver);

            //Specify required values
            string termYears = Constants.ltaTERMYEARS;
            string levelTermValue = Constants.ltaTERMVALUE;
            string benefitId = "lta";
            
            //Call benefit page and add LTA, select JOINT LIFE
            benefitPage.AddNewBenefit(driver, benefitId);
            level.LTASelectJoint(driver);
            
            //Fill in basic details, click save.
            level.LTAMinimalBenefitDetails(driver, termYears, levelTermValue);
            new CommonSolutionBuilderPageObjects().BenefitSaveButton(driver, benefitId);

            //Quote!
            benefitPage.QuoteNow(driver);
        }

        #endregion

        #region Tests

        ////TEST ONE
        //Check Client History Link
        [Test, Parallelizable, Description("Link to Dashboard")]
        public void LinkToDashboardJointLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To JointLifeResults to get to JointLifeResults Page:
            var setupRoute = new JointLifeResultsScreen();
            setupRoute.RouteToResultsJointLife(driver);

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
        public void ClientHistoryButtonJointLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To JointLifeResults to get to JointLifeResults Page:
            var setupRoute = new JointLifeResultsScreen();
            setupRoute.RouteToResultsJointLife(driver);

            //Click client history Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.ClientHistoryButton(driver);

            //Validate client histroy page reached.
            Assert.IsTrue(driver.FindElement(By.Id("client-history")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST THREE
        //Add client button
        [Test, Parallelizable, Description("Add Client Button")]
        public void AddClientButtonJointLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To JointLifeResults to get to JointLifeResults Page:
            var setupRoute = new JointLifeResultsScreen();
            setupRoute.RouteToResultsJointLife(driver);

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
        public void MyServicesLinkJointLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To JointLifeResults to get to JointLifeResults Page:
            var setupRoute = new JointLifeResultsScreen();
            setupRoute.RouteToResultsJointLife(driver);

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
        public void LogoutButtonJointLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To JointLifeResults to get to JointLifeResults Page:
            var setupRoute = new JointLifeResultsScreen();
            setupRoute.RouteToResultsJointLife(driver);

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
        public void ViewEditClientButtonJointLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To JointLifeResults to get to JointLifeResults Page:
            var setupRoute = new JointLifeResultsScreen();
            setupRoute.RouteToResultsJointLife(driver);

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
        public void NewQuoteButtonJointLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To JointLife to get to JointLifeResults Page:
            var setupRoute = new JointLifeResultsScreen();
            setupRoute.RouteToResultsJointLife(driver);

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
        public void HelpLinkJointLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To JointLifeResults to get to JointLifeResults Page:
            var setupRoute = new JointLifeResultsScreen();
            setupRoute.RouteToResultsJointLife(driver);

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


        //JOINT LIFE
        //quoteType = JointLife FIRST LINE, TwoSingleLives SECOND LINE
        //benefitInstance = JL, L1, L2
        //quoteTypeIcons = jointLivesResults, firstLifeResults, secondLifeResults
        //solutionType = jointPolicy, individualPolicy



        //TEST NINE
        //Link back to Benefit Details, assert benefit optiosns retained.
        [Test, Parallelizable, Description("Link to Benefit Input (Requote)")]
        public void RequoteJointLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To JointLifeResults to get to JointLifeResults Page:
            var setupRoute = new JointLifeResultsScreen();
            setupRoute.RouteToResultsJointLife(driver);

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
        public void PrintJointLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To JointLifeResults to get to JointLifeResults Page:
            var setupRoute = new JointLifeResultsScreen();
            setupRoute.RouteToResultsJointLife(driver);

            //**************************************
            //*****ASSUMES PRINT ICON IS ACTIVE*****
            //**************************************

            //Click PRINT icon
            string thisWindow = new CommonResultsPageObjects().Print(driver);

            //Generic wait
            //string pageValidator = "pageContainer1";
            var common = new CommonSolutionBuilderPageObjects();
            //common.GenericWait(driver, pageValidator);
            driver.WaitForUpTo(60, "Didn't make it to the expected page. Did not find: results PDF.")
                .Until(ExpectedConditions.UrlContains("GetResultsPagePdfPrint"));

            //Validate print page by address
            string getTitle = driver.Title.ToString();
            Assert.Contains(getTitle, "ResultsSnapshot");

            //Close Window and validate return
            common.NewWindowClose(driver, thisWindow);

            //Call Cleanup
            CleanUp(driver);
        }


        //TEST ELEVEN
        //Open FUll Details screen , check and close.
        [Test, Parallelizable, Description("Full Details modal")]
        public void FullDetailsJointLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To JointLifeResults to get to JointLifeResults Page:
            var setupRoute = new JointLifeResultsScreen();
            setupRoute.RouteToResultsJointLife(driver);

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


        ////TEST - Unable to verify popup across all browser types
        ////Click the title bar to open product title pop up
        //[Test, Parallelizable, Description("Title Bar Pop Up")]
        //public void TitleBarPopUpJointLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        //{
        //    // Call Setup
        //    var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

        //    //Use Route To JointLifeResults to get to JointLifeResults Page:
        //    var setupRoute = new JointLifeResultsScreen();
        //    setupRoute.RouteToResultsJointLife(driver);

        //    //Click help icon


        //    //Call Cleanup
        //    CleanUp(driver);
        //}


        //TEST TWELVE
        //Open select alternative from results screen icon
        [Test, Parallelizable, Description("Glyph Icon link to Select Alternatives")]
        public void SelectAlternativesIconJointLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To JointLifeResults to get to JointLifeResults Page:
            var setupRoute = new JointLifeResultsScreen();
            setupRoute.RouteToResultsJointLife(driver);

            //Click SelectAlternative icon
            var commonResults = new CommonResultsPageObjects();
            string quoteType = "JointLife";
            string benefitInstance = "JL";
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
        public void PNQIconJointLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To JointLifeResults to get to JointLifeResults Page:
            var setupRoute = new JointLifeResultsScreen();
            setupRoute.RouteToResultsJointLife(driver);

            //Click Products Not Quoting  icon
            var commonResults = new CommonResultsPageObjects();
            string quoteType = "JointLife";
            string benefitInstance = "JL";
            commonResults.ProductsNotQuotingIcon(driver, quoteType, benefitInstance);

            //Wait for SelectAlternative to load
            string pageValidator = "providersNotQuotingModalBody";
            new CommonSolutionBuilderPageObjects().GenericWait(driver, pageValidator);

            //Close
            new SelectAlternativePageObjects().SelectAlternativeClose(driver);

            //Call Cleanup
            CleanUp(driver);
        }


        //TEST FOURTEEN
        //Open XRAE product infomration from results screen icon (if present)
        [Test, Parallelizable, Description("Glyph Icon link to XRAE details")]
        public void XraeIconJointLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
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
            string quoteTypeLower = "jointLife";

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
        public void WarningsIconJointLifeResults(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
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
            string quoteType = "JointLife";
            string benefitInstance = "JL";

            ///Check if Warning is present:
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
