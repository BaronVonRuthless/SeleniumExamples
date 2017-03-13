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

namespace SolutionBuilderQuoteDetailsPageObjects
{
    public class DetailedQuotePageObjects
    {
        //DETAILED QUOTE
        //Requires NewWindowClose to end
        public string DetailedQuote(IWebDriver driver, string quoteType, string benefitInstance)
        {
            var callReap = driver.FindElement(By.Id("premiumCellOptionsDetailedQuote_" + quoteType + "_" + benefitInstance));
            new CommonSupportObjects().TabletClick(callReap, driver);

            var originalWindow = driver.WindowHandles[0];
            var newWindowHandle = driver.WindowHandles[1];
            driver.SwitchTo().Window(newWindowHandle);

            try
            {
                driver.SwitchTo().DefaultContent();
                driver.WaitForUpTo(15, "Couldn't reach DQ portal link destination")
                .Until(ExpectedConditions.ElementExists(By.ClassName("ClientDetailsFormLabel")));

            }
            catch
            {
                IWebElement containerFrameDQ = driver.FindElement(By.Id("tpiContentArea"));
                driver.SwitchTo().Frame(containerFrameDQ);
                driver.WaitForUpTo(15, "Couldn't reach DQ portal link destination")
                .Until(ExpectedConditions.ElementExists(By.ClassName("ClientDetailsFormLabel")));
            }

            return originalWindow;
        }

        //PORTAL QUOTE
        //Quotes within the Assureweb Portal
        public void PortalQuoteClick(IWebDriver driver)
        {
            driver.FindElement(By.Id("ucClearSaveQuoteTop_lnkQuote_ClearSaveQuote")).Click();
            driver.WaitForUpTo(60, "Failed to reach results screen")
                .Until(ExpectedConditions.ElementExists(By.Id("tab_ProvidersNotQuoting")));
        }


        //DETAILED - CLOSE
        //
        public void DetailedClose(IWebDriver driver)
        {
            var detailedClose = driver.FindElement(By.Id("detailedQuoteCloseButton"));
            new CommonSupportObjects().TabletClick(detailedClose, driver);
        }


        //DETAILED - SAVE & APPLY
        //
        public void DetailedSaveApply(IWebDriver driver)
        {
            var detailedSave = driver.FindElement(By.XPath(".//*[@id='detailedQuoteDialog']/div/div/div[2]/div/hidden/div/button"));
            new CommonSupportObjects().TabletClick(detailedSave, driver);
        }

        //DETAILED - LIKE FIRST
        //
        public void DetailedLikeFirst(IWebDriver driver)
        {
            var detailedLike = driver.FindElement(By.Id("detailedQuoteLikeButton_0"));
            new CommonSupportObjects().TabletClick(detailedLike, driver);
        }

        //DETAILED - APPLY FIRST
        //
        public void DetailedApplyFirst(IWebDriver driver)
        {
            var detailedApply = driver.FindElement(By.Id("applyProduct_0"));
            new CommonSupportObjects().TabletClick(detailedApply, driver);
        }


        //DETAILED - RETURN TO COMPARISON
        //
        public string DetailedReturnToComp(IWebDriver driver)
        {
            driver.FindElement(By.Id("fullComparisonResultsButton")).Click();

            var originalWindow = driver.WindowHandles[0];
            var newWindowHandle = driver.WindowHandles[1];
            driver.SwitchTo().Window(newWindowHandle);

            driver.WaitForUpTo(60, "Couldn't reach DQ portal link destination")
                .Until(ExpectedConditions.TitleContains("Multi-Benefit Comparison"));

            return originalWindow;
        }





    }
}