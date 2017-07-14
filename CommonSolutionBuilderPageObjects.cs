using System;
using NUnit.Framework;
using Selenium;
using System.Web;
using System.Text;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using SolutionBuilderClientDetailsPageObjects;

namespace Common
{

    //This class contains common actiosn that can be used on most pages; tablet style clicks, URL goTo etc...

    public class CommonSolutionBuilderPageObjects
    {

        ////LINK TO MY SERVICES - NO DIALOGUE (Dashboard + Client History)
        //Find and click My Services link
        public void MyServicesButton(IWebDriver driver)
        {
            //Set element to use AND alternative element
            string standardElement = "myServicesButton";
            string alternativeElement = "myServicesLink";

            //Locate link and click using Element Is Present validator
            var common = new CommonSupportObjects();
            common.ElementIsPresentClick(driver, standardElement, alternativeElement);

            //If spinner displayed, wait...
            //while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            //{
                driver.WaitForUpTo(30, "Didn't make it to My Services")
                .Until(ExpectedConditions.ElementExists(By.Id("SolutionBuilder-btn")));
            //}
        }

        ////LINK TO DASHBOARD - DIALOGUE
        //Find and click My Services
        public void MyServicesButtonDialogue(IWebDriver driver)
        {
            //Set element to use AND alternative element
            string standardElement = "myServicesButton";
            string alternativeElement = "myServicesLink";

            //Locate link and click using Element Is Present validator
            var common = new CommonSupportObjects();
            common.ElementIsPresentClick(driver, standardElement, alternativeElement);

            //If spinner displayed, wait...
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "No dialogue, no soliloquy")
                .Until(ExpectedConditions.ElementExists(By.Id("messageTitle")));
            }
        }

        ////LINK TO DASHBOARD - NO DIALOGUE (Dashboard + Client History)
        //Find and click Client Search
        public void ClientSearchButton(IWebDriver driver)
        {
            //Set element to use AND alternative element
            string standardElement = "ClientSearchButton";
            string alternativeElement = "searchClientMenuLink";

            //Locate link and click using Element Is Present validator
            var common = new CommonSupportObjects();
            common.ElementIsPresentClick(driver, standardElement, alternativeElement);

            //If spinner displayed, wait...
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "Didn't make it to the dashboard")
                .Until(ExpectedConditions.ElementExists(By.Id("btnAddClient")));
            }
        }

        ////LINK TO DASHBOARD - DIALOGUE
        //Find and click Client Search from Benefits and wait for dialogue
        public void ClientSearchButtonDialogue(IWebDriver driver)
        {
            //Set element to use AND alternative element
            string standardElement = "ClientSearchButton";
            string alternativeElement = "searchClientMenuLink";

            //Locate link and click using Element Is Present validator
            var common = new CommonSupportObjects();
            common.ElementIsPresentClick(driver, standardElement, alternativeElement);

            //If spinner displayed, wait...
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
            driver.WaitForUpTo(30, "No dialogue, no soliloquy")
            .Until(ExpectedConditions.ElementExists(By.Id("messageTitle")));
            }
        }

        ////GENERIC DIALOGUE BOX - YES
        //Select "Yes" and check next page is reached
        public void DialogueYes(IWebDriver driver)
        {
            //Go through with it
            var common = new CommonSupportObjects();
            var okButton = driver.FindElement(By.Id("btnYes"));
            common.TabletClick(okButton, driver); 
        }

        ////PAGE TRANSITION - SPINNER
        //Generic WAIT method for spinner interactions
        public void SpinnerWait(IWebDriver driver, string pageValidator)
        {
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "Didn't make it to the expected page. Did not find: " + pageValidator)
                .Until(ExpectedConditions.ElementExists(By.Id(pageValidator)));
            }
        }

        ////PAGE TRANSITION - GENERIC
        //Generic WAIT method for non-spinner transitions (Hard Wait)
        public void GenericWait(IWebDriver driver, string pageValidator)
        {
                driver.WaitForUpTo(60, "Didn't make it to the expected page. Did not find: " + pageValidator)
                .Until(ExpectedConditions.ElementExists(By.Id(pageValidator)));
        }



        ////PAGE TRANSITION - SPECIFIED
        //Specified WAIT method for non-spinner transitions (Hard Wait)
        public void SpecifiedWait(IWebDriver driver, int waitTime, string pageValidator)
        {
            driver.WaitForUpTo(waitTime, "Didn't make it to the expected page. Did not find: " + pageValidator)
            .Until(ExpectedConditions.ElementExists(By.Id(pageValidator)));
        }



        ////VALIDATE DIALOGUE TEXT
        //Validate the dilaogue text
        public void ValidateDialogueDisplayText(IWebDriver driver, string messageText)
        {
            //Validate Dialogue Box
            var dialogueText = driver.FindElement(By.Id("messageText")).Text.Trim();
            Assert.AreEqual(dialogueText, messageText);
        }

        ////GENERIC DIALOGUE BOX - CANCEL
        //Close the dilaogue box
        public void DialogueClose(IWebDriver driver)
        {
            //Wuss out
            var common = new CommonSupportObjects();
            var cancelButton = driver.FindElement(By.Id("btnNo"));
            common.TabletClick(cancelButton, driver); 
            //cancelButton.Click();
        }

        ////OPEN HELP OVERLAY - DASHBOARD
        //Find and click the help link
        public void HelpOverlayOpenDashboard(IWebDriver driver)
        {
            //Set element to use AND alternative element
            string standardElement = "showHelpButton";
            string alternativeElement = "showHelpLink";

            //Locate link and click using Element Is Present validator
            var common = new CommonSupportObjects();
            common.ElementIsPresentClick(driver, standardElement, alternativeElement);

            //Wait for overlay to load
            driver.WaitForUpTo(60, "Still no overlay")
            .Until(ExpectedConditions.ElementExists(By.XPath("html/body/div[2]/hidden/div/div/button")));
        }


        ////OPEN HELP OVERLAY - VALIDATE BY ID
        //Find and click the help link
        public void HelpOverlayOpenValidateById(IWebDriver driver, string validationElement)
        {
            //Set element to use AND alternative element
            string standardElement = "showHelpButton";
            string alternativeElement = "showHelpLink";

            //Locate link and click using Element Is Present validator
            var common = new CommonSupportObjects();
            common.ElementIsPresentClick(driver, standardElement, alternativeElement);

            //Wait for overlay to load
            driver.WaitForUpTo(60, "Still no overlay")
            .Until(ExpectedConditions.ElementExists(By.Id(validationElement)));
        }


        ////OPEN HELP OVERLAY - VALIDATE BY PATH
        //Find and click the help link
        public void HelpOverlayOpenValidateByPath(IWebDriver driver, string validationPath)
        {
            //Set element to use AND alternative element
            string standardElement = "showHelpButton";
            string alternativeElement = "showHelpLink";

            //Locate link and click using Element Is Present validator
            var common = new CommonSupportObjects();
            common.ElementIsPresentClick(driver, standardElement, alternativeElement);

            //Wait for overlay to load
            driver.WaitForUpTo(30, "Still no overlay")
            .Until(ExpectedConditions.ElementExists(By.XPath(validationPath)));
        }



        ////CLOSE HELP OVERLAY CLOSE - GENERIC
        //Find and click the Got It! link
        public void HelpOverlayCloseGeneric(IWebDriver driver, string pageValidator)
        {
            //Locate link and click
            //var gotIt = driver.FindElement(By.XPath("html/body/div[1]/hidden/div/div/button"));
            var gotIt = driver.FindElement(By.XPath("html/body/div[2]/hidden/div/div/button"));

            var common = new CommonSupportObjects();
            common.TabletClick(gotIt, driver);

            //Wait for page to return:
            GenericWait(driver, pageValidator);
            //driver.WaitForUpTo(30, "Frozen in a helpfull wasteland")
            //.Until(ExpectedConditions.ElementExists(By.Id(pageValidator)));
        }

        ////CLOSE HELP OVERLAY CLOSE - SPECIFIED
        //Find and click the Got It! link
        public void HelpOverlayCloseSpecified(IWebDriver driver, string pageValidator, string buttonPath)
        {
            //Locate link and click
            //var gotIt = driver.FindElement(By.XPath("html/body/div[1]/div[1]/button"));
            var gotIt = driver.FindElement(By.XPath(buttonPath));

            var common = new CommonSupportObjects();
            common.TabletClick(gotIt, driver);

            //Wait for page to return:
            GenericWait(driver, pageValidator);
            //driver.WaitForUpTo(30, "Frozen in a helpfull wasteland")
            //.Until(ExpectedConditions.ElementExists(By.Id(pageValidator)));
        }




        ////LINK TO LOGOUT
        //Find and click LOGOUT button, wait for dialogue
        public void LogoutButton(IWebDriver driver)
        {
            //Set element to use AND alternative element
            string standardElement = "logoutButton";
            string alternativeElement = "logoutLink";

            //Locate link and click using Element Is Present validator
            var common = new CommonSupportObjects();
            common.ElementIsPresentClick(driver, standardElement, alternativeElement);

            //If spinner displayed, wait...
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "No dialogue, no soliloquy")
                .Until(ExpectedConditions.ElementExists(By.Id("messageTitle")));
            }
        }

        ////LINK TO CLIENT HISTORY - NO DIALOGUE (Benefits Summary)
        //Find and click Client History
        public void ClientHistoryButton(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var clientHistory = driver.FindElement(By.Id("clientHistoryMenuLink"));
            common.TabletClick(clientHistory, driver);
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "Expected page not reached - Client History")
                .Until(ExpectedConditions.ElementExists(By.Id("client-history")));
            }
        }


        ////LINK TO CLIENT HISTORY - DIALOGUE
        //Find and click Client History
        public void ClientHistoryButtonDialogue(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var clientHistory = driver.FindElement(By.Id("clientHistoryMenuLink"));
            common.TabletClick(clientHistory, driver);
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "No dialogue, no soliloquy")
                .Until(ExpectedConditions.ElementExists(By.Id("messageTitle")));
            }
        }

        ////LINK TO ADD CLIENT - NO DIALOGUE (Client History)
        //Find and click Add Client link
        public void AddClientButton(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var addClient = driver.FindElement(By.Id("addClientMenuLink"));
            common.TabletClick(addClient, driver);
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "Didn't make it to Client Details")
                .Until(ExpectedConditions.ElementExists(By.Id("clientDetails")));
            }
        }

        ////LINK TO ADD CLIENT - DIALOGUE
        //Find and click Add Client link
        public void AddClientButtonDialogue(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var addClient = driver.FindElement(By.Id("addClientMenuLink"));
            common.TabletClick(addClient, driver);
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "No dialogue, no soliloquy")
                .Until(ExpectedConditions.ElementExists(By.Id("messageTitle")));
            }
        }

        ////LINK TO EDIT CLIENT - NO DIALOGUE (Client History)
        //Find and click Add Client link
        public void EditClientButton(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var editClient = driver.FindElement(By.Id("editViewClientMenuLink"));
            common.TabletClick(editClient, driver);
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "Didn't make it to Client Details")
                .Until(ExpectedConditions.ElementExists(By.Id("clientDetails")));
            }
        }

        ////LINK TO EDIT CLIENT - DIALOGUE
        //Find and click Add Client link
        public void EditClientButtonDialogue(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var editClient = driver.FindElement(By.Id("editViewClientMenuLink"));
            common.TabletClick(editClient, driver);
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "No dialogue, no soliloquy")
                .Until(ExpectedConditions.ElementExists(By.Id("messageTitle")));
            }
        }

        ////LINK TO NEW QUOTE - NO DIALOGUE (Client History)
        //Find and click Add Client link
        public void NewQuoteButton(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var newQuote = driver.FindElement(By.Id("newQuoteMenuLink"));
            common.TabletClick(newQuote, driver);
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "Didn't make it to Benefit Summary")
                .Until(ExpectedConditions.ElementExists(By.Id("benefit-summary")));
            }
        }

        ////LINK TO NEW QUOTE - DIALOGUE
        //Find and click Add Client link
        public void NewQuoteButtonDialogue(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var newQuote = driver.FindElement(By.Id("newQuoteMenuLink"));
            common.TabletClick(newQuote, driver);
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "No dialogue, no soliloquy")
                .Until(ExpectedConditions.ElementExists(By.Id("messageTitle")));
            }
        }



        ////LINK TO NEW QUOTE - DIALOGUE
        //Find and click Add Client link
        public void BenefitSaveButton(IWebDriver driver, string benefitId)
        {
            //Locate link and click - Use benefit ID to save benefit, unless IP
            try
            {
                var common = new CommonSupportObjects();
                var saveBenefit = driver.FindElement(By.Id(benefitId + "-save-benefit-button"));
                common.TabletClick(saveBenefit, driver);
            }
            catch
            {
                new IncomeProtectionPageObjects().IpSaveButton(driver);
            }
            
            //Wait while...
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "Benefit not added, or Summary not reached")
                .Until(ExpectedConditions.ElementExists(By.Id(benefitId+"Summary")));
            }
        }

        ////LINK TO NEW QUOTE - DIALOGUE
        //Find and click Add Client link
        public void BenefitCancelButton(IWebDriver driver, string benefitId)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var cancelBenefit = driver.FindElement(By.Id(benefitId+"-cancel-button"));
            common.TabletClick(cancelBenefit, driver);
            
            //Wait on dialogue...
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "No dialogue, no soliloquy")
                .Until(ExpectedConditions.ElementExists(By.Id("messageTitle")));
            }
        }


        ////BENEFIT SCREEN INDICATIVE PREMIUM READER
        //Returns the premium from the indicative premium window sans whitespace
        public string BenefitIndicativePremiumReader(IWebDriver driver, string benefitId)
        {
            //Set element to use AND alternative element
            string standardReadElement = (benefitId + "IndicativeQuoteOriginal");
            string alternativeReadElement = (benefitId + "IndicativePremiumCalculated");

            var returnBenefitValue = new CommonSupportObjects().ElementIsPresentRead(driver, standardReadElement, alternativeReadElement);

            return returnBenefitValue.Trim();
        }


        ////CALL MATRIX SCREEN
        //CLick on the matrix link for any benefit
        public void BenefitMatrixScreenButton(IWebDriver driver, string benefitId)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var matrixQuote = driver.FindElement(By.Id(benefitId + "SummaryMatrix"));
            common.TabletClick(matrixQuote, driver);
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "No dialogue, no soliloquy")
                .Until(ExpectedConditions.ElementExists(By.Id("messageTitle")));
            }
        }




        ////EDIT EXISTING BENEFIT
        //CLick on the Edit button for any benefit
        public void BenefitEditButton(IWebDriver driver, string benefitId)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var editBenefit = driver.FindElement(By.Id(benefitId + "SummaryDelete"));
            common.TabletClick(editBenefit, driver);
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "No dialogue, no soliloquy")
                .Until(ExpectedConditions.ElementExists(By.Id("messageTitle")));
            }
        }



        ////DELETE BENEFIT
        //Delete any beenfit on the benefit selection screen
        public void BenefitDeleteButton(IWebDriver driver, string benefitId)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var deleteBenefit = driver.FindElement(By.Id(benefitId + "SummaryDelete"));
            common.TabletClick(deleteBenefit, driver);
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "No dialogue, no soliloquy")
                .Until(ExpectedConditions.ElementExists(By.Id("messageTitle")));
            }
        }


        ////CLOSE NEW WINDOW (OR TAB)
        //Closes the current window and returns focus to the "origianl window"
        public void NewWindowClose(IWebDriver driver, string originalWindow)
        {
            //Close existing window:
            driver.Close();

            //Switch focus to original window:
            driver.SwitchTo().Window(originalWindow);
        }



        ////SELECT LIFE - ALL BENFIT DETAILS SCREENS
        //Select the required LIFE on any Benefit Details screen
        public void BenefitDetailsChooseLife(IWebDriver driver, string benefitId, string lifeAssured)
        {
            //benefitId = dta/lta etc
            //lifeAssured = FirstLife/SecondLife/JointLives
            
            //Locate link and click
            if (benefitId == "ip")
            {
                var ipLifeClick = driver.FindElement(By.Id("ip" + lifeAssured));
                new CommonSupportObjects().TabletClick(ipLifeClick, driver);
            }
            else
            {
                var lifeClick = driver.FindElement(By.Id(benefitId + lifeAssured + "new"));
                new CommonSupportObjects().TabletClick(lifeClick, driver);
            }
        }









    }
}
