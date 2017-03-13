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

namespace SolutionBuilderQuoteDetailsPageObjects
{
    public class ProvidersNotQuotingPageObjects
    {

        //PROVIDERS NOT QUOTING - OPEN FROM MENU
        //premiumCellOptionsPNQ_SingleBenefit_    -   premiumCellOptionsPNQ_MultiProvider_B2
        public void PNQOpenMenu(IWebDriver driver, string quoteType, string benefitInstance)
        {
            var pnqOpenMenu = driver.FindElement(By.Id("premiumCellOptionsPNQ_" + quoteType + "_" + benefitInstance));
            new CommonSupportObjects().TabletClick(pnqOpenMenu, driver);
        }



        //PROVIDERS NOT QUOTING - OPEN FROM ICON
        //premiumCellComparisonExclusions_SingleBenefit_
        public void PNQOpen(IWebDriver driver, string quoteType, string benefitInstance)
        {
            var pnqOpenIcon = driver.FindElement(By.Id("premiumCellComparisonExclusions_" + quoteType + "_" + benefitInstance));
            new CommonSupportObjects().TabletClick(pnqOpenIcon, driver);
        }



        //PNQ - EXPAND NOTES
        //
        public void PNQExpand(IWebDriver driver)
        {
            var pnqExpand = driver.FindElement(By.XPath(".//*[@id='providersNotQuotingModalBody']/div/accordion/div/div[2]"));
            new CommonSupportObjects().TabletClick(pnqExpand, driver);
        }


        //PNQ - CLOSE
        //
        public void PNQClose(IWebDriver driver)
        {
            var pnqClose = driver.FindElement(By.Id("premiumCellResultsClose"));
            new CommonSupportObjects().TabletClick(pnqClose, driver);
        }


        //PNQ - SELECT ALTERNATIVE
        //
        public void PNQSelectAlternative(IWebDriver driver)
        {
            var selectAlternative = driver.FindElement(By.Id("premiumCellDialogToProvidersNotQuoting"));
            new CommonSupportObjects().TabletClick(selectAlternative, driver);

            string pageValidator = "alternativeProductsRows";
            new CommonSolutionBuilderPageObjects().SpinnerWait(driver, pageValidator);
        }


    }
}