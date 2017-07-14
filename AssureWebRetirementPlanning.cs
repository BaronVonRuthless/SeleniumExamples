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
    class AssureWebRetirementPlanning : TestBase
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

        #region Retirement Planning Tests

        ////TEST 3.1
        //
        [Test, Parallelizable, Description("Select Annuity Quick Quote Option")]
        public void RetirementQuickQuote(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Open Retirement Planning Menu
            var retirementObjects = new AssureWebRetirementPlanningPageObjects();
            retirementObjects.RetirementPlanningClick(driver);

            //Select Quick Quote
            retirementObjects.AnnuityQuickClick(driver);

            //Verify page and close
            //Switch to iFrame
            string frameIdentifier = "tpi-iframe";
            var commonAss = new CommonAssureWebPageObjects();
            commonAss.PageFocusIFrame(driver, frameIdentifier);

            //DefaultWait for iFrame Content
            string pageValidator = "ctl00_MainBody_QuickQuoteClientDetails_Annuitant_Basic_ClientTypeHeader";
            var commonSol = new CommonSolutionBuilderPageObjects();
            commonSol.GenericWait(driver, pageValidator);

            //Validate
            Assert.IsTrue(driver.FindElement(By.Id(pageValidator)).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST 3.2
        //
        [Test, Parallelizable, Description("Select Annuity Detailed Quote Option")]
        public void RetirementDetailedQuote(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Open Retirement Planning Menu
            var retirementObjects = new AssureWebRetirementPlanningPageObjects();
            retirementObjects.RetirementPlanningClick(driver);

            //Select Detailed Quote
            retirementObjects.AnnuityDetailedClick(driver);

            //Verify page and close
            //Switch to iFrame
            string frameIdentifier = "tpi-iframe";
            var commonAss = new CommonAssureWebPageObjects();
            commonAss.PageFocusIFrame(driver, frameIdentifier);

            //DefaultWait for iFrame Content
            string pageValidator = "ctl00_MainBody_ClientDetails_AnnuitantClient_Basic_ClientTypeHeader";
            var commonSol = new CommonSolutionBuilderPageObjects();
            commonSol.GenericWait(driver, pageValidator);

            //Validate
            Assert.IsTrue(driver.FindElement(By.Id(pageValidator)).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST 3.3
        //
        [Test, Parallelizable, Description("Select REAP Pensions Option")]
        public void RetirementPensions(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Open Retirement Planning Menu
            var retirementObjects = new AssureWebRetirementPlanningPageObjects();
            retirementObjects.RetirementPlanningClick(driver);

            //Selec Pensions
            retirementObjects.PensionsClick(driver);

            //Verify page and close
            //Switch to iFrame
            string frameIdentifier = "tpi-iframe";
            var commonAss = new CommonAssureWebPageObjects();
            commonAss.PageFocusIFrame(driver, frameIdentifier);

            //DefaultWait for iFrame Content
            string pageValidator = "pensionTabControl_tabLiteralContainer";
            var commonSol = new CommonSolutionBuilderPageObjects();
            commonSol.GenericWait(driver, pageValidator);

            //Validate
            Assert.IsTrue(driver.FindElement(By.Id(pageValidator)).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST 3.4
        //
        [Test, Parallelizable, Description("Select iGO eApp Option")]
        public void RetirementIgoApp(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Open Retirement Planning Menu
            var retirementObjects = new AssureWebRetirementPlanningPageObjects();
            retirementObjects.RetirementPlanningClick(driver);

            //Select iGO
            retirementObjects.IGOClick(driver);
            
            //Follow to new PAGE
            var commonAss = new CommonAssureWebPageObjects();
            commonAss.PageFocusNewTab(driver);

            //Wait
            string pageValidator = "lblCaseListHeader";
            var commonSol = new CommonSolutionBuilderPageObjects();
            commonSol.GenericWait(driver, pageValidator);

            //Verify XRAE Page has loaded:
            Assert.IsTrue(driver.FindElement(By.Id(pageValidator)).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST 3.5
        //
        [Test, Parallelizable, Description("Select Provider Literature")]
        public void RetirementProviderLiterature(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Open Retirement Planning Menu
            var retirementObjects = new AssureWebRetirementPlanningPageObjects();
            retirementObjects.RetirementPlanningClick(driver);

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

        ////TEST 3.6
        //
        [Test, Parallelizable, Description("Select Provider Profiles")]
        public void RetirementProviderProfiles(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Open Retirement Planning Menu
            var retirementObjects = new AssureWebRetirementPlanningPageObjects();
            retirementObjects.RetirementPlanningClick(driver);

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
