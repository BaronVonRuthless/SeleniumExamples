using Gallio.Framework;
using Gallio.Model;
using MbUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using Common;
using RegManagerPageObjects;
using AssureWebPageObjects;

namespace AssureWebTESTS
{
    class AssureWebInvestments : TestBase
    {
        #region Support Methods

        //A bundle to quickly get you to the Dashboard
        public void RouteToAnnouncements(IWebDriver driver)
        {
            // Use login methods to call page, validate and attempt login
            var login = new RegManagerTESTS.LoginPage();
            login.LoginDefaultUser(driver);

            //Login to Solutiuon Builder
            var myServices = new MyServicesPageObjects();
            myServices.LaunchAssureWeb(driver);
        }

        #endregion

        #region Investments Tests

        ////TEST 4.1
        //
        [Test, Parallelizable, Description("Select Bonds Option")]
        public void InvestmentsBonds(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Open Investments Menu
            var investmentsObjects = new AssureWebInvestmentsPageObjects();
            investmentsObjects.InvestmentsClick(driver);

            //Select Bonds
            investmentsObjects.BondsClick(driver);

            //Switch to iFrame
            string frameIdentifier = "tpi-iframe";
            var commonAss = new CommonAssureWebPageObjects();
            commonAss.PageFocusIFrame(driver, frameIdentifier);

            //DefaultWait for iFrame Content
            string pageValidator = "ucClientDetailsFirstLife_ddlTaxRate";
            var commonSol = new CommonSolutionBuilderPageObjects();
            commonSol.GenericWait(driver, pageValidator);

            //Validate
            Assert.IsTrue(driver.FindElement(By.Id(pageValidator)).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST 4.2
        //
        [Test, Parallelizable, Description("Select Provider Literature")]
        public void InvestmentsProviderLiterature(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Open Investments Menu
            var investmentsObjects = new AssureWebInvestmentsPageObjects();
            investmentsObjects.InvestmentsClick(driver);

            //Select provider Literature
            var announceObjects = new AssureWebAnnouncementsPageObjects();
            announceObjects.ProviderLiteratureClick(driver);

            //Switch to iFrame
            string frameIdentifier = "tpi-iframe";
            var commonAss = new CommonAssureWebPageObjects();
            commonAss.PageFocusIFrame(driver, frameIdentifier);

            //DefaultWait for iFrame Content
            string pageValidator = "ProvidersDropDownList";
            var commonSol = new CommonSolutionBuilderPageObjects();
            commonSol.GenericWait(driver, pageValidator);

            //Validate
            Assert.IsTrue(driver.FindElement(By.Id(pageValidator)).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST 4.3
        //
        [Test, Parallelizable, Description("Select Provider Profiles")]
        public void InvestmentsProviderProfiles(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Open Investments Menu
            var investmentsObjects = new AssureWebInvestmentsPageObjects();
            investmentsObjects.InvestmentsClick(driver);

            //Select Provider Profiles
            var announceObjects = new AssureWebAnnouncementsPageObjects();
            announceObjects.ProviderProfilesClick(driver);

            //Switch to iFrame
            string frameIdentifier = "tpi-iframe";
            var commonAss = new CommonAssureWebPageObjects();
            commonAss.PageFocusIFrame(driver, frameIdentifier);

            //DefaultWait for iFrame Content
            string pageValidator = "ProviderProfilesGridView";
            var commonSol = new CommonSolutionBuilderPageObjects();
            commonSol.GenericWait(driver, pageValidator);

            //Validate
            Assert.IsTrue(driver.FindElement(By.Id(pageValidator)).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        #endregion

    }
}
