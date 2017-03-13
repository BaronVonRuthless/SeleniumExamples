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

    //This class contains common actions that occur only on the differetn results screens

    public class XraePageObjects
    {
        //XRAE BUTTON
        //Main XRAE link from results screen
        public void XraeLinkButton(IWebDriver driver)
        {
            var xraeButton = driver.FindElement(By.Id("xraeBtn"));
            new CommonSupportObjects().TabletClick(xraeButton, driver);
        }
        


        //XRAE POP-UP CLOSE
        //Close the XRAE pop-up
        public void XraeModalClose(IWebDriver driver)
        {
            var closeButton = driver.FindElement(By.Id("xraeLifeDetailsCloseButton"));
            new CommonSupportObjects().TabletClick(closeButton, driver);
        }


        //XRAE FIRST LIFE
        //Select the first life create/return
        public string XraeFirstLife(IWebDriver driver)
        {
            var firstLife = driver.FindElement(By.Id("xraeLifeDetailsFirstLife"));
            new CommonSupportObjects().TabletClick(firstLife, driver);

            var originalWindow = driver.WindowHandles[0];
            var newWindowHandle = driver.WindowHandles[1];
            driver.SwitchTo().Window(newWindowHandle);

            driver.WaitForUpTo(30, "Didn't make it to XRAE")
                .Until(ExpectedConditions.ElementExists(By.Id("navMenu_btnNewCase")));

            return originalWindow;
        }



        //XRAE SECOND LIFE
        //Select the second life create/return
        public string XraeSecondLife(IWebDriver driver)
        {
            var secondLife = driver.FindElement(By.Id("xraeLifeDetailsSecondLife"));
            new CommonSupportObjects().TabletClick(secondLife, driver);

            var originalWindow = driver.WindowHandles[0];
            var newWindowHandle = driver.WindowHandles[1];
            driver.SwitchTo().Window(newWindowHandle);

            driver.WaitForUpTo(30, "Didn't make it to XRAE")
                .Until(ExpectedConditions.ElementExists(By.Id("navMenu_btnNewCase")));

            return originalWindow;
        }



        //XRAE NEWS LINK
        //Hit the XRAE news link and follow through to the new page
        public string XraeNews(IWebDriver driver)
        {
            driver.FindElement(By.Id("XraeNewsLink")).Click();
            //var xraeNews = driver.FindElement(By.Id("XraeNewsLink"));
            //new CommonSupportObjects().TabletClick(xraeNews, driver);

            var originalWindow = driver.WindowHandles[0];
            var newWindowHandle = driver.WindowHandles[1];
            driver.SwitchTo().Window(newWindowHandle);

            driver.WaitForUpTo(30, "Didn't make it to XRAE News")
                .Until(ExpectedConditions.ElementExists(By.Id("maincontent")));

            return originalWindow;
        }


        //XRAE USERE GUIDE
        //Link out to XRAE user guide
        public string XraeUserGuide(IWebDriver driver)
        {
            driver.FindElement(By.XPath(".//*[@id='xraeLifeDetails']/div/div[2]/div[2]/span/a[2]")).Click();
            //var userGuide = driver.FindElement(By.XPath(".//*[@id='xraeLifeDetails']/div/div[2]/div[2]/span/a[2]"));
            //new CommonSupportObjects().TabletClick(userGuide, driver);

            var originalWindow = driver.WindowHandles[0];
            var newWindowHandle = driver.WindowHandles[1];
            driver.SwitchTo().Window(newWindowHandle);

            driver.WaitForUpTo(30, "Didn't make it to XRAE User Guide")
                .Until(ExpectedConditions.UrlContains("xraeuserguide.pdf"));
            
            return originalWindow;
        }




    }
}
