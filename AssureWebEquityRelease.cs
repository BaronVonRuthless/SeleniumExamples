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
    class AssureWebEquityRelease : TestBase
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

        #region Equity Release Tests

        ////TEST 5.1
        //
        [Test, Parallelizable, Description("Select Comparison Quote Option (Equity)")]
        public void EquityComparisonQuote(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);
            
            //Open Equity Menu
            var equityObjects = new AssureWebEquityReleasePageObjects();
            equityObjects.EquityReleaseClick(driver);

            //Select Comparison Quote
            equityObjects.ComparisonQuoteEquityClick(driver);

            //Switch to iFrame
            string frameIdentifier = "tpi-iframe";
            var commonAss = new CommonAssureWebPageObjects();
            commonAss.PageFocusIFrame(driver, frameIdentifier);

            //DefaultWait for iFrame Content
            string pageValidator = "applicantsf";
            var commonSol = new CommonSolutionBuilderPageObjects();
            commonSol.GenericWait(driver, pageValidator);

            //Validate
            Assert.IsTrue(driver.FindElement(By.Id(pageValidator)).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST 5.2
        //
        [Test, Parallelizable, Description("Select About Equity Release Option")]
        public void EquityAboutRelease(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Open Equity Menu
            var equityObjects = new AssureWebEquityReleasePageObjects();
            equityObjects.EquityReleaseClick(driver);

            //Select About Equity Release
            equityObjects.AboutEquityReleaseClick(driver);
            
            //DefaultWait for Content
            string pageValidator = "aboutEquityRelease-content";
            var commonSol = new CommonSolutionBuilderPageObjects();
            commonSol.GenericWait(driver, pageValidator);

            //Validate
            Assert.IsTrue(driver.FindElement(By.Id(pageValidator)).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST 5.3
        //
        [Test, Parallelizable, Description("Select Benefit Calculator Option")]
        public void EquityStateBenefitCalculator(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Open Equity Menu
            var equityObjects = new AssureWebEquityReleasePageObjects();
            equityObjects.EquityReleaseClick(driver);

            //Select State benefit Calculator
            equityObjects.StateBenefitCalculatorClick(driver);

            //DefaultWait for Content
            string pageValidator = "stateBenefitsCalculator-content";
            var commonSol = new CommonSolutionBuilderPageObjects();
            commonSol.GenericWait(driver, pageValidator);

            //Validate
            Assert.IsTrue(driver.FindElement(By.Id(pageValidator)).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST 5.4
        //
        [Test, Parallelizable, Description("Select Provider Profiles")]
        public void EquityProviderProfiles(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Open Equity Menu
            var equityObjects = new AssureWebEquityReleasePageObjects();
            equityObjects.EquityReleaseClick(driver);

            //Select Provider Profile
            var announceObjects = new AssureWebAnnouncementsPageObjects();
            announceObjects.ProviderProfilesClick(driver);

            //Switch to iFrame
            //string frameIdentifier = "tpi-iframe";
            //var commonAss = new CommonAssureWebPageObjects();
            //commonAss.PageFocusIFrame(driver, frameIdentifier);

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
