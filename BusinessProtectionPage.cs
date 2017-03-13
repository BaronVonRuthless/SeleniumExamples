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

    public class BusinessProtectionPage : TestBase
    {
        #region Support Methods

        //Get to BP Page
        public void RouteToBP(IWebDriver driver)
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
            string benefitId = "bp";
            benefit.AddNewBenefit(driver, benefitId);
            Assert.IsTrue(driver.FindElement(By.Id("bpTermnew")).Displayed);
        }

        #endregion

        #region Tests

        ////TEST ONE
        //Check MyServices Link
        [Test, Parallelizable, Description("Link to Dashboard")]
        public void LinkToDashboardBP(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To BP to get to BP Page:
            var setupRoute = new BusinessProtectionPage();
            setupRoute.RouteToBP(driver);

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
        public void ClientHistoryButtonBP(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To BP to get to BP Page:
            var setupRoute = new BusinessProtectionPage();
            setupRoute.RouteToBP(driver);

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

            //Validate dashboard page reached.
            Assert.IsTrue(driver.FindElement(By.Id("client-history")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST THREE
        //Add client button
        [Test, Parallelizable, Description("Add Client Button")]
        public void AddClientButtonBP(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To BP to get to BP Page:
            var setupRoute = new BusinessProtectionPage();
            setupRoute.RouteToBP(driver);

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
        public void MyServicesLinkBP(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To BP to get to BP Page:
            var setupRoute = new BusinessProtectionPage();
            setupRoute.RouteToBP(driver);

            //Click my services Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.MyServicesButtonDialogue(driver);

            //Summon Validator, Lord of Validation
            string messageText = Constants.CHANGES;
            common.ValidateDialogueDisplayText(driver, messageText);

            //Cancel dialogue
            common.DialogueClose(driver);

            //Re-select my services and exit
            common.MyServicesButtonDialogue(driver);
            common.DialogueYes(driver);
            string pageValidator = "SolutionBuilder-btn";
            common.GenericWait(driver, pageValidator);

            //Validate dashboard page reached.
            Assert.IsTrue(driver.FindElement(By.Id("Assureweb-btn")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST FIVE
        //Logout
        [Test, Parallelizable, Description("Header Logout Button")]
        public void LogoutButtonBP(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To BP to get to BP Page:
            var setupRoute = new BusinessProtectionPage();
            setupRoute.RouteToBP(driver);

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
            string pageValidator = "UserName";
            common.GenericWait(driver, pageValidator);

            //Validate login page reached.
            Assert.IsTrue(driver.FindElement(By.Id("signin-btn")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST SIX
        //Click the View/Edit client button
        [Test, Parallelizable, Description("View Edit Client Button")]
        public void ViewEditClientButtonBP(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To BP to get to BP Page:
            var setupRoute = new BusinessProtectionPage();
            setupRoute.RouteToBP(driver);

            //Click view edit client Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            common.EditClientButtonDialogue(driver);

            //Summon Validator, Lord of Validation
            string messageText = Constants.BENEFIT;
            common.ValidateDialogueDisplayText(driver, messageText);

            //Cancel dialogue
            common.DialogueClose(driver);

            //Re-select edit client and exit
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
        //NOW WITH ADDED RELEVENT LIFE!
        [Test, Parallelizable, Description("Indicative Premium Active")]
        public void IndicativePremiumGenerationBP(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To BP to get to BP Page:
            var setupRoute = new BusinessProtectionPage();
            setupRoute.RouteToBP(driver);

            //Set benefit ID as "BP"
            string benefitId = "bp";

            //Read Indicative filed premium and match to blank "..." value
            var blankIndicativePremium = new CommonSolutionBuilderPageObjects().BenefitIndicativePremiumReader(driver, benefitId);
            Assert.AreEqual(blankIndicativePremium, "...");

            //Insert basic premium details
            var inputBPValues = new BusinessProtectionPageObjects();
            string termYears = Constants.bpTERMYEARS;
            inputBPValues.BPTermYears(driver, termYears);
            inputBPValues.BPLevelTermSelect(driver);
            string levelTermValue = Constants.bpTERMVALUE;
            inputBPValues.BPLevelTermAmount(driver, levelTermValue);

            //Check indicative field again and confirm value has updated
            var newIndicativePremium = new CommonSolutionBuilderPageObjects().BenefitIndicativePremiumReader(driver, benefitId);
            int indicativePremium = Int32.Parse(newIndicativePremium.Replace("£", ""));
            Assert.GreaterThan(indicativePremium, 0);

            //Check that Relevent Life is changeable/updates Indicative Premium





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
        public void CancelButtonBP(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To BP to get to BP Page:
            var setupRoute = new BusinessProtectionPage();
            setupRoute.RouteToBP(driver);

            //Click cancel Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            string benefitId = "bp";
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
            Assert.IsTrue(driver.FindElement(By.Id("select-benefit-bp")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST NINE
        //Check form validation standard PART ONE
        [Test, Parallelizable, Description("Form Validation Standard Elements")]
        public void FormValidationStandardBP(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To BP to get to BP Page:
            var setupRoute = new BusinessProtectionPage();
            setupRoute.RouteToBP(driver);

                //Save Benefit - throw all screen errors//
            //Click Save Benefit button to throw the 'Please correct the issues highlighted below' message
            string benefitId = "bp";
            var common = new CommonSolutionBuilderPageObjects();
            common.BenefitSaveButton(driver, benefitId);

            //Wait on page refresh, jsut in case.
            driver.WaitForUpTo(30, "Please correct the issues highlighted below")
            .Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='bpFormnew']/div[2]/div/div[2]")));

            //Assert that headedr text is shown
            string headerValidationText = driver.FindElement(By.XPath(".//*[@id='bpFormnew']/div[2]/div/div[2]")).Text.Trim();
            Assert.AreEqual(headerValidationText, "Please correct the issues highlighted below");



                //LifeCover TICKBOXES//
            //Check Life Cover field is disabled
            string attributeNameDisabled = "disabled";
            string lifeAmountDisabled = driver.FindElement(By.Id("bpLifeCoverAmountnew")).GetAttribute(attributeNameDisabled);
            Assert.AreEqual(lifeAmountDisabled, "true");

            //CLick the tickbox
            var lifeCoverAmount = driver.FindElement(By.Id("bpLifeCoverBasisnew"));
            lifeCoverAmount.Click();

            //CHeck that the field is now accepting values
            string attributeNameRequired = "required";
            string lifeEnterAmount = driver.FindElement(By.Id("bpLifeCoverAmountnew")).GetAttribute(attributeNameRequired);
            Assert.AreEqual(lifeEnterAmount, "true");

            //Assert that error text is displayed:
            string validationTextLife = driver.FindElement(By.XPath(".//*[@id='bpFormnew']/div[8]/div[2]/span[1]")).Text.Trim();
            Assert.AreEqual(validationTextLife, "Please enter a whole number between 1,000 and 5,000,000");

            //Insert premium info Life cover amount
            var lifeEnterAmountField = driver.FindElement(By.Id("bpLifeCoverAmountnew"));
            lifeEnterAmountField.Clear();
            lifeEnterAmountField.SendKeys("100000");



                //// CRITICAL ILLNESS COVER AMOUNT ////
            //Check that CIC amount field is disabled
            string cicAmountDisabled = driver.FindElement(By.Id("bpCriticalIllnessAmountnew")).GetAttribute(attributeNameDisabled);
            Assert.AreEqual(cicAmountDisabled, "true");

            //CLick the CIC cover tick box
            var criticalIllnessCoverAmount = driver.FindElement(By.Id("bpCriticalIllnessCoverBasisnew"));
            criticalIllnessCoverAmount.Click();

            //Assert that error text is displayed:
            string validationTextCIC = driver.FindElement(By.XPath(".//*[@id='bpFormnew']/div[9]/div[2]/span[1]")).Text.Trim();
            Assert.AreEqual(validationTextCIC, "Please enter a whole number between 1,000 and 5,000,000");

            //CHeck that the field is now accepting values
            string cicEnterAmount = driver.FindElement(By.Id("bpCriticalIllnessAmountnew")).GetAttribute(attributeNameRequired);
            Assert.AreEqual(cicEnterAmount, "true");

            //Insert premium info CIC cover amount
            var criticalInputAmount = driver.FindElement(By.Id("bpCriticalIllnessAmountnew"));
            criticalInputAmount.Clear();
            criticalInputAmount.SendKeys("100000");



                //// LIFE OR EARLIER CI COVER AMOUNT ////            
            //Assert that Life or earlier CI cover amount button is Inactive:
            string lifeAndCicButtonDisabled = driver.FindElement(By.Id("bpLifeOrCriticalIllnessCoverBasisnew")).GetAttribute(attributeNameDisabled);
            Assert.AreEqual(lifeAndCicButtonDisabled, "true");

            //Assert that input field is disabled
            string lifeAndCicAmountDisabled = driver.FindElement(By.Id("bpLifeCoverOrEarlierCIAmountnew")).GetAttribute(attributeNameDisabled);
            Assert.AreEqual(lifeAndCicAmountDisabled, "true");



                //Then deselct CIC and recheck that fields are avaialble//
                //CHeck toast message!//
            //Unselect tickbox to de-activate Critical illness cover amount
            var unselectCriticalIllnessCoverAmount = driver.FindElement(By.Id("bpCriticalIllnessCoverBasisnew"));
            unselectCriticalIllnessCoverAmount.Click();

            //Select tickbox to activate Life or earlier CI cover amoun
            var lifeOrEarlierCICoverAmoun = driver.FindElement(By.Id("bpLifeOrCriticalIllnessCoverBasisnew"));
            lifeOrEarlierCICoverAmoun.Click();

            //Check toast message
            string toastValidationMessage = driver.FindElement(By.Id("toast-container")).Text.Trim();
            Assert.Contains(toastValidationMessage, "Cover basis changed. Please review Total permanent disability");

            //Assert that error text is displayed:
            string validationTextLifeCIC = driver.FindElement(By.XPath(".//*[@id='bpFormnew']/div[10]/div[2]/span[1]")).Text.Trim();
            Assert.AreEqual(validationTextLifeCIC, "Please enter a whole number between 1,000 and 5,000,000");



                //CHeck that CIC buttons have reacted to change, fill Life+CIC values
            //Assert that Critical illness cover amount button is Inactive:
            string cicButtonDisabled = driver.FindElement(By.Id("bpCriticalIllnessCoverBasisnew")).GetAttribute(attributeNameDisabled);
            Assert.AreEqual(cicButtonDisabled, "true");

            //Assert that input field is disabled
            string cicAmountDisabledAgain = driver.FindElement(By.Id("bpCriticalIllnessAmountnew")).GetAttribute(attributeNameDisabled);
            Assert.AreEqual(cicAmountDisabledAgain, "true");

            //Insert premium into life & Critical illness cover amount
            var lifeAndCicInputAmount = driver.FindElement(By.Id("bpLifeCoverOrEarlierCIAmountnew"));
            lifeAndCicInputAmount.Clear();
            lifeAndCicInputAmount.SendKeys("100000");



                //Term field validation//
            //Then Assert that error text is displayed:
            string validationText = driver.FindElement(By.XPath(".//*[@id='bpFormnew']/div[6]/div[2]/span")).Text.Trim();
            Assert.AreEqual(validationText, "Please enter a number between 1 and 59");
                                                    //////// TO BE INVESTIGATED ////////
                                                    ////Add a regex to handle the changing "and age" in the above string so that differnet ages can be used

            //Insert number of years in Term
            var usernameField = driver.FindElement(By.Id("bpTermnew"));
            usernameField.Clear();
            usernameField.SendKeys("15");

            //Check that error text "please enter a number..." has been removed.
            bool enterNumberTextNull = driver.FindElement(By.XPath(".//*[@id='bpFormnew']/div[6]/div[2]/span")).Displayed;
            Assert.IsFalse(enterNumberTextNull);

            //Assert the message on the top of the page changes to the Thnak You text:
            string validationHeaderComplete = driver.FindElement(By.XPath(".//*[@id='bpFormnew']/div[2]/div/div[3]")).Text.Trim();
            Assert.AreEqual(validationHeaderComplete, "Thank you. All of the details are now correct.");


                //Exit and validate that a benefit summary is introduced to the benefit selection page
            //Select Save benefit button
            common.BenefitSaveButton(driver, benefitId);
             

            //Call Cleanup
            CleanUp(driver);
        }



        #endregion
    }
}
