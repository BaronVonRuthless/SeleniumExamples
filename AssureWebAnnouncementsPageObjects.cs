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
    public class AssureWebAnnouncementsPageObjects
    {
        #region Header Options

        ////CLICK MY SERVICES
        //Locate and interact with the "My iPipeline Services" button
        public void MyServices(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.Id("HeaderMyIpipelineButton")).Click();
        }

        ////CLICK LOGOUT
        //Locate and interact with the "Logout" button
        public void Logout(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.Id("HeaderLogoutButton")).Click();
        }

        ////CLICK THE HEADER
        //Locate and interact with the iPipeline header image
        public void HeaderClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.Id("HeaderIpipelineLogo")).Click();
        }

        #endregion



        #region Common Options

        ////CLICK THE PROVIDER LITERATURE OPTION
        //
        public void ProviderLiteratureClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.Id("ProviderLiterature")).Click();
        }

        ////CLICK THE PROVIDER PROFILES OPTION
        //
        public void ProviderProfilesClick(IWebDriver driver)
        {
            //Do A Thing
            driver.FindElement(By.Id("ProviderProfiles")).Click();
        }

        #endregion



    }
}
