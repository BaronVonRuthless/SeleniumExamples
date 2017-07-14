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

namespace AssureWebPageObjects
{
    class AssureWebRetirementPlanningPageObjects
    {
        #region Retirement Planning

        ////CLICK THE RETIREMENT PLANNING OPTION
        //
        public void RetirementPlanningClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.XPath(".//*[@id='RetirementPlanning-header']/div[2]")).Click();
        }

        ////CLICK THE QUICK QUOTE OPTION
        //
        public void AnnuityQuickClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.Id("AnnuityQuickQuote")).Click();
        }

        ////CLICK THE DETAILED QUOTE OPTION
        //
        public void AnnuityDetailedClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.Id("AnnuityDetailedQuote")).Click();
        }

        ////CLICK THE RDR PENSIONS OPTION
        //
        public void PensionsClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.Id("Pensions")).Click();
        }

        ////CLICK THE iGO e-App OPTION
        //
        public void IGOClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.Id("iGOe-App")).Click();
        }

        #endregion




    }
}
