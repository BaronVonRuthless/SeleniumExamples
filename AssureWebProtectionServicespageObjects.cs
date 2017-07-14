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
    class AssureWebProtectionServicesPageObjects
    {
        #region Protection Services

        ////CLICK THE PROTECTION SERVICES OPTION
        //
        public void ProtectionServicesClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.XPath(".//*[@id='ProtectionServices-header']/div[2]")).Click();
        }

        ////CLICK THE ESSENTIAL PROTECTION OPTION
        //
        public void EssentialProtectionClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.Id("EssentialProtection")).Click();
        }

        ////CLICK THE INCOME PROTECTION OPTION
        //
        public void IncomeProtectionClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.Id("IncomeProtection")).Click();
        }

        ////CLICK THE BP & WOL OPTION
        //
        public void BpAndWolClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.Id("BusinessProtection&WholeofLife")).Click();
        }

        ////CLICK XRAE OPTION
        //
        public void XRAEClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.Id("XRAE-Underwriting")).Click();
        }

        #endregion




    }
}
