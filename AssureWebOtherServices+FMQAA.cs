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
    class AssureWebOtherServices_FMQAA : TestBase
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

        #region Other Services Tests

        ////TEST 6.1
        //
        [Test, Parallelizable, Description("Select Document Library Option")]
        public void OtherDocumentLibrary(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Open Other Services Menu
            var otherObjects = new AssureWebOtherServicesPageObjects();
            otherObjects.OtherServicesClick(driver);

            //Select Document Library
            otherObjects.DocumentLibraryClick(driver);

            //DefaultWait for iFrame Content
            string pageValidator = "AnnuityServiceUserGuide";
            var commonSol = new CommonSolutionBuilderPageObjects();
            commonSol.GenericWait(driver, pageValidator);

            //Validate
            Assert.IsTrue(driver.FindElement(By.Id(pageValidator)).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        #endregion

        #region Find My Quote & Apply Tests

        ////TEST 7.1
        //
        [Test, Parallelizable, Description("Select Find My Quote & Apply Option")]
        public void FindMyQuoteApply(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Open FMQAA
            var otherObjects = new AssureWebOtherServicesPageObjects();
            otherObjects.FindMyQuoteApplyClick(driver);

            //Switch to iFrame
            string frameIdentifier = "tpi-iframe";
            var commonAss = new CommonAssureWebPageObjects();
            commonAss.PageFocusIFrame(driver, frameIdentifier);

            //DefaultWait for iFrame Content
            string pageValidator = "searchResultsUpdatePanel";
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
