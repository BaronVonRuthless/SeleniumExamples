using System;
using NUnit.Framework;
using Selenium;
using System.Web;
using System.Text;
using System.Net;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Common;
using RegManagerPageObjects;

namespace SolutionBuilderClientDetailsPageObjects
{
    public class IncomeProtectionPageObjects
    {
        
        ////SELECT PREMIUM TYPE - ALL
        //Click "All"
        public void PremiumTypeAll(IWebDriver driver)
        {
            //Locate save and click
            var ptAll = driver.FindElement(By.Id("ipAllPremiumTypes"));
            new CommonSupportObjects().TabletClick(ptAll, driver);
        }

        ////SELECT PREMIUM TYPE - GUARANTEED
        //Click "Guaranteed"
        public void PremiumTypeGuaranteed(IWebDriver driver)
        {
            //Locate save and click
            var ptGuaranteed = driver.FindElement(By.Id("ipGuaranteedPremium"));
            new CommonSupportObjects().TabletClick(ptGuaranteed, driver);
        }

        ////SELECT PREMIUM TYPE - REVIEWABLE
        //Click "Reviewable"
        public void PremiumTypeReviewable(IWebDriver driver)
        {
            //Locate save and click
            var ptReviewable = driver.FindElement(By.Id("ipReviewablePremium"));
            new CommonSupportObjects().TabletClick(ptReviewable, driver);
        }
        
        
        
        
        
        ////INPUT BENEFIT AMOUNT
        //Enter the term years required
        public void IPBenefitAmount(IWebDriver driver, string benefitAmount)
        {
            //Locate link and click
            var benefitInput = driver.FindElement(By.Id("ipBenefitAmount"));
            benefitInput.SendKeys(benefitAmount);
        }

        ////SELECT DEFERRED PERIOD
        //Select from the dropdown
        public void IPDeferredPeriod(IWebDriver driver, string browserName)
        {
            if (browserName != "MicrosoftEdge")

                try
                {
                    //var dropDown = 
                    driver.FindElement(By.XPath(".//*[@id='deferredPeriod']/option[6]")).Click();
                    //new CommonSupportObjects().TabletClick(dropDown, driver);
                }
                catch
                {
                    var element = driver.FindElement(By.Id("deferredPeriod"));
                    element.Click();
                    element.SendKeys("2");
                    element.SendKeys("2");
                    element.SendKeys(Keys.Enter);
                }

            else
            {
                var element = driver.FindElement(By.Id("deferredPeriod"));
                element.Click();
                element.SendKeys(Keys.Down);
                element.SendKeys(Keys.Down);
                element.SendKeys(Keys.Down);
                element.SendKeys(Keys.Down);
                element.SendKeys(Keys.Down);
                element.SendKeys(Keys.Enter);
            }
        }

        ////SAVE IP BENEFIT
        //Unique Save button for IP
        public void IpSaveButton(IWebDriver driver)
        {
            //Locate save and click
            var saveButton = driver.FindElement(By.Id("ipAddBenefit"));
            new CommonSupportObjects().TabletClick(saveButton, driver);
        }

        ////CANCEL IP BENEFIT
        //Unique Cancel button for IP
        public void IpCancelBenefit(IWebDriver driver)
        {
            //Locate save and click
            var common = new CommonSupportObjects();
            var cancelButton = driver.FindElement(By.Id("ipRemoveBenefit"));
            common.TabletClick(cancelButton, driver);
        }
		


        ////MINIMUM DETAILS
        //As above, entry of the bare minimum to complete NO XRAE
        public void IpMinimalBenefitDetails(IWebDriver driver, string benefitAmount, string browserName)
        {
            var thisPage = new IncomeProtectionPageObjects();

            //Run through the three basic steps to complete the LTA benefit:
            thisPage.IPBenefitAmount(driver, benefitAmount);
            thisPage.IPDeferredPeriod(driver, browserName);
        }

        ////VALIDATE DIALOGUE TEXT
        //Validate the dilaogue text
        public void IpValidateDialogueDisplayText(IWebDriver driver, string messageText)
        {
            //Validate Dialogue Box
            var dialogueText = driver.FindElement(By.Id("messageText")).Text.Trim();
            Assert.AreEqual(dialogueText, messageText);
        }


        ////GENERIC DIALOGUE BOX - CANCEL
        //Close the dilaogue box
        public void IpDialogueClose(IWebDriver driver)
        {
            //Wuss out
            var common = new CommonSupportObjects();
            var cancelButton = driver.FindElement(By.Id("btnNo"));
            common.TabletClick(cancelButton, driver);
            //cancelButton.Click();
        }


        ////LINK TO NEW QUOTE - DIALOGUE
        //Find and click Add Client link
        public void IpBenefitCancelButton(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var cancelBenefit = driver.FindElement(By.Id("ipRemoveBenefit"));
            common.TabletClick(cancelBenefit, driver);

            //Wait on dialogue...
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "No dialogue, no soliloquy")
                .Until(ExpectedConditions.ElementExists(By.Id("messageTitle")));
            }
        }

        ////GENERIC DIALOGUE BOX - YES
        //Select "Yes" and check next page is reached
        public void IpDialogueYes(IWebDriver driver)
        {
            //Go through with it
            var common = new CommonSupportObjects();
            var okButton = driver.FindElement(By.Id("btnYes"));
            common.TabletClick(okButton, driver);
            //okButton.Click();
        }
        
                                //////  CONOR
        ////IP OCCUPATION DETAILS DIALOGUE - CANCEL
        //Close the dialogue box
        public void IpOccupationDetailsCancel(IWebDriver driver)
        {
            //Calcer (close) the dialogue box
            var common = new CommonSupportObjects();
            var cancelButton = driver.FindElement(By.Id("clientOccupationDetailsCancel"));
            common.TabletClick(cancelButton, driver);   
        }
                                //////  CONOR

    }
}