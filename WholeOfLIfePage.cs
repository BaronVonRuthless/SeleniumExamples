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

    public class WholeOfLifePage : TestBase
    {
        #region Support Methods

        //Get to WOL Page
        public void RouteToWOL(IWebDriver driver)
        {
            //Call Shortcut to Add Client - validate 
            var support = new DashboardPage();
            support.RouteToDashboard(driver);
            Assert.IsTrue(driver.FindElement(By.Id("btnAddClient")).Displayed);

            //Add New Quote
            var dashboard = new DashboardPageObjects();
            dashboard.NewQuote(driver);
            Assert.IsTrue(driver.FindElement(By.Id("benefit-summary")).Displayed);

            //Select WOL and wait for screen to load - validate page
            var benefit = new BenefitSelectionPageObjects();
            string benefitId = "wol";
            benefit.AddNewBenefit(driver, benefitId);
            Assert.IsTrue(driver.FindElement(By.Id("wolLifeCoverAmountnew")).Displayed);
        }

        #endregion

        #region Tests

        ////TEST ONE
        //Check Client Search Link
        [Test, Parallelizable, Description("Link to Dashboard")]
        public void LinkToDashboardWOL(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            
            //Use Route To WOL to get to WOL Page:
            var setupRoute = new WholeOfLifePage();
            setupRoute.RouteToWOL(driver);
            
            //Click Client Search Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.ClientSearchButtonDialogue(driver);

            //Summon Validator, Lord of Validation
            string messageText = Constants.BENEFIT;
            common.ValidateDialogueDisplayText(driver, messageText);

            //Cancel dialogue
            common.DialogueClose(driver);

            //Re-select Client Search and exit
            common.ClientSearchButtonDialogue(driver);
            string pageValidator = "clientSearchInput";
            common.DialogueYes(driver);
            common.SpinnerWait(driver, pageValidator);

            //Validate dashboard page reached.
            Assert.IsTrue(driver.FindElement(By.Id("resultsSearchTitle")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST TWO
        //Client History
        [Test, Parallelizable, Description("Client History Button")]
        public void ClientHistoryButtonWOL(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To WOL to get to WOL Page:
            var setupRoute = new WholeOfLifePage();
            setupRoute.RouteToWOL(driver);

            //Click client history Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.ClientHistoryButtonDialogue(driver);

            //Summon Validator, Lord of Validation
            string messageText = Constants.BENEFIT;
            common.ValidateDialogueDisplayText(driver, messageText);

            //Cancel dialogue
            common.DialogueClose(driver);

            //Re-select client history and exit
            common.ClientHistoryButtonDialogue(driver);
            common.DialogueYes(driver);
            string pageValidator = "navigation-bar";
            common.SpinnerWait(driver, pageValidator);

            //Validate client history page reached.
            Assert.IsTrue(driver.FindElement(By.Id("client-history")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST THREE
        //Add client button
        [Test, Parallelizable, Description("Add Client Button")]
        public void AddClientButtonWOL(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To WOL to get to WOL Page:
            var setupRoute = new WholeOfLifePage();
            setupRoute.RouteToWOL(driver);

            //Click add client Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.AddClientButtonDialogue(driver);

            //Summon Validator, Lord of Validation
            string messageText = Constants.BENEFIT;
            common.ValidateDialogueDisplayText(driver, messageText);

            //Cancel dialogue
            common.DialogueClose(driver);

            //Re-select add client and exit
            common.AddClientButtonDialogue(driver);
            string pageValidator = "clientDetails";
            common.DialogueYes(driver);
            common.SpinnerWait(driver, pageValidator);

            //Validate client details reached and page blank
            string attribute = driver.FindElement(By.Id("firstlifetitle")).GetAttribute("value");
            Assert.AreEqual(attribute, "");

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST FOUR
        //Back to My Services using header button
        [Test, Parallelizable, Description("Link Back to Services")]
        public void MyServicesLinkWOL(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To WOL to get to WOL Page:
            var setupRoute = new WholeOfLifePage();
            setupRoute.RouteToWOL(driver);

            //Click my services Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.MyServicesButtonDialogue(driver);

            //Summon Validator, Lord of Validation
            string messageText = Constants.CHANGES;
            common.ValidateDialogueDisplayText(driver, messageText);

            //Cancel dialogue
            common.DialogueClose(driver);

            //Re-select my servicea and exit
            common.MyServicesButtonDialogue(driver);
            common.DialogueYes(driver);
            string pageValidator = "SolutionBuilder-btn";
            common.GenericWait(driver, pageValidator);

            //Validate my services page reached.
            Assert.IsTrue(driver.FindElement(By.Id("Assureweb-btn")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST FIVE
        //Logout
        [Test, Parallelizable, Description("Header Logout Button")]
        public void LogoutButtonWOL(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To WOL to get to WOL Page:
            var setupRoute = new WholeOfLifePage();
            setupRoute.RouteToWOL(driver);

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
        public void ViewEditClientButtonWOL(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To WOL to get to WOL Page:
            var setupRoute = new WholeOfLifePage();
            setupRoute.RouteToWOL(driver);

            //Click View/Edit Client Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.EditClientButtonDialogue(driver);

            //Summon Validator, Lord of Validation
            string messageText = Constants.BENEFIT;
            common.ValidateDialogueDisplayText(driver, messageText);

            //Cancel dialogue
            common.DialogueClose(driver);

            //Re-select view edit client and exit
            common.EditClientButtonDialogue(driver);
            string pageValidator = "clientDetails";
            common.DialogueYes(driver);
            common.SpinnerWait(driver, pageValidator);

            //Validate client details page reached - Find field and ensure contains "Mr"
            string attribute = driver.FindElement(By.Id("firstlifetitle")).GetAttribute("value");
            Assert.AreEqual(attribute, "Mr");

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST SEVEN
        //Does the indicative premium populate AND CHANGE as the form is completed?
        [Test, Parallelizable, Description("Indicative Premium Active")]
        public void IndicativePremiumGenerationWOL(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To WOL to get to WOL Page:
            var setupRoute = new WholeOfLifePage();
            setupRoute.RouteToWOL(driver);

            //Set benefit ID as "WOL"
            string benefitId = "wol";

            //Read Indicative filed premium and match to blank "..." value
            var blankIndicativePremium = new CommonSolutionBuilderPageObjects().BenefitIndicativePremiumReader(driver, benefitId);
            Assert.AreEqual(blankIndicativePremium, "...");

            //Insert basic premium details
            var inputWOLValues = new WholeOfLifePageObjects();
            string sumAssured = Constants.wolSUMASSURED;
            inputWOLValues.WOLSumAssured(driver, sumAssured);

            //Check indicative field again and confirm value has updated
            var newIndicativePremium = new CommonSolutionBuilderPageObjects().BenefitIndicativePremiumReader(driver, benefitId);
            int indicativePremium = Int32.Parse(newIndicativePremium.Replace("£", ""));
            Assert.GreaterThan(indicativePremium, 0);

            //Save benefit and check premium has transfered through to Benefit Summary page
            var common = new CommonSolutionBuilderPageObjects();
            common.BenefitSaveButton(driver, benefitId);

            //Read out updated INdicative Total and compare to single benefit read.
            var returnTotalValue = new BenefitSelectionPageObjects().TotalIndicativePremiumReader(driver);
            int indicativeValueTotal = Int32.Parse(returnTotalValue.Replace("£", ""));
            Assert.AreEqual(indicativeValueTotal, indicativePremium);

            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST EIGHT
        //Do I get a warnign dialogue when I try to cancel?
        [Test, Parallelizable, Description("Cancel Button")]
        public void CancelButtonWOL(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To WOL to get to WOL Page:
            var setupRoute = new WholeOfLifePage();
            setupRoute.RouteToWOL(driver);

            //Click cancel Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            string benefitId = "wol";
            common.BenefitCancelButton(driver, benefitId);

            //Summon Validator, Lord of Validation
            string messageText = Constants.BENEFIT;
            common.ValidateDialogueDisplayText(driver, messageText);

            //Cancel dialogue
            common.DialogueClose(driver);

            //Re-select cancel and exit
            common.BenefitCancelButton(driver, benefitId);
            string pageValidator = "benefit-summary";
            common.DialogueYes(driver);
            common.SpinnerWait(driver, pageValidator);

            //Validate client details page reached - Find field and ensure contains "Mr"
            Assert.IsTrue(driver.FindElement(By.Id("select-benefit-wol")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST NINE
        //Check form validation standard PART ONE
        [Test, Parallelizable, Description("Form Validation Standard Elements")]
        public void FormValidationStandardWOL(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            
            //Use Route To WOL to get to WOL Page:
            var setupRoute = new WholeOfLifePage();
            setupRoute.RouteToWOL(driver);
            

                //Save Benefit - throw all screen errors//
            //Click Save Benefit button to throw the 'Please correct the issues highlighted below' message
            string benefitId = "wol";
            var common = new CommonSolutionBuilderPageObjects();
            common.BenefitSaveButton(driver, benefitId);
            

            //Wait on page refresh, jsut in case.
            driver.WaitForUpTo(30, "Please correct the issues highlighted below")
            .Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='wolFormnew']/div[2]/div/div[2]")));

            //Assert that headedr text is shown
            string headerValidationText = driver.FindElement(By.XPath(".//*[@id='wolFormnew']/div[2]/div/div[2]")).Text.Trim();
            Assert.AreEqual(headerValidationText, "Please correct the issues highlighted below");


            //Sum assured amount//
            //Assert that error text is displayed:
            string validationTextBenefit = driver.FindElement(By.XPath(".//*[@id='wolFormnew']/div[6]/div[2]/span[1]")).Text.Trim();
            Assert.AreEqual(validationTextBenefit, "Please enter a whole number between 1,000 and 10,000,000");

            //Insert premium info Sum assured amount
            var sumAssuredAmountField = driver.FindElement(By.Id("wolLifeCoverAmountnew"));
            sumAssuredAmountField.Clear();
            sumAssuredAmountField.SendKeys("10000");

            //Assert that error text is removed:
            //            bool validationNoTextBenefit = driver.FindElement(By.XPath(".//*[@id='ipForm']/div[8]/div[2]").Equals);
            //            Assert.IsFalse(validationNoTextBenefit);


            //Assert the message on the top of the page changes to the Thnak You text:
            string validationHeaderComplete = driver.FindElement(By.XPath(".//*[@id='wolFormnew']/div[2]/div/div[3]")).Text.Trim();
            Assert.AreEqual(validationHeaderComplete, "Thank you. All of the details are now correct.");



            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST TEN
        //Cycle through LIFE AND DEATH options. Bleak.
        [Test, Parallelizable, Description("Life Options")]
        public void JointLifeDeathOptionsWOL(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To WOL to get to WOL Page:
            var setupRoute = new WholeOfLifePage();
            setupRoute.RouteToWOL(driver);

            //Cycle through Life/Death options



            //Switch out to Client and take out second life



            //Return to WOL



            //






            //Call Cleanup
            CleanUp(driver);
        }

        #endregion
    }
}
