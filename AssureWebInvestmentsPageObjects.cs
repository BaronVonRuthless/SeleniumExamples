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
    class AssureWebInvestmentsPageObjects
    {
        #region Investments

        ////CLICK THE INVESTMENTS OPTION
        //
        public void InvestmentsClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.XPath(".//*[@id='Investments-header']/div[2]")).Click();
        }

        ////CLICK THE BONDS OPTION
        //
        public void BondsClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.Id("Bonds")).Click();
        }

        #endregion




    }
}
