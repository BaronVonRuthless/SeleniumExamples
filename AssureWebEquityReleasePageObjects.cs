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
    class AssureWebEquityReleasePageObjects
    {
        #region Equity Release

        ////CLICK THE EQUITY RELEASE OPTION
        //
        public void EquityReleaseClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.XPath(".//*[@id='EquityRelease-header']/div[2]")).Click();
        }

        ////CLICK THE COMPARISON QUOTE OPTION
        //
        public void ComparisonQuoteEquityClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.Id("ComparisonQuote")).Click();
        }

        ////CLICK THE ABOUT EQUITY OPTION
        //
        public void AboutEquityReleaseClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.Id("AboutEquityRelease")).Click();
        }

        ////CLICK THE BENEFIT CALCULATOR OPTION
        //
        public void StateBenefitCalculatorClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.Id("StateBenefitsCalculator")).Click();
        }

        #endregion





    }
}
