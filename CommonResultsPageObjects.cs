using System;
using NUnit.Framework;
using Selenium;
using System.Web;
using System.Text;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using RegManagerPageObjects;
using SolutionBuilderClientDetailsPageObjects;
using Common;
using System.Collections.Generic;

namespace Common
{

    //This class contains common actions that occur only on the differetn results screens

    public class CommonResultsPageObjects
    {
        //TITLE BAR
        //Finds and clicks title bar, uses quoteType and benefitInstance - follow with "SpinnerWait"
        public void SelectTitleBar(IWebDriver driver, string quoteType, string benefitInstance)
        {
            var titleBar = driver.FindElement(By.Id("premiumCellTitle_" + quoteType + "_" + benefitInstance));
            new CommonSupportObjects().TabletClick(titleBar, driver);
        }


        //ALTERNATIVES
        //Finds and clicks alternatives button, uses quoteType and benefitInstance - follow with "SpinnerWait"
        public void SelectAlternativeIcon(IWebDriver driver, string quoteType, string benefitInstance)
        {
            var selectAlternative = driver.FindElement(By.Id("premiumCellComparisonAlternatives_" + quoteType + "_" + benefitInstance));
            new CommonSupportObjects().TabletClick(selectAlternative, driver);
        }


        //NOT QUOTED
        //Finds and clicks not quoted button, uses quoteType and benefitInstance - follow with "SpinnerWait"
        public void ProductsNotQuotingIcon(IWebDriver driver, string quoteType, string benefitInstance)
        {
            var productsNot = driver.FindElement(By.Id("premiumCellComparisonExclusions_" + quoteType + "_" + benefitInstance));
            new CommonSupportObjects().TabletClick(productsNot, driver);
        }


        //WARNINGS
        //Finds and clicks waqrnings icon, uses quoteType and benefitInstance - follow with "SpinnerWait"
        public void ProductWarningsIcon(IWebDriver driver, string quoteType, string benefitInstance)
        {
            var productWarnings = driver.FindElement(By.Id("premiumCellQuoteWarning_" + quoteType + "_" + benefitInstance));
            new CommonSupportObjects().TabletClick(productWarnings, driver);
        }



        //XRAE GLYPH - SINGLE & JOINT
        //Select the XRAE glyph using quoteTypeIcons to define - follow with SpinnerWait
        public void XraeIconSingleJoint(IWebDriver driver, string quoteTypeLower)
        {
            var xraeGlyph = driver.FindElement(By.XPath(".//*[@id='" + quoteTypeLower + "PremiumCell" + "']/div/div[2]/div[1]/div[2]/div/span/span/i[2]"));
            xraeGlyph.Click();
        }
        //.//*[@id='singleProviderPremiumCell_MB']/div/div[2]/div[1]/div[2]/div/span/span/i[2]



        //XRAE GLYPH - MULTI BENEFIT
        //Select the XRAE glyph using quoteTypeIcons to define - follow with SpinnerWait
        public void XraeIconMultiBenefit(IWebDriver driver, string quoteTypeLower, string benefitInstance)
        {
            var xraeGlyph = driver.FindElement(By.XPath(".//*[@id='" + quoteTypeLower + "PremiumCell_" + benefitInstance + "']/div/div[2]/div[1]/div[2]/div/span/span/i[2]"));
            xraeGlyph.Click();
        }
        //.//*[@id='singleProviderPremiumCell_MB']/div/div[2]/div[1]/div[2]/div/span/span/i[2]


        //LIKE FLAG
        //Select the flag of the first quote on screen - needs solutionType from:
        //quickQuote, jointPolicy, individualPolicy, singleProvider, hybrid, multiProvider
        //validate selected with "'solutionCountBadge' is displayed"
        public void SelectFirstFlag(IWebDriver driver, string quoteTypeLower)
        {
            var likeFlag = driver.FindElement(By.Id(quoteTypeLower + "LikeButton"));
            new CommonSupportObjects().TabletClick(likeFlag, driver);
        }


        
        
        
        //FULL DETAILS - SINGLE LIFE
        public void FullDetailsSingleOpen(IWebDriver driver)
        {
            var openDetails = driver.FindElement(By.Id("resultsSummaryFullDetails"));
            new CommonSupportObjects().TabletClick(openDetails, driver);
        }



        //FULL DETAILS - MULTI BENEFIT
        public void FullDetailsMultiOpen(IWebDriver driver, string benefitType, int benefitInstance)
        {
            var openDetails = driver.FindElement(By.Id("modal" + benefitType + benefitInstance + "Button"));
            new CommonSupportObjects().TabletClick(openDetails, driver);
        }
        //modalLevelTerm0Button - modalDecreasingTerm1Button - etc




            //FULL DETAILS - CLOSE
            //Click the "Cancel" button on the Full Details pop-up
            public void FullDetailsClose(IWebDriver driver)
            {
                var button = driver.FindElement(By.Id("resultsSummaryInputsClose"));
                new CommonSupportObjects().TabletClick(button, driver);
            }




            //FULL DETAILS CLOSE - MULTI
            //Click the "Cancel" button on the Full Details pop-up
            public void FullDetailsCloseMulti(IWebDriver driver, string benefitType, int benefitInstance)
            {
                var button = driver.FindElement(By.Id("resultsSummaryInputsClose_" + benefitType + benefitInstance));
                new CommonSupportObjects().TabletClick(button, driver);
            }




            //FULL DETAILS - READ SINGLE / JOINT BENEFIT TITLE
            //Read the text from the benefit title bar in the full details modal and return
            public string FullDetailsReadTitleSingle(IWebDriver driver)
            {
                //var benefitTitle = driver.FindElement(By.Id("resultsSummaryInputsBenefitTitle")).Text;
                var benefitTitle = driver.FindElement(By.Id("resultsInputBenefitSummaryTitle")).Text;

                return benefitTitle.ToString();
            }
            

            //FULL DETAILS - READ MULTI BENEFIT TITLE
            //Read the text from the benefit title bar in the full details modal and return
            public string FullDetailsReadTitleMulti(IWebDriver driver, string benefitType, int benefitInstance)
            {
                var benefitTitle = driver.FindElement(By.Id("resultsSummaryInputsBenefitTitle_" + benefitType + benefitInstance)).Text;
                return benefitTitle.ToString();
            }


        //REQUOTE
        //Click the requote button (all menu builder types) - follow with SpinnerWait
        public void Requote(IWebDriver driver)
        {
            var requoteButton = driver.FindElement(By.Id("requoteBtn"));
            new CommonSupportObjects().TabletClick(requoteButton, driver);
        }


        //PRINT
        //Select Print option and follow link to new page
        public string Print(IWebDriver driver)
        {
            //try
            //{
                ////Click "Print" button
                //driver.FindElement(By.XPath(".//*[@id='printBtn']/a")).Click();
            //}
            //catch (Exception)
            //{
                //Click "Print" button
                var printButton = driver.FindElement(By.Id("printBtn"));
                new CommonSupportObjects().TabletClick(printButton, driver);            
            //}

            //validate new page and close
            var originalWindow = driver.WindowHandles[0];
            var newWindowHandlePrint = driver.WindowHandles[1];
            driver.SwitchTo().Window(newWindowHandlePrint);

            return originalWindow;
        }



        //XRAE LINK
        //Select XRAE link and follow to new window
        public void XraeModalButton(IWebDriver driver)
        {
            var xraeButton = driver.FindElement(By.Id("xraeBtn"));
            new CommonSupportObjects().TabletClick(xraeButton, driver);
        }
    }
}
