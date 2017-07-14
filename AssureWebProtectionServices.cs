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
    class AssureWebProtectionServices : TestBase
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

        #region Protection Services Tests

        ////TEST 2.1
        //
        [Test, Parallelizable, Description("Select Essential Protection Option")]
        public void ProtectionEssential(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Select Protection Services
            var protectionObjects = new AssureWebProtectionServicesPageObjects();
            protectionObjects.ProtectionServicesClick(driver);

            //Select Essential Protection:
            protectionObjects.EssentialProtectionClick(driver);

            //Switch to iFrame
            string frameIdentifier = "tpi-iframe";
            var commonAss = new CommonAssureWebPageObjects();
            commonAss.PageFocusIFrame(driver, frameIdentifier);

            //DefaultWait for iFrame Content
            string pageValidator = "EnhancedProtectionComparisonTitleText";
            var commonSol = new CommonSolutionBuilderPageObjects();
            commonSol.GenericWait(driver, pageValidator);

            //Validate
            Assert.IsTrue(driver.FindElement(By.Id(pageValidator)).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST 2.2
        //
        [Test, Parallelizable, Description("Select Income Protection Option")]
        public void ProtectionIncome(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Select Protection Services
            var protectionObjects = new AssureWebProtectionServicesPageObjects();
            protectionObjects.ProtectionServicesClick(driver);

            //Select Income Protection
            protectionObjects.IncomeProtectionClick(driver);

            //Switch to iFrame
            string frameIdentifier = "tpi-iframe";
            var commonAss = new CommonAssureWebPageObjects();
            commonAss.PageFocusIFrame(driver, frameIdentifier);

            //DefaultWait for iFrame Content
            string pageValidator = "txtOccupation";
            var commonSol = new CommonSolutionBuilderPageObjects();
            commonSol.GenericWait(driver, pageValidator);

            //Validate
            Assert.IsTrue(driver.FindElement(By.Id(pageValidator)).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST 2.3
        //
        [Test, Parallelizable, Description("Select Business Protection And WOL Options")]
        public void ProtectionBpAndWol(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Select Protection Services
            var protectionObjects = new AssureWebProtectionServicesPageObjects();
            protectionObjects.ProtectionServicesClick(driver);

            //Select BP and WOL
            protectionObjects.BpAndWolClick(driver);

            //Switch to iFrame
            string frameIdentifier = "tpi-iframe";
            var commonAss = new CommonAssureWebPageObjects();
            commonAss.PageFocusIFrame(driver, frameIdentifier);

            //DefaultWait for iFrame Content
            string pageValidator = "TermComparisonTitleText";
            var commonSol = new CommonSolutionBuilderPageObjects();
            commonSol.GenericWait(driver, pageValidator);

            //Validate
            Assert.IsTrue(driver.FindElement(By.Id(pageValidator)).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST 2.4
        //
        [Test, Parallelizable, Description("Select XRAE")]
        public void ProtectionXRAE(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Select Protection Services
            var protectionObjects = new AssureWebProtectionServicesPageObjects();
            protectionObjects.ProtectionServicesClick(driver);

            //Select XRAE Option
            protectionObjects.XRAEClick(driver);   

            //Follow to new PAGE
            var commonAss = new CommonAssureWebPageObjects();
            commonAss.PageFocusNewTab(driver);

            //Wait
            string pageValidator = "navMenu_btnNavCases";
            var commonSol = new CommonSolutionBuilderPageObjects();
            commonSol.GenericWait(driver, pageValidator);

            //Verify XRAE Page has loaded:
            Assert.IsTrue(driver.FindElement(By.Id(pageValidator)).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST 2.5
        //
        [Test, Parallelizable, Description("Select Provider Literature")]
        public void ProtectionProviderLiterature(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Select Protection Services
            var protectionObjects = new AssureWebProtectionServicesPageObjects();
            protectionObjects.ProtectionServicesClick(driver);

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

        ////TEST 2.6
        //
        [Test, Parallelizable, Description("Select Provider Profiles")]
        public void ProtectionProviderProfiles(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Select Protection Services
            var protectionObjects = new AssureWebProtectionServicesPageObjects();
            protectionObjects.ProtectionServicesClick(driver);

            //Select Provider Profiles
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
