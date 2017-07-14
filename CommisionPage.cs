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

    public class CommissionPage : TestBase
    {
        #region Support Methods

        //Get to Commission Page
        public void RouteToCommission(IWebDriver driver)
        {
            //Call Shortcut to Add Client - validate 
            var support = new DashboardPage();
            support.RouteToDashboard(driver);

            //Add New Quote
            var dashboard = new DashboardPageObjects();
            dashboard.NewQuote(driver);

            //Select WOL and wait for screen to load - validate page
            var benefit = new BenefitSelectionPageObjects();
            benefit.EditCommission(driver);
        }

        #endregion

        #region Tests

        ////TEST ONE
        //Check Client History Link
        [Test, Parallelizable, Description("Link to Dashboard")]
        public void LinkToDashboardCommission(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To Commission to get to Commission Page:
            var setupRoute = new CommissionPage();
            setupRoute.RouteToCommission(driver);

            //Click Client Search Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.ClientSearchButtonDialogue(driver);

            //Summon Validator, Lord of Validation
            string messageText = Constants.CHANGES;
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
        public void ClientHistoryButtonCommission(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To Commission to get to Commission Page:
            var setupRoute = new CommissionPage();
            setupRoute.RouteToCommission(driver);

            //Click client history Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.ClientHistoryButtonDialogue(driver);

            //Summon Validator, Lord of Validation
            string messageText = Constants.CHANGES;
            common.ValidateDialogueDisplayText(driver, messageText);

            //Cancel dialogue
            common.DialogueClose(driver);

            //Re-select client history and exit
            common.ClientHistoryButtonDialogue(driver);
            common.DialogueYes(driver);
            string pageValidator = "navigation-bar";
            common.SpinnerWait(driver, pageValidator);

            //Validate client histroy page reached.
            Assert.IsTrue(driver.FindElement(By.Id("client-history")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST THREE
        //Add client button
        [Test, Parallelizable, Description("Add Client Button")]
        public void AddClientButtonCommission(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To Commission to get to Commission Page:
            var setupRoute = new CommissionPage();
            setupRoute.RouteToCommission(driver);

            //Click add client Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.AddClientButtonDialogue(driver);

            //Summon Validator, Lord of Validation
            string messageText = Constants.CHANGES;
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
        public void MyServicesLinkCommission(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To Commission to get to Commission Page:
            var setupRoute = new CommissionPage();
            setupRoute.RouteToCommission(driver);

            //Click my services Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.MyServicesButtonDialogue(driver);

            //Summon Validator, Lord of Validation
            string messageText = Constants.CHANGES;
            common.ValidateDialogueDisplayText(driver, messageText);

            //Cancel dialogue
            common.DialogueClose(driver);

            //Re-select myservices and exit
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
        public void LogoutButtonCommission(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To Commission to get to Commission Page:
            var setupRoute = new CommissionPage();
            setupRoute.RouteToCommission(driver);

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
        public void ViewEditClientButtonCommission(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To Commission to get to Commission Page:
            var setupRoute = new CommissionPage();
            setupRoute.RouteToCommission(driver);

            //Click view edit client Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.EditClientButtonDialogue(driver);

            //Summon Validator, Lord of Validation
            string messageText = Constants.CHANGES;
            common.ValidateDialogueDisplayText(driver, messageText);

            //Cancel dialogue
            common.DialogueClose(driver);

            //Re-select viewedit client and exit
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


        ////TEST EIGHT
        //DO I get a warnign dialogue when I try to cancel?
        [Test, Parallelizable, Description("Cancel Button")]
        public void CancelButtonCommission(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To Commission to get to Commission Page:
            var setupRoute = new CommissionPage();
            setupRoute.RouteToCommission(driver);

            //Click cancel Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            string benefitId = "commission";
            common.BenefitCancelButton(driver, benefitId);

            //Summon Validator, Lord of Validation
            string messageText = Constants.CHANGES;
            common.ValidateDialogueDisplayText(driver, messageText);

            //Cancel dialogue
            common.DialogueClose(driver);

            //Re-select cancel and exit
            common.BenefitCancelButton(driver, benefitId);
            string pageValidator = "benefit-summary";
            common.DialogueYes(driver);
            common.SpinnerWait(driver, pageValidator);

            //Validate client details page reached - Find field and ensure contains "Mr"
            Assert.IsTrue(driver.FindElement(By.Id("commission-button")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST NINE
        //Check form validation standard PART ONE
        [Test, Parallelizable, Description("Form Validation Standard Elements")]
        public void FormValidationCommission(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To Commission to get to Commission Page:
            var setupRoute = new CommissionPage();
            setupRoute.RouteToCommission(driver);

            //Run validation steps to check all functions are available
            var commission = new CommissionPageObjects();
            commission.SelectNil(driver);
            
            //Assert that input is disabled
            Assert.IsFalse(driver.FindElement(By.Id("percentageInput")).Enabled);
            
            //Assert that indemnity buttons are disabled
            string attributeName = "disabled";
            string requiredYesDisabled = driver.FindElement(By.Id("indemnityRequiredYes")).GetAttribute(attributeName);
            Assert.AreEqual(requiredYesDisabled, "true");
            string requiredNoDisabled = driver.FindElement(By.Id("indemnityRequiredNo")).GetAttribute(attributeName);
            Assert.AreEqual(requiredNoDisabled, "true");

            //Click Full
            commission.SelectFull(driver);
            
            //Assert input still disabled
            Assert.IsFalse(driver.FindElement(By.Id("percentageInput")).Enabled);

            //Assert indemnity is NO LONGER DISABLED
            string requiredYesActive = driver.FindElement(By.Id("indemnityRequiredYes")).GetAttribute(attributeName);
            Assert.IsNull(requiredYesActive);
            string requiredNoActive = driver.FindElement(By.Id("indemnityRequiredNo")).GetAttribute(attributeName);
            Assert.IsNull(requiredNoActive);

            //Click No, Click Yes
            commission.IndemnityNo(driver);
            commission.IndemnityYes(driver);

            //Click Modified
            commission.SelectModified(driver);
            
            //Assert percentage available
            Assert.IsTrue(driver.FindElement(By.Id("percentageInput")).Enabled);

            //Input some junk (clears field)
            var inputPercentage = "tu";
            commission.PercentageInput(driver, inputPercentage);
            
            //Assert that error text is thrown
            string validationText = driver.FindElement(By.XPath(".//*[@id='commissionForm']/div[4]/div[2]/span")).Text.Trim();
            Assert.AreEqual(validationText, "Please enter a whole number between 1 - 99");

            //Try to Save
            commission.SaveBenefitCommission(driver);
            //Assert validation header
            string validationHeaderError = driver.FindElement(By.XPath(".//*[@id='commissionForm']/div[2]/div/div[2]")).Text.Trim();
            Assert.AreEqual(validationHeaderError, "Please correct the issues highlighted below");

            //Input a valid percentage (clears field)
            inputPercentage = "5";
            commission.PercentageInput(driver, inputPercentage);

            string validationHeaderComplete = driver.FindElement(By.XPath(".//*[@id='commissionForm']/div[2]/div/div[3]")).Text.Trim();
            Assert.AreEqual(validationHeaderComplete, "Thank you. All of the details are now correct.");

            //Save
            commission.SaveBenefitCommission(driver);

            //generic wait
            string pageValidator = "benefit-summary";
            var common = new CommonSolutionBuilderPageObjects();
            common.GenericWait(driver, pageValidator);

            //Assert Summary page reached
            Assert.IsTrue(driver.FindElement(By.XPath(".//*[@id='benefit-summary']/div/div[1]/div[1]/div[1]/h4")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }


        #endregion
    }
}
