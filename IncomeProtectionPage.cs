using Gallio.Framework;
using Gallio.Model;
using MbUnit.Framework;
using NUnit;
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

    public class IncomeProtectionPage : TestBase
    {
        #region Support Methods

        //Get to IP Page
        public void RouteToIP(IWebDriver driver)
        {
            //Call Shortcut to Add Client - validate 
            var support = new DashboardPage();
            support.RouteToDashboard(driver);
            //Assert.IsTrue(driver.FindElement(By.Id("btnAddClient")).Displayed);

            //Add New Quote
            var dashboard = new DashboardPageObjects();
            dashboard.NewQuote(driver);
            //Assert.IsTrue(driver.FindElement(By.Id("benefit-summary")).Displayed);

            //Select WOL and wait for screen to load - validate page
            var benefit = new BenefitSelectionPageObjects();
            string benefitId = "ip";
            benefit.AddNewBenefit(driver, benefitId);
            //Assert.IsTrue(driver.FindElement(By.Id("ipBenefitAmount")).Displayed);
        }

        //Get to IP Page
        public void AddAllPremiumIncomeProtection(IWebDriver driver, string browserName)
        {
            //Use Route to enter IP page
            RouteToIP(driver);

            //Complete IP details (generic) inc. ALL PREMIUM
            var incomeObjects = new IncomeProtectionPageObjects();
            
            incomeObjects.PremiumTypeAll(driver);
            string benefitAmount = Constants.ipBENEFITAMOUNT;
            string benefitId = "ip";
            
            incomeObjects.IpMinimalBenefitDetails(driver, benefitAmount, browserName);
            new CommonSolutionBuilderPageObjects().BenefitSaveButton(driver, benefitId);
        }



        #endregion

        #region Tests

        ////TEST ONE
        //Check MyServices Link
        [Test, Parallelizable, Description("Link to Dashboard")]
        public void LinkToDashboardIP(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To IP to get to IP Page:
            var setupRoute = new IncomeProtectionPage();
            setupRoute.RouteToIP(driver);

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
        public void ClientHistoryButtonIP(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To IP to get to IP Page:
            var setupRoute = new IncomeProtectionPage();
            setupRoute.RouteToIP(driver);

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
        public void AddClientButtonIP(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To IP to get to IP Page:
            var setupRoute = new IncomeProtectionPage();
            setupRoute.RouteToIP(driver);

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
        public void MyServicesLinkIP(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To IP to get to IP Page:
            var setupRoute = new IncomeProtectionPage();
            setupRoute.RouteToIP(driver);

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
        public void LogoutButtonIP(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To IP to get to IP Page:
            var setupRoute = new IncomeProtectionPage();
            setupRoute.RouteToIP(driver);

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
        public void ViewEditClientButtonIP(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To IP to get to IP Page:
            var setupRoute = new IncomeProtectionPage();
            setupRoute.RouteToIP(driver);

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
        public void IndicativePremiumGenerationIP(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To IP to get to IP Page:
            var setupRoute = new IncomeProtectionPage();
            setupRoute.RouteToIP(driver);

            //Set benefit ID as "IP"
            string benefitId = "ip";

            //Read Indicative filed premium and match to blank "..." value
            var blankIndicativePremium = new CommonSolutionBuilderPageObjects().BenefitIndicativePremiumReader(driver, benefitId);
            Assert.AreEqual(blankIndicativePremium, "...");

            //Insert basic premium details
            var inputIPValues = new IncomeProtectionPageObjects();
            string benefitAmount = Constants.ipBENEFITAMOUNT;
            inputIPValues.PremiumTypeGuaranteed(driver);
            inputIPValues.IPBenefitAmount(driver, benefitAmount);
            inputIPValues.IPDeferredPeriod(driver, browserName);

            //Check indicative field again and confirm value has updated
            var newIndicativePremium = new CommonSolutionBuilderPageObjects().BenefitIndicativePremiumReader(driver, benefitId);
            int indicativePremium = Int32.Parse(newIndicativePremium.Replace("£", ""));
            Assert.GreaterThan(indicativePremium, 0);

            //Save benefit and check premium has transfered through to Benefit Summary page
            inputIPValues.IpSaveButton(driver);

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
        public void CancelButtonIP(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To IP to get to IP Page:
            var setupRoute = new IncomeProtectionPage();
            setupRoute.RouteToIP(driver);

////        NC text
//          Click cancel Button - open dialogue
//          var common = new CommonSolutionBuilderPageObjects();
//          string benefitId = "ip";
//          common.BenefitCancelButton(driver, benefitId);
            
////        CON text
            //Click cancel Button - open dialogue
            var IPcommon = new IncomeProtectionPageObjects();
            IPcommon.IpCancelBenefit(driver);
            
            //Summon Validator, Lord of Validation
            string messageText = Constants.BENEFIT;
            IPcommon.IpValidateDialogueDisplayText(driver, messageText);

            //Cancel dialogue
            IPcommon.IpDialogueClose(driver);

            //Re-select cancel and exit
            IPcommon.IpBenefitCancelButton(driver);
            string pageValidator = "benefit-summary";
            IPcommon.IpDialogueYes(driver);
            new CommonSolutionBuilderPageObjects().SpinnerWait(driver, pageValidator);

            //Validate client details page reached - Find field and ensure contains "Mr"
            Assert.IsTrue(driver.FindElement(By.Id("select-benefit-ip")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST NINE
        //Check form validation standard PART ONE
        [Test, Parallelizable, Description("Form Validation Standard Elements")]
        public void FormValidationStandardIP(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use Route To IP to get to IP Page:
            var setupRoute = new IncomeProtectionPage();
            setupRoute.RouteToIP(driver);

            
                //Save Benefit - throw all screen errors//
//          //Click Save Benefit button to throw the 'Please correct the issues highlighted below' message
//          // string benefitId = "ip";
            var incomeObjects = new IncomeProtectionPageObjects();
            incomeObjects.IpSaveButton(driver);


            //Wait on page refresh, jsut in case.
            driver.WaitForUpTo(30, "Please correct the issues highlighted below")
            .Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='ipForm']/div[2]/div/div[2]")));
            
            //Assert that headedr text is shown
            string headerValidationText = driver.FindElement(By.XPath(".//*[@id='ipForm']/div[2]/div/div[2]")).Text.Trim();
            Assert.AreEqual(headerValidationText, "Please correct the issues highlighted below");

            
                //Monthly benefit amount//
            //Assert that error text is displayed:
            string validationTextBenefit = driver.FindElement(By.XPath(".//*[@id='ipForm']/div[8]/div[2]/span[1]")).Text.Trim();
            Assert.AreEqual(validationTextBenefit, "Please enter a number with 2 decimal places between £5.00 and £99,999.99");

            //Insert premium info Monthly benefit amount
            var benefitEnterAmountField = driver.FindElement(By.Id("ipBenefitAmount"));
            benefitEnterAmountField.Clear();
            benefitEnterAmountField.SendKeys("10000");

            //Assert that error text is removed:
//            bool validationNoTextBenefit = driver.FindElement(By.XPath(".//*[@id='ipForm']/div[8]/div[2]").Equals);
//            Assert.IsFalse(validationNoTextBenefit);


                //Deferred period//
            //Assert that error text is displayed:
            string validationTextDeferredPeriod = driver.FindElement(By.XPath(".//*[@id='ipForm']/div[10]/div[2]/span")).Text.Trim();
            Assert.AreEqual(validationTextDeferredPeriod, "Please select a Deferred period");

            //Select Deferred period:
//            incomeObjects.IPDeferredPeriod(driver);


                //Check form validation on Employment pop-up window
            //Assert if additional client details link is shown
            string occupationDetailsLink = driver.FindElement(By.Id("occupationDetailsLink")).Text.Trim();
            Assert.AreEqual(occupationDetailsLink, "Click here");
            driver.FindElement(By.Id("occupationDetailsLink")).Click();

            // Click Cancel
            //Wait on page refresh, jsut in case.
            driver.WaitForUpTo(30, "Employment status")
            .Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='lifeForm']/div[2]/label")));
            driver.FindElement(By.Id("clientEmploymentStatus"));
            driver.FindElement(By.Id("clientOccupationDetailsCancel")).Click();


            // Make changes and Click Save
            driver.FindElement(By.Id("occupationDetailsLink")).Click();
            //Wait on page refresh, jsut in case.
            driver.WaitForUpTo(30, "Employment status")
            .Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='lifeForm']/div[2]/label")));
            driver.FindElement(By.Id("clientEmploymentStatus"));


            //Select Employment Status = Employed
            var employmentStatus = driver.FindElement(By.XPath(".//*[@id='clientEmploymentStatus']/option[1]"));
            employmentStatus.Click();


            //Clear salary info Annual Earned Income amount
            var clearAnnualEarnedIncome = driver.FindElement(By.Id("clientIncome"));
            clearAnnualEarnedIncome.Clear();

            //Select Employment Status = Unemployed
            var nonemploymentStatus = driver.FindElement(By.XPath(".//*[@id='clientEmploymentStatus']/option[4]"));
            nonemploymentStatus.Click();

            //save changes
            driver.FindElement(By.Id("clientOccupationDetailsSave")).Click();



            //Reopen Employment pop-up window
            driver.FindElement(By.Id("occupationDetailsLink")).Click();



            //driver.WaitForUpTo(30, "Occupation")
            //.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='lifeForm']/div[4]/label")));


            //Insert ClientOccupation info Occupation field
            var clientOccupation = driver.FindElement(By.Id("clientOccupation"));
            clientOccupation.Clear();
            clientOccupation.SendKeys("Accountant");
            //driver.FindElement(By.XPath(".//*[@id='typeahead-1057-2891-option-1']/a")).Click();



            //Insert salary info Annual Earned Income amount
            var annualEarnedIncome = driver.FindElement(By.Id("clientIncome"));
            annualEarnedIncome.Clear();
            annualEarnedIncome.SendKeys("100000");




            ////Wait on page refresh, jsut in case.
            //driver.WaitForUpTo(30, "Airline Pilots")
            //.Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='clientOccupation']")));


            //driver.FindElement(By.Id("clientOccupationDetailsSave")).Click();

            
            //driver.FindElement(By.Id("occupationDetailsLink")).Click();


            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST TEN
        //Add SOLO IP and check ALL is avaialble - check other Benefits locked out
        [Test, Parallelizable, Description("IP All Premiums by Default")]
        public void AllPremiumByDefault(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Route in to IP - defaults to ALL
            RouteToIP(driver);

            //Assert screen text is present
            //string screenTextEntry = driver.FindElement(By.XPath(".//*[@id='ipForm']/visible/div/div/div/span")).Text.Trim();
            string screenTextEntry = driver.FindElement(By.Id("ipForm")).Text.Trim();
            Assert.Contains(screenTextEntry, "Note: Income Protection can only be selected as a single benefit if premium type is 'All'.");

            //Switch to GUARANTEED cover options
            var incomeObjects = new IncomeProtectionPageObjects();
            incomeObjects.PremiumTypeGuaranteed(driver);

            //Assert screen text is hidden
            var commonSupport = new CommonSupportObjects();
            string elementPath = ".//*[@id='ipForm']/visible/div/div/div/span";
            bool screenTextGuaranteed = commonSupport.ElementPresentConfirmByXpath(driver, elementPath);
            Assert.IsFalse(screenTextGuaranteed);

            //Switch to REVIEWABLE cover options
            incomeObjects.PremiumTypeReviewable(driver);

            //Assert screen text is hidden, again
            bool screenTextReviewable = commonSupport.ElementPresentConfirmByXpath(driver, elementPath);
            Assert.IsFalse(screenTextReviewable);

            //Complete IP details (generic) inc. ALL PREMIUM
            incomeObjects.PremiumTypeAll(driver);
            string benefitAmount = Constants.ipBENEFITAMOUNT;
            string benefitId = "ip";
            incomeObjects.IpMinimalBenefitDetails(driver, benefitAmount, browserName);
            new CommonSolutionBuilderPageObjects().BenefitSaveButton(driver, benefitId);

            //Check that the message board displays the correct message
            string messageBoard = driver.FindElement(By.Id("benefit-selector")).Text.Trim();
            //string messageBoard = driver.FindElement(By.XPath(".//*[@id='benefit-summary']/div/div[1]/div[2]/h4")).Text.Trim();
            Assert.Contains(messageBoard, "Add benefit - Income Protection can only be selected as a single benefit if premium type is 'All'");

            //Check that other benefits are disabled
            //Setup array for all benefits (not BP and WOL, soz.
            string[] benefitArray = new string[] { "wol", "dta", "fib", "lta", "bp" };

            //Use for each loop to itterate through each beenfit
            foreach (string item in benefitArray)
            {
                //Set benefitId to item key
                string benefitInBasket = item;

                string addBenefitOption = driver.FindElement(By.Id("select-benefit-" + benefitInBasket)).GetAttribute("disabled");
                Assert.AreEqual(addBenefitOption, "true");
            }

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST ELEVEN
        //Add LTA and enter IP - check ALL PREMIUMS are unavailable
        [Test, Parallelizable, Description("IP All Premiums Unavailable")]
        public void AllPremiumUnavailable(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Summon the Commonator
            var commonSupport = new CommonSupportObjects();
            var commonSolution = new CommonSolutionBuilderPageObjects();
            var incomeObjects = new IncomeProtectionPageObjects();

            //Route in to BENEFITS
            new BenefitSelectionPage().RouteToBenefits(driver);

            //Setup array for all benefits (not BP and WOL, soz.
            string[] benefitArray = new string[] { "lta", "dta", "fib" };

            //Use for each loop to itterate through each beenfit
            foreach (string item in benefitArray)
            {
                //Set benefitId to item key
                string benefitInput = item;

                //Breakout the benefits!
                if (benefitInput == "lta")
                {
                    commonSupport.AddBasicLevelTermBenefit(driver);
                }
                if (benefitInput == "dta")
                {
                    commonSupport.AddBasicDecreasingTermBenefit(driver);
                }
                if (benefitInput == "fib")
                {
                    commonSupport.AddBasicFamilyIncomeBenefit(driver);
                }

                //Bounce into IP
                string benefitId = "ip";
                new BenefitSelectionPageObjects().AddNewBenefit(driver, benefitId);

                //Assert that ALL option is not present
                string elementId = "ipAllPremiumTypes";
                bool premiumOptions = commonSupport.ElementPresentConfirmById(driver, elementId);
                Assert.IsFalse(premiumOptions);

                //Assert that screen text is not displayed
                string elementPath = ".//*[@id='ipForm']/visible/div/div/div/span";
                bool screenText = commonSupport.ElementPresentConfirmByXpath(driver, elementPath);
                Assert.IsFalse(screenText);

                //Quit out of IP and return to Benefit Selection
                incomeObjects.IpCancelBenefit(driver);
                incomeObjects.IpDialogueYes(driver);

                //Cancel the existing benefit
                commonSolution.BenefitDeleteButton(driver, benefitInput);
                commonSolution.DialogueYes(driver);
            }

            //Call Cleanup
            CleanUp(driver);
        }


        //JOINT LIFE TEST!
        // "Add benefit - only Income Protection can be requested if premium type is 'All'."


        #endregion
    }
}
