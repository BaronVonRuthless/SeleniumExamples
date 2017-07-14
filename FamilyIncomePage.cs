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

    public class FamilyIncomePage : TestBase
    {
        #region Support Methods

        //Get to FIB Page
        public void RouteToFIB(IWebDriver driver)
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
            string benefitId = "fib";
            benefit.AddNewBenefit(driver, benefitId);
            Assert.IsTrue(driver.FindElement(By.Id("fibTermnew")).Displayed);
        }

        #endregion

        #region Tests

        ////TEST ONE
        //Check MyServices Link
        [Test, Parallelizable, Description("Link to Dashboard")]
        public void LinkToDashboardFIB(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To FIB to get to FIB Page:
            var setupRoute = new FamilyIncomePage();
            setupRoute.RouteToFIB(driver);

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
        public void ClientHistoryButtonFIB(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To FIB to get to FIB Page:
            var setupRoute = new FamilyIncomePage();
            setupRoute.RouteToFIB(driver);

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
        public void AddClientButtonFIB(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To FIB to get to FIB Page:
            var setupRoute = new FamilyIncomePage();
            setupRoute.RouteToFIB(driver);

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
        public void MyServicesLinkFIB(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To FIB to get to FIB Page:
            var setupRoute = new FamilyIncomePage();
            setupRoute.RouteToFIB(driver);

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
        public void LogoutButtonFIB(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To FIB to get to FIB Page:
            var setupRoute = new FamilyIncomePage();
            setupRoute.RouteToFIB(driver);

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
        public void ViewEditClientButtonFIB(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To FIB to get to FIB Page:
            var setupRoute = new FamilyIncomePage();
            setupRoute.RouteToFIB(driver);

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
        [Test, Parallelizable, Description("Indicative Premium Active")]
        public void IndicativePremiumGenerationFIB(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To FIB to get to FIB Page:
            var setupRoute = new FamilyIncomePage();
            setupRoute.RouteToFIB(driver);

            //Set benefit ID as "FIB"
            string benefitId = "fib";

            //Read Indicative filed premium and match to blank "..." value
            var blankIndicativePremium = new CommonSolutionBuilderPageObjects().BenefitIndicativePremiumReader(driver, benefitId);
            Assert.AreEqual(blankIndicativePremium, "...");

            //Insert basic premium details
            var inputFIBValues = new FamilyIncomePageObjects();
            string termYears = Constants.fibTERMYEARS;
            inputFIBValues.FIBTermYears(driver, termYears);
            inputFIBValues.FIBCriticalIllnessSelect(driver);
            string cicValue = Constants.fibCICVALUE;
            inputFIBValues.FIBCriticalIllnessAmount(driver, cicValue);

            //Check indicative field again and confirm value has updated
            var newIndicativePremium = new CommonSolutionBuilderPageObjects().BenefitIndicativePremiumReader(driver, benefitId);
            int indicativePremium = Int32.Parse(newIndicativePremium.Replace("£", ""));
            Assert.GreaterThan(indicativePremium, 0);

            //Save benefit and check premium has transfered through to Benefit Summary page
            var common = new CommonSolutionBuilderPageObjects();
            common.BenefitSaveButton(driver, benefitId);

            //Read out updated Indicative Total and compare to single benefit read.
            var returnTotalValue = new BenefitSelectionPageObjects().TotalIndicativePremiumReader(driver);
            int indicativeValueTotal = Int32.Parse(returnTotalValue.Replace("£", ""));
            Assert.AreEqual(indicativeValueTotal, indicativePremium);

            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST EIGHT
        //Do I get a warnign dialogue when I try to cancel?
        [Test, Parallelizable, Description("Cancel Button")]
        public void CancelButtonFIB(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To FIB to get to FIB Page:
            var setupRoute = new FamilyIncomePage();
            setupRoute.RouteToFIB(driver);

            //Click cancel Button - open dialogue
            var common = new CommonSolutionBuilderPageObjects();
            string benefitId = "fib";
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
            Assert.IsTrue(driver.FindElement(By.Id("select-benefit-fib")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST NINE
        //Check form validation standard PART ONE
        [Test, Parallelizable, Description("Form Validation Standard Elements")]
        public void FormValidationStandardFIB(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);


            //Use Route To FIB to get to FIB Page:
            var setupRoute = new FamilyIncomePage();
            setupRoute.RouteToFIB(driver);

                //Save Benefit - throw all screen errors//
            //Click Save Benefit button to throw the 'Please correct the issues highlighted below' message
            string benefitId = "fib";
            var common = new CommonSolutionBuilderPageObjects();
            common.BenefitSaveButton(driver, benefitId);

            //Wait on page refresh, jsut in case.
            driver.WaitForUpTo(30, "Please correct the issues highlighted below")
            .Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='fibFormnew']/div[2]/div/div[2]")));
            
            //Assert that headedr text is shown
            string headerValidationText = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[2]/div/div[2]")).Text.Trim();
            Assert.AreEqual(headerValidationText, "Please correct the issues highlighted below");



                //LifeCover TICKBOXES//
            //Check Life Cover field is disabled
            string attributeNameDisabled = "disabled";
            string lifeAmountDisabled = driver.FindElement(By.Id("fibLifeCoverAmountnew")).GetAttribute(attributeNameDisabled);
            Assert.AreEqual(lifeAmountDisabled, "true");

            //CLick the tickbox
            var lifeCoverAmount = driver.FindElement(By.Id("fibLifeCoverBasisnew"));
            lifeCoverAmount.Click();

            //CHeck that the field is now accepting values
            string attributeNameRequired = "required";
            string lifeEnterAmount = driver.FindElement(By.Id("fibLifeCoverAmountnew")).GetAttribute(attributeNameRequired);
            Assert.AreEqual(lifeEnterAmount, "true");

            //Assert that error text is displayed:
            string validationTextLife = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[8]/div[2]")).Text.Trim();
            Assert.AreEqual(validationTextLife, "Please enter a whole number between 1,000 and 50,000,000");

            //Insert premium info Life cover amount
            var lifeEnterAmountField = driver.FindElement(By.Id("fibLifeCoverAmountnew"));
            lifeEnterAmountField.Clear();
            lifeEnterAmountField.SendKeys("100000");



                //// CRITICAL ILLNESS COVER AMOUNT ////
            //Check that CIC amount field is disabled
            string cicAmountDisabled = driver.FindElement(By.Id("fibCriticalIllnessAmountnew")).GetAttribute(attributeNameDisabled);
            Assert.AreEqual(cicAmountDisabled, "true");

            //CLick the CIC cover tick box
            var criticalIllnessCoverAmount = driver.FindElement(By.Id("fibCriticalIllnessCoverBasisnew"));
            criticalIllnessCoverAmount.Click();

            //Assert that error text is displayed:
            string validationTextCIC = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[9]/div[2]")).Text.Trim();
            Assert.AreEqual(validationTextCIC, "Please enter a whole number between 1,000 and 50,000,000");

            //CHeck that the field is now accepting values
            string cicEnterAmount = driver.FindElement(By.Id("fibCriticalIllnessAmountnew")).GetAttribute(attributeNameRequired);
            Assert.AreEqual(cicEnterAmount, "true");

            //Insert premium info CIC cover amount
            var criticalInputAmount = driver.FindElement(By.Id("fibCriticalIllnessAmountnew"));
            criticalInputAmount.Clear();
            criticalInputAmount.SendKeys("100000");



                //// LIFE OR EARLIER CI COVER AMOUNT ////            
            //Assert that Life or earlier CI cover amount button is Inactive:
            string lifeAndCicButtonDisabled = driver.FindElement(By.Id("fibLifeOrCriticalIllnessCoverBasisnew")).GetAttribute(attributeNameDisabled);
            Assert.AreEqual(lifeAndCicButtonDisabled, "true");

            //Assert that input field is disabled
            string lifeAndCicAmountDisabled = driver.FindElement(By.Id("fibLifeCoverOrEarlierCIAmountnew")).GetAttribute(attributeNameDisabled);
            Assert.AreEqual(lifeAndCicAmountDisabled, "true");



                //Then deselct CIC and recheck that fields are avaialble//
                //CHeck toast message!//
            //Unselect tickbox to de-activate Critical illness cover amount
            var unselectCriticalIllnessCoverAmount = driver.FindElement(By.Id("fibCriticalIllnessCoverBasisnew"));
            unselectCriticalIllnessCoverAmount.Click();

            //Select tickbox to activate Life or earlier CI cover amoun
            var lifeOrEarlierCICoverAmoun = driver.FindElement(By.Id("fibLifeOrCriticalIllnessCoverBasisnew"));
            lifeOrEarlierCICoverAmoun.Click();

            //Check toast message
            string toastValidationMessage = driver.FindElement(By.Id("toast-container")).Text.Trim();
            Assert.Contains(toastValidationMessage, "Cover basis changed. Please review Total permanent disability");

            //Assert that error text is displayed:
            string validationTextLifeCIC = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[10]/div[2]/span[1]")).Text.Trim();
            Assert.AreEqual(validationTextLifeCIC, "Please enter a whole number between 1,000 and 5,000,000");



                //CHeck that CIC buttons have reacted to change, fill Life+CIC values
            //Assert that Critical illness cover amount button is Inactive:
            string cicButtonDisabled = driver.FindElement(By.Id("fibCriticalIllnessCoverBasisnew")).GetAttribute(attributeNameDisabled);
            Assert.AreEqual(cicButtonDisabled, "true");

            //Assert that input field is disabled
            string cicAmountDisabledAgain = driver.FindElement(By.Id("fibCriticalIllnessAmountnew")).GetAttribute(attributeNameDisabled);
            Assert.AreEqual(cicAmountDisabledAgain, "true");

            //Insert premium into life & Critical illness cover amount
            var lifeAndCicInputAmount = driver.FindElement(By.Id("fibLifeCoverOrEarlierCIAmountnew"));
            lifeAndCicInputAmount.Clear();
            lifeAndCicInputAmount.SendKeys("100000");



            //Term field validation//
            //Then Assert that error text is displayed:
            string validationText = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[6]/div[2]/span")).Text.Trim();
            Assert.AreEqual(validationText, "Please enter a number between 1 and 59");
                                            //////// TO BE INVESTIGATED ////////
                                            ////Add a regex to handle the changing "and age" in the above string so that differnet ages can be used

            //Insert number of years in Term
            var usernameField = driver.FindElement(By.Id("fibTermnew"));
            usernameField.Clear();
            usernameField.SendKeys("15");

            //Check that error text "please enter a number..." has been removed.
            bool enterNumberTextNull = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[6]/div[2]/span")).Displayed;
            Assert.IsFalse(enterNumberTextNull);

            //Assert the message on the top of the page changes to the Thnak You text:
            string validationHeaderComplete = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[2]/div/div[3]")).Text.Trim();
            Assert.AreEqual(validationHeaderComplete, "Thank you. All of the details are now correct.");


                //Exit and validate that a benefit summary is introduced to the benefit selection page
            //Select Save benefit button
            common.BenefitSaveButton(driver, benefitId);

            
            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST TEN
        //Check form validation xrae PART TWO
        [Test, Parallelizable, Description("Form Validation Xrae Elements")]
        public void FormValidationXraeFIB(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            
            //Use Route To FIB to get to FIB Page:
            var setupRoute = new FamilyIncomePage();
            setupRoute.RouteToFIB(driver);
            

                //Enter cover amount and years - required so that correct error Xrea validation displays//
            //CLick the tickbox
            var lifeCoverAmount = driver.FindElement(By.Id("fibLifeCoverBasisnew"));
            lifeCoverAmount.Click();
            //Insert number of years in Term
            var termField = driver.FindElement(By.Id("fibTermnew"));
            termField.Clear();
            termField.SendKeys("15");
            //Insert premium info Life cover amount
            var lifeEnterAmountField = driver.FindElement(By.Id("fibLifeCoverAmountnew"));
            lifeEnterAmountField.Clear();
            lifeEnterAmountField.SendKeys("100000");


            //Click 'Yes' to question 'Would you like to enter height and weight for your Client?'
            var xraeYesButton = driver.FindElement(By.Id("fibHeightAndHeightYesnew"));
            xraeYesButton.Click();

                                //   * * *  M E T R I C  * * *  //

            //Assert Xrea button functionality for First Life
            driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[15]")).FindElement(By.Id("hwMetric")).Click();

            //Insert invalid value into Height field
            var metricHeightValue = driver.FindElement(By.Id("hw.heightCentimetres"));
            metricHeightValue.Clear();
            metricHeightValue.SendKeys("1");


            //Click Save Benefit button to throw the 'Please correct the issues highlighted below' message
            string benefitId = "fib";
            var common = new CommonSolutionBuilderPageObjects();
            common.BenefitSaveButton(driver, benefitId);

            //Wait on message refresh, jsut in case.
            driver.WaitForUpTo(30, "Please correct the issues highlighted below")
            .Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='fibFormnew']/div[2]/div/div[2]")));

            //Assert that headed text is shown
            string headerValidationText = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[2]/div/div[2]")).Text.Trim();
            Assert.Contains(headerValidationText, "Please correct the issues highlighted below");


            //Assert correct Xrea HEIGHT error texts are displayed
            string xraeValidationInvalidHeightErrorText = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[15]")).FindElement(By.XPath(".//*[@id='height-and-weight']/div[2]/div[2]/span")).Text.Trim();
            Assert.Contains(xraeValidationInvalidHeightErrorText, "Height must be between 122cm and 241cm");
            // and
// fails    string xraeValidationMissingWeightErrorText = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[15]")).FindElement(By.XPath(".//*[@id='height-and-weight']/div[3]/div[2]/span")).Text.Trim();
// fails    Assert.Contains(xraeValidationMissingWeightErrorText, "Height and weight must be supplied together or not at all");

            //Check that error text "Height must be between 122cm and 241cm" has been removed.
            var metricValidHeightValue = driver.FindElement(By.Id("hw.heightCentimetres"));
            metricValidHeightValue.Clear();
            metricValidHeightValue.SendKeys("200");
            bool xraeValidationErrorTextNullHeight = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[15]")).FindElement(By.XPath(".//*[@id='height-and-weight']/div[2]/div[2]/span")).Displayed;
            Assert.IsFalse(xraeValidationErrorTextNullHeight);


                //Assert correct Xrea WEIGHT error texts are displayed
            //Insert invalid value into Weight field
            var metricWeightValue = driver.FindElement(By.Id("hw.weightKilograms"));
            metricWeightValue.Clear();
            metricWeightValue.SendKeys("1");
            string xraeValidationInvalidWeightErrorText = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[15]")).FindElement(By.XPath(".//*[@id='height-and-weight']/div[3]/div[2]/span")).Text.Trim();
            Assert.Contains(xraeValidationInvalidWeightErrorText, "Weight must be between 23kg and 227kg");


            //Assert correct Xrea MISSING HEIGHT error texts are displayed
            metricHeightValue.Clear();
            string xraeValidationMissingHeightErrorText = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[15]")).FindElement(By.XPath(".//*[@id='height-and-weight']/div[2]/div[2]/span")).Text.Trim();
            Assert.Contains(xraeValidationMissingHeightErrorText, "Height and weight must be supplied together or not at all");


            //Check that error text "Weight must be between 23kg and 227kg" has been removed.
            var metricValidWeightValue = driver.FindElement(By.Id("hw.weightKilograms"));
            metricValidWeightValue.Clear();
            metricValidWeightValue.SendKeys("111");
            bool xraeValidationErrorTextNullWeight = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[15]")).FindElement(By.XPath(".//*[@id='height-and-weight']/div[3]/div[2]/span")).Displayed;
            Assert.IsFalse(xraeValidationErrorTextNullWeight);


                //Assert the message on the top of the page changes to the Thnak You text:
            //Insert valid Height
            var metricValidHeightValue2 = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[15]")).FindElement(By.Id("hw.heightCentimetres"));
            metricValidHeightValue2.Clear();
            metricValidHeightValue2.SendKeys("222");


            //Assert change to message on the top of the page            
            string validationHeaderComplete = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[2]/div/div[3]")).Text.Trim();
            Assert.AreEqual(validationHeaderComplete, "Thank you. All of the details are now correct.");

                                    //   * * *  I M P E R I A L  * * *  //

            //Assert Xrea button functionality for SECOND Life
            driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[16]")).FindElement(By.Id("hwMetric")).Click();
            driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[16]")).FindElement(By.Id("hwImperial")).Click();

            //Insert invalid value into Height - Feet field
            var imperialHeightFeetValue = driver.FindElement(By.Id("hw.heightFeet"));
            imperialHeightFeetValue.Clear();
            imperialHeightFeetValue.SendKeys("1");


            //Click Save Benefit button to throw the 'Please correct the issues highlighted below' message
            common.BenefitSaveButton(driver, benefitId);

            //Wait on message refresh, jsut in case.
            driver.WaitForUpTo(30, "Please correct the issues highlighted below")
            .Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='fibFormnew']/div[2]/div/div[2]")));

            //Assert that headed text is shown
            Assert.Contains(headerValidationText, "Please correct the issues highlighted below");


            //Assert correct Xrea HEIGHT - FEET error texts are displayed
// fails    string xraeValidationInvalidHeightFeetErrorText = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[16]")).FindElement(By.XPath(".//*[@id='height-and-weight']/div[2]/div[3]/span")).Text.Trim();
// fails    Assert.Contains(xraeValidationInvalidHeightFeetErrorText, "Height must be between 4ft 0in and 7ft 11in");
            // and
            string xraeValidationMissingWeightErrorText = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[16]")).FindElement(By.XPath(".//*[@id='height-and-weight']/div[3]/div[3]/span")).Text.Trim();
            Assert.Contains(xraeValidationMissingWeightErrorText, "Height and weight must be supplied together or not at all");

            //clear date from HEIGHT - FEET
            imperialHeightFeetValue.Clear();
            //Insert invalid value into Height - Inches field
            var imperialHeightInchesValue = driver.FindElement(By.Id("hw.heightInches"));
            imperialHeightInchesValue.Clear();
            imperialHeightInchesValue.SendKeys("111");

            //Assert correct Xrea HEIGHT - INCHES error texts are displayed
            string xraeValidationInvalidHeightInchesErrorText = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[16]")).FindElement(By.XPath(".//*[@id='height-and-weight']/div[2]/div[3]/span")).Text.Trim();
            Assert.Contains(xraeValidationInvalidHeightInchesErrorText, "Inches cannot be greater than 11");


            //Insert Valid values into Height - Feet and Height - Inches fields and that no error text for Height displays
            imperialHeightFeetValue.Clear();
            imperialHeightFeetValue.SendKeys("5");
            imperialHeightInchesValue.Clear();
            imperialHeightInchesValue.SendKeys("5");
// fails    bool xraeValidationErrorTextNullImperialHeight = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[16]")).FindElement(By.XPath(".//*[@id='height-and-weight']/div[2]/div[2]/span")).Displayed;
// fails    Assert.IsFalse(xraeValidationErrorTextNullImperialHeight);

            //Insert invalid value into WEIGHT - STONE field
            var imperialWeightStoneValue = driver.FindElement(By.Id("hw.weightStone"));
            imperialWeightStoneValue.Clear();
            imperialWeightStoneValue.SendKeys("1");

            //Wait on message refresh, jsut in case.
            driver.WaitForUpTo(30, "Please correct the issues highlighted below")
            .Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='fibFormnew']/div[2]/div/div[2]")));

            //Assert that headed text is shown
            Assert.Contains(headerValidationText, "Please correct the issues highlighted below");

            //Assert correct Xrea WEIGHT - STONE error text is displayed
// fails    string xraeValidationInvalidWeightStoneErrorText = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[16]")).FindElement(By.XPath(".//*[@id='height-and-weight']/div[3]/div[3]/span")).Text.Trim();
// fails    Assert.Contains(xraeValidationInvalidWeightStoneErrorText, "Weight must be between 3st 9lb and 35st 11lb");

            //Assert correct Xrea WEIGHT - POUNDS error text is displayed
            imperialWeightStoneValue.Clear();
            imperialWeightStoneValue.SendKeys("11");
// fails    string xraeValidationMissingWeightPoundsErrorText = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[16]")).FindElement(By.XPath(".//*[@id='height-and-weight']/div[3]/div[3]/span")).Text.Trim();
// fails    Assert.Contains(xraeValidationMissingWeightPoundsErrorText, "Both stone and pounds must be specified");            


            //Insert valid Weight - Pounds
            var imperialWeightPoundsValue = driver.FindElement(By.XPath(".//*[@id='fibFormnew']/div[16]")).FindElement(By.Id("hw.weightPounds"));
            imperialWeightPoundsValue.Clear();
            imperialWeightPoundsValue.SendKeys("11");


            //Assert change to message on the top of the page            
            Assert.AreEqual(validationHeaderComplete, "Thank you. All of the details are now correct.");

            // CLEAR ALL HEIGHT AND WEIGHT DATE FROM TEST CLIENTS ! //
            metricHeightValue.Clear();
            metricWeightValue.Clear();
            imperialHeightFeetValue.Clear();
            imperialWeightPoundsValue.Clear();

            //CLICK Save
            string xreaBenefitId = "fib";
            var xreaCommon = new CommonSolutionBuilderPageObjects();
            xreaCommon.BenefitSaveButton(driver, xreaBenefitId);


            //Call Cleanup
            CleanUp(driver);
        }


        #endregion
    }
}
