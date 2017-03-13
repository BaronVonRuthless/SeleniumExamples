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

namespace SolutionBuilderClientDetailsTESTS
{
    //
    //
    //

    public class BenefitSelectionPage : TestBase
    {
        #region Support Methods

        //A bundle to quickly get you to the New Client Page
        public void RouteToBenefits(IWebDriver driver)
        {
            // Use login methods to call page, validate and attempt login
            var support = new DashboardPage();
            support.RouteToDashboard(driver);

            //Click through to New Quote
            var Benefits = new DashboardPageObjects();
            Benefits.NewQuote(driver);

        }

        #endregion

        #region Tests

        ////TEST ONE
        //Help Overlay
        [Test, Parallelizable, Description("Link to Help Overlay")]
        public void HelpLinkBenefits(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Benefits - validate
            var support = new BenefitSelectionPage();
            support.RouteToBenefits(driver);

            //Click help icon
            var common = new CommonSolutionBuilderPageObjects();
            common.HelpOverlayOpenBenefits(driver);
            string pageValidator = "benefit-summary";
            common.HelpOverlayClose(driver, pageValidator);
            Assert.IsTrue(driver.Title.Equals("Solution Builder"));

            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST TWO
        //CHeck links out - add new client
        [Test, Parallelizable, Description("Link out to Add New Client")]
        public void AddClientBenefits(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Benefits - validate
            var support = new BenefitSelectionPage();
            support.RouteToBenefits(driver);

            //CLick through to New Client
            var Benefits = new CommonSolutionBuilderPageObjects();
            Benefits.AddClientButton(driver);
            Assert.IsTrue(driver.FindElement(By.Id("firstlifegenderfemale")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }


        ////CLIENT SEARCH
        //Return to Dashboard
        [Test, Parallelizable, Description("Link to Dashboard")]
        public void LinkToDashboardBenefits(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Benefits - validate
            var support = new BenefitSelectionPage();
            support.RouteToBenefits(driver);

            //Click Client Search Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.ClientSearchButton(driver);

            //Validate dashboard page reached.
            Assert.IsTrue(driver.FindElement(By.Id("resultsSearchTitle")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////CLIENT HISTORY
        //Return directly to Client History
        [Test, Parallelizable, Description("Client History Button")]
        public void ClientHistoryButtonBenefits(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Benefits - validate
            var support = new BenefitSelectionPage();
            support.RouteToBenefits(driver);

            //Click client history Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.ClientHistoryButton(driver);

            //Validate client histroy page reached.
            Assert.IsTrue(driver.FindElement(By.Id("client-history")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////EDIT CLIENT
        //View/Edit Client history link
        [Test, Parallelizable, Description("View Edit Client Button")]
        public void ViewEditClientButtonBenefits(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Benefits - validate
            var support = new BenefitSelectionPage();
            support.RouteToBenefits(driver);

            //Click view edit client Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.EditClientButton(driver);

            //Validate client details page reached - Find field and ensure contains "Mr"
            Assert.AreEqual(driver.FindElement(By.Id("firstlifetitle")).GetAttribute("value"), "Mr");

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST FOUR
        //Back to My Services using header button
        [Test, Parallelizable, Description("Link Back to Services")]
        public void MyServicesLinkBenefits(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Benefits - validate
            var support = new BenefitSelectionPage();
            support.RouteToBenefits(driver);

            //Select My "iPipeline"
            var common = new CommonSolutionBuilderPageObjects();
            common.MyServicesButtonDialogue(driver);

            //Confirm dialogue text is correct:
            string messageText = Constants.CHANGES;
            common.ValidateDialogueDisplayText(driver, messageText);

            //Cancel dialogue
            common.DialogueClose(driver);

            //Re-select myservices and exit
            common.MyServicesButtonDialogue(driver);
            common.DialogueYes(driver);
            string pageValidator = "SolutionBuilder-btn";
            common.GenericWait(driver, pageValidator);

            Assert.IsTrue(driver.Title.Equals("iPipeline - My iPipeline Services"));

            ////Call Cleanup
            CleanUp(driver);
        }



        ////TEST FIVE
        //Logout
        [Test, Parallelizable, Description("Header Logout Button")]
        public void LogoutButtonBenefits(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Benefits - validate
            var support = new BenefitSelectionPage();
            support.RouteToBenefits(driver);

            //Select "Logout"
            var common = new CommonSolutionBuilderPageObjects();
            common.LogoutButton(driver);
            common.DialogueYes(driver);
            string pageValidator = "UserName";
            common.GenericWait(driver, pageValidator);

            //Confirm login page reached
            Assert.IsTrue(driver.Title.Equals("iPipeline Login"));

            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST SIX - INDICATIVE PREMIUM
        //Indicative Premium Checker
        [Test, Parallelizable, Description("Check Indicative Total")]
        public void IndicativeTotalNoBenefits(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var route = new BenefitSelectionPage();
            var objects = new BenefitSelectionPageObjects();
            var expectedIndicativeTotal = "0";

            //Call Shortcut to Benefits - validate
            route.RouteToBenefits(driver);

            //Read indicative total value and store
            var returnTotalValue = objects.TotalIndicativePremiumReader(driver);

            //Remove "£" if present
            var indicativeValueTotal = returnTotalValue.Replace("£", "");

            //Compare to "0"
            Assert.AreEqual(indicativeValueTotal, expectedIndicativeTotal);

            //Call Cleanup
            CleanUp(driver);
        }


        //////TEST SEVEN - BEENFIT COMBINATIONS
        ////Check that the matrix, edit and delete links are present for benefits.
        //[Test, Parallelizable, Description("Check Combined Protection Benefits Don't Exceed Five")]
        //public void BenefitCombinationsAllBenefits(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        //{
        //    // Call Setup
        //    var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
        //    var route = new BenefitSelectionPage();
        //    var objects = new BenefitSelectionPageObjects();

        //    ////use an array to load in a bunch of benefits and them chug through combinations?

        //    //Call Cleanup
        //    CleanUp(driver);
        //}


        ////TEST EIGHT - BENFIT COMBINATIONS - WOL
        //Check that the correct number of benefits is selctable
        [Test, Parallelizable, Description("Check the Benefit Combination Options - Whole of Life")]
        public void BenefitCombinationsWOL(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup + Get to Benefits
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            new BenefitSelectionPage().RouteToBenefits(driver);

            //Add WOL + Input basic details and Save out to Benefit Selection screen
            var common = new CommonSupportObjects();
            common.AddBasicWholeOfLifeBenefit(driver);

            //Check that other benefits are hidden and that text is displayed:
            string infoText = driver.FindElement(By.Id("benefit-summary")).Text.Trim();
            Assert.Contains(infoText, "Whole of Life can only be requested as a single benefit");

            bool benefitSelector = driver.FindElement(By.Id("benefit-selector")).Displayed;
            Assert.IsFalse(benefitSelector);

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST NINE - BENFIT COMBINATIONS - BP
        //Check that the correct number of benefits is selctable
        [Test, Parallelizable, Description("Check the Benefit Combination Options - Business Protection")]
        public void BenefitCombinationsBP(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            new BenefitSelectionPage().RouteToBenefits(driver);

            //QAdd BP + input basic details and Save out to Benefit Selection screen
            var common = new CommonSupportObjects();
            common.AddBasicBusinessProtectionBenefit(driver);

            //Check that other benefits are hidden and that text is displayed:
            string infoText = driver.FindElement(By.Id("benefit-summary")).Text.Trim();
            Assert.Contains(infoText, "Business Protection can only be requested as a single benefit");

            bool benefitSelector = driver.FindElement(By.Id("benefit-selector")).Displayed;
            Assert.IsFalse(benefitSelector);

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST TEN - BENFIT SUMMARY OPTIONS - WOL
        //Check that the correct number of benefits is selctable
        [Test, Parallelizable, Description("Check the Benefit Options - Whole of Life")]
        public void BenefitSummaryOptionsWOL(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup + Get to Benefits
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            new BenefitSelectionPage().RouteToBenefits(driver);
            var benefits = new BenefitSelectionPageObjects();
            var common = new CommonSolutionBuilderPageObjects();
            string benefitId = "wol";

            //Add WOL + Input basic details and Save out to Benefit Selection screen
            var support = new CommonSupportObjects();
            support.AddBasicWholeOfLifeBenefit(driver);

            //Call ElementNotPresentConfirm to confirm matrix option is not present
            {    
                string elementId = (benefitId + "SummaryMatrix");
                bool checkForMatrix = support.ElementPresentConfirmById(driver, elementId);
                Assert.IsFalse(checkForMatrix);
            }

            //Use Edit to return to benefit and then re-Save
            benefits.EditBenefitFromSummary(driver, benefitId);
            common.BenefitSaveButton(driver, benefitId);

            //Check that other benefits are hidden and that text is displayed:
            string infoText = driver.FindElement(By.Id("benefit-summary")).Text.Trim();
            Assert.Contains(infoText, "Whole of Life can only be requested as a single benefit");

            bool benefitSelector = driver.FindElement(By.Id("benefit-selector")).Displayed;
            Assert.IsFalse(benefitSelector);

            //Delete WOL
            benefits.DeleteBenefitFromSummaryConfirmDialogue(driver, benefitId);

            //wolSummary no longer present!
            {
                string elementId = (benefitId + "SummaryDelete");
                bool checkForSummary = support.ElementPresentConfirmById(driver, elementId);
                Assert.IsFalse(checkForSummary);
            }

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST ELEVEN - BENFIT SUMMARY OPTIONS - BP
        //Check that the correct number of benefits is selctable
        [Test, Parallelizable, Description("Check the Benefit Options - Business Protection")]
        public void BenefitSummaryOptionsBP(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup + Get to Benefits
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            new BenefitSelectionPage().RouteToBenefits(driver);
            var benefits = new BenefitSelectionPageObjects();
            var common = new CommonSolutionBuilderPageObjects();
            string benefitId = "bp";

            //Add WOL + Input basic details and Save out to Benefit Selection screen
            var support = new CommonSupportObjects();
            support.AddBasicBusinessProtectionBenefit(driver);

            //Check matrix is accesible
            benefits.EnterMatrixFromSummary(driver, benefitId);
            new MatrixScreenPageObjects().ExitToBenefitSelectionScreen(driver);

            //Use Edit to return to benefit and then re-Save
            benefits.EditBenefitFromSummary(driver, benefitId);
            common.BenefitSaveButton(driver, benefitId);

            //Check that other benefits are hidden and that text is displayed:
            string infoText = driver.FindElement(By.Id("benefit-summary")).Text.Trim();
            Assert.Contains(infoText, "Business Protection can only be requested as a single benefit");

            bool benefitSelector = driver.FindElement(By.Id("benefit-selector")).Displayed;
            Assert.IsFalse(benefitSelector);

            //Delete BP
            benefits.DeleteBenefitFromSummaryConfirmDialogue(driver, benefitId);

            //bpSummary no longer present!
                string elementId = (benefitId + "SummaryDelete");
                bool checkForSummary = support.ElementPresentConfirmById(driver, elementId);
                Assert.IsFalse(checkForSummary);

            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST TWELVE - BENFIT SUMMARY OPTIONS - ALL BENEFITS
        //Check that the correct number of benefits is selctable
        [Test, Parallelizable, Description("Check the Benefit Options - AllBenefits")]
        public void BenefitSummaryOptionsAllBenefits(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup + Get to Benefits
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            new BenefitSelectionPage().RouteToBenefits(driver);
            
            //Setup array for all benefits (not BP and WOL, soz.
            string[] benefitArray = new string[] { "ip", "dta", "fib", "lta" };

            //Use for each loop to itterate through each beenfit
            foreach (string item in benefitArray)
            {
                //Set benefitId to item key
                string benefitId = item;
                
                //Call the Common Summary Checker
                var benefits = new BenefitSelectionPageObjects();
                benefits.CommonBenefitSummaryChecker(driver, benefitId, browserName);

                //Check that other benefits are avaialble and that text is displayed:
                string infoText = driver.FindElement(By.Id("benefit-summary")).Text.Trim();
                Assert.Contains(infoText, "You have added 1 benefit. You can enter 4 more");

                bool benefitSelector = driver.FindElement(By.Id("benefit-selector")).Displayed;
                Assert.IsTrue(benefitSelector);

                string wholeOfLifeOption = driver.FindElement(By.Id("select-benefit-wol")).GetAttribute("disabled");
                Assert.AreEqual(wholeOfLifeOption, "true");

                string businessProtectionOption = driver.FindElement(By.Id("select-benefit-bp")).GetAttribute("disabled");
                Assert.AreEqual(businessProtectionOption, "true");

                bool otherBenefits = driver.FindElement(By.Id("select-benefit-"+benefitId)).Enabled;
                Assert.IsTrue(otherBenefits);

                //Delete benefit
                benefits.DeleteBenefitFromSummaryConfirmDialogue(driver, benefitId);

                //Check summary is no longer present!
                string elementId = (benefitId + "SummaryDelete");
                bool checkForSummary = new CommonSupportObjects().ElementPresentConfirmById(driver, elementId);
                Assert.IsFalse(checkForSummary);
            }

            //Call Cleanup
            CleanUp(driver);
        }


        #endregion
    }
}
