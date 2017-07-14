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
    class AssureWebAnnouncements : TestBase
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
        
        

        #region Page Entry & Validation Tests

        ////TEST 1.1
        //Log in to Reg Manager and click through to AssureWeb Announcements page
        [Test, Parallelizable, Description("Basic Access Test")]
        public void AnnouncementsGetToPage(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Exception Check + Validate for count
            var commonSupport = new CommonSupportObjects();
            string expectedPage = "iPipeline - Assureweb";
            commonSupport.ConfirmPageTitle(driver, expectedPage);
            Assert.IsTrue(driver.Title.Equals(expectedPage));

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST 1.2
        //Log in to Reg Manager, through to AssureWeb then Logout
        [Test, Parallelizable, Description("Logout from Announcements page")]
        public void AnnouncementsLogoutButton(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Logout
            var announceObjects = new AssureWebAnnouncementsPageObjects();
            announceObjects.Logout(driver);

            //Wait
            var common = new CommonSolutionBuilderPageObjects();
            string pagevalidator = "signin-btn";
            common.GenericWait(driver, pagevalidator);

            //Verify page and close
            Assert.IsTrue(driver.Title.Equals("iPipeline Login"));

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST 1.3
        //Log in to Reg Manager, through to AssureWeb and exit to MyServices
        [Test, Parallelizable, Description("Exit to MyServices")]
        public void AnnouncementsMyServicesLink(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //Exit to MyServices
            var announceObjects = new AssureWebAnnouncementsPageObjects();
            announceObjects.MyServices(driver);

            //Wait
            var common = new CommonSolutionBuilderPageObjects();
            string pagevalidator = "SolutionBuilderFindOutMoreButton";
            common.GenericWait(driver, pagevalidator);

            //Verify page and close
            Assert.IsTrue(driver.Title.Equals("iPipeline - My iPipeline Services"));

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST 1.4
        //Log in to Reg Manager, through to AssureWeb and exit to MyServices via Header
        [Test, Parallelizable, Description("Exit to MyServices Via Header")]
        public void AnnouncementsHeaderImageLink(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Announcements
            var support = new AssureWebAnnouncements();
            support.RouteToAnnouncements(driver);

            //return to Announcements Page
            var announceObjects = new AssureWebAnnouncementsPageObjects();
            announceObjects.HeaderClick(driver);

            //Verify page and close
            string expectedPage = "iPipeline - Assureweb";
            Assert.IsTrue(driver.Title.Equals(expectedPage));

            //Call Cleanup
            CleanUp(driver);
        }
        #endregion

    }
}
