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
    class AssureWebOtherServicesPageObjects
    {
        #region Other Services

        ////CLICK THE OTHER SERVICES OPTION
        //
        public void OtherServicesClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.XPath(".//*[@id='OtherServices-header']/div[2]")).Click();
        }

        ////CLICK THE DOCUMENT LIBRARY OPTION
        //
        public void DocumentLibraryClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.Id("DocumentLibrary")).Click();
        }

        #endregion



        #region Find My Quote & Apply

        ////CLICK THE FIND MY QUOTE OPTION
        //
        public void FindMyQuoteApplyClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.XPath(".//*[@id='FindMyQuote&Apply-header']/div[2]")).Click();
        }

        #endregion




    }
}
