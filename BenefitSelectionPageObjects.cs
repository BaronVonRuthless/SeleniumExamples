using System;
using NUnit.Framework;
using Selenium;
using System.Web;
using System.Text;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Common;
using SolutionBuilderClientDetailsTESTS;

namespace SolutionBuilderClientDetailsPageObjects
{
    public class BenefitSelectionPageObjects
    {
        ////LINK TO ANY BENEFIT
        //Find and click add BENEFIT links
        public void AddNewBenefit(IWebDriver driver, string benefitId)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var addBenefit = driver.FindElement(By.Id("select-benefit-" + benefitId));
            common.TabletClick(addBenefit, driver);

            //If spinner displayed, wait...
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                try
                {
                    driver.WaitForUpTo(20, "Couldn't reach " + benefitId + " page")
                    .Until(ExpectedConditions.ElementExists(By.Id(benefitId + "Formnew")));
                }
                catch
                {
                    driver.WaitForUpTo(10, "Couldn't reach " + benefitId + " page")
                    .Until(ExpectedConditions.ElementExists(By.Id(benefitId + "Form")));
                }
            }
        }

        ////LINK TO COMMISION PAGE
        //Find and click edit commision link
        public void EditCommission(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var editComm = driver.FindElement(By.Id("commission-button"));
            common.TabletClick(editComm, driver);

            //If spinner displayed, wait...
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "Couldn't reach Commission page")
                .Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='commissionForm']/div[1]/div/h3")));
            }
        }


        ///QUOTE!
        /////Hit dat shit
        public void QuoteNow(IWebDriver driver)
        {
            //Locate the Quote Now button & click
            var common = new CommonSupportObjects();
            var quoteNow = driver.FindElement(By.Id("quote-button"));
            common.TabletClick(quoteNow, driver);

            //Transition to QUOTE RESULTS PAGE - generic wait
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(180, "Couldn't reach results")
                .Until(ExpectedConditions.ElementExists(By.Id("model-results")));
            }
        
        }


        ////INDICATIVE PREMIUM TOTAL CHECKER
        //Pulls and returns value from the indicative premium window trimmed of all whitespace
        public string TotalIndicativePremiumReader(IWebDriver driver)
        {
            //Set element to use AND alternative element
            string standardReadElement = ("indicativePremiumCalculated");
            string alternativeReadElement = ("indicativePremiumUnavailable");

            var returnTotalValue = new CommonSupportObjects().ElementIsPresentRead(driver, standardReadElement, alternativeReadElement);

            return returnTotalValue.Trim();
        }



        ////DELETE BENEFIT FROM SUMMARY
        //takes the benefitId and clicks the delete button. Use DIALOGUE in COMMON to Confirm
        public void DeleteBenefitFromSummary(IWebDriver driver, string benefitId)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var deleteBenefit = driver.FindElement(By.Id(benefitId + "SummaryDelete"));
            common.TabletClick(deleteBenefit, driver);

            //If spinner displayed, wait...
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "No dialogue, no soliloquy")
                .Until(ExpectedConditions.ElementExists(By.Id("messageTitle")));
            }
        }


        ////EDIT BEENFIT FROM SUMMARY
        //Takes benefitId and clicks appropriate View/Edit button from the benfit summary
        public void EditBenefitFromSummary(IWebDriver driver, string benefitId)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var addBenefit = driver.FindElement(By.Id(benefitId + "SummaryEdit"));
            common.TabletClick(addBenefit, driver);
        }



        ////Enter The Matrix
        //Click the matrix button for the elected benefit
        public void EnterMatrixFromSummary(IWebDriver driver, string benefitId)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var clickMatrix = driver.FindElement(By.Id(benefitId + "SummaryMatrix"));
            common.TabletClick(clickMatrix, driver);

            //If spinner displayed, wait...
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "No dialogue, no soliloquy")
                .Until(ExpectedConditions.ElementExists(By.Id("printMatrixButton")));
            }
        }


        ////DELETE BENEFIT FROM SUMMARY
        //Takes benefitId, deletes benefit entry from Summary
        public void DeleteBenefitFromSummaryConfirmDialogue(IWebDriver driver, string benefitId)
        {
            new BenefitSelectionPageObjects().DeleteBenefitFromSummary(driver, benefitId);
            string messageText = Constants.DELETE;
            var common = new CommonSolutionBuilderPageObjects();
            common.ValidateDialogueDisplayText(driver, messageText);
            common.DialogueYes(driver);
        }


        ////COMMON BENEFIT SUMMARY CHECKER
        //Takes benefitId, checks the links on the benefit sumamry screen
        public void CommonBenefitSummaryChecker(IWebDriver driver, string benefitId, string browserName)
        {
            //Add WOL + Input basic details and Save out to Benefit Selection screen
            var support = new CommonSupportObjects();
            var benefits = new BenefitSelectionPageObjects();

            //Select correctbeenfit and input
            if (benefitId.Equals("lta"))
            {
                support.AddBasicLevelTermBenefit(driver);
            }
            if (benefitId.Equals("dta"))
            {
                support.AddBasicDecreasingTermBenefit(driver);
            }
            if (benefitId.Equals("fib"))
            {
                support.AddBasicFamilyIncomeBenefit(driver);
            }
            if (benefitId.Equals("ip"))
            {
                //support.AddBasicIncomeProtectionBenefit(driver, browserName);
                benefits.AddNewBenefit(driver, benefitId);
                
                var inputIPValues = new IncomeProtectionPageObjects();
                string benefitAmount = Constants.ipBENEFITAMOUNT;
                inputIPValues.IPBenefitAmount(driver, benefitAmount);
                inputIPValues.IPDeferredPeriod(driver, browserName);
                inputIPValues.IpSaveButton(driver);
            }

            //Check matrix is accesible IF it is, go in and out:
            try
            {
                benefits.EnterMatrixFromSummary(driver, benefitId);
                new MatrixScreenPageObjects().ExitToBenefitSelectionScreen(driver);
            }

            //If NOT, then check that we're in "iPhone" mode (matrix unavaialble)
            catch
            {
                driver.FindElement(By.Id("myServicesLink"));
            }

            //Use Edit to return to benefit and then re-Save
            benefits.EditBenefitFromSummary(driver, benefitId);
            new CommonSolutionBuilderPageObjects().BenefitSaveButton(driver, benefitId);
        }


        ////MESSAGE BOARD READ
        //Read and return the screen text in the Benefit Summary message board
        public string MessageBoardRead(IWebDriver driver)
        {
            //Set variable to report value to:
            var returnValue = "";

            //Check page for the MEssage Board and read out the text
            try
            {
                returnValue = driver.FindElement(By.XPath(".//*[@id='benefit-summary']/div/div[1]/div[2]/h4")).Text;
            }
            //Just in case...
            catch
            {
                returnValue = "Sorry Bub, no text in 'ere.";
            }

            return returnValue.Trim();
        }
    }
}