using Gallio.Framework;
using Gallio.Model;
using MbUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using Common;
using RegManagerPageObjects;
using RegManagerTESTS;
using SolutionBuilderClientDetailsPageObjects;

namespace SolutionBuilderClientDetailsTESTS
{
    //
    //
    //

    public class DashboardPage : TestBase
    {
        #region Support Methods

        //A bundle to quickly get you to the Dashboard
        public void RouteToDashboard(IWebDriver driver)
        {
            // Use login methods to call page, validate and attempt login
            var login = new LoginPage();
            login.LoginDefaultUser(driver);

            //Login to Solutiuon Builder
            var myServices = new MyServicesPageObjects();
            myServices.LaunchSolutionBuilder(driver);
        }

        #endregion

        #region Tests



        ////TEST ONE
        //Help Overlay
        [Test, Parallelizable, Description("Link to Help Overlay")]
        public void HelpLinkDashboard(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Dashboard - validate
            var route = new DashboardPage();
            route.RouteToDashboard(driver);

            //Click help icon
            var common = new CommonSolutionBuilderPageObjects();
            common.HelpOverlayOpenDashboard(driver);
            string pageValidator = "clientSearchInput";
            common.HelpOverlayCloseGeneric(driver, pageValidator);
            Assert.IsTrue(driver.Title.Equals("Solution Builder"));

            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST TWO
        //CHeck links out - add new client
        [Test, Parallelizable, Description("Link out to Add New Client")]
        public void AddClientDashboard(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Dashboard - validate
            var route = new DashboardPage();
            route.RouteToDashboard(driver);

            //CLick through to New Client
            var dashboard = new DashboardPageObjects();
            dashboard.AddNewClient(driver);
            Assert.IsTrue(driver.FindElement(By.Id("firstlifegenderfemale")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST THREE
        //New Quote for existing client
        [Test, Parallelizable, Description("New Quote Existing Client")]
        public void NewQuoteButton(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Dashboard - validate
            var route = new DashboardPage();
            route.RouteToDashboard(driver);

            //Click through
            var dashboard = new DashboardPageObjects();
            dashboard.NewQuote(driver);

            Assert.IsTrue(driver.FindElement(By.Id("commission-button")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST FOUR
        //Back to My Services using header button
        [Test, Parallelizable, Description("Link Back to Services")]
        public void MyServicesLinkDashboard(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Dashboard - validate
            var route = new DashboardPage();
            route.RouteToDashboard(driver);

            //Select My "iPipeline"
            var common = new CommonSolutionBuilderPageObjects();
            common.MyServicesButton(driver);

            Assert.IsTrue(driver.Title.Equals("iPipeline - My iPipeline Services"));

            ////Call Cleanup
            CleanUp(driver);
        }



        ////TEST FIVE
        //Logout
        [Test, Parallelizable, Description("Header Logout Button")]
        public void LogoutButtonDashboard(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            
            //Call Shortcut to Dashboard - validate
            var route = new DashboardPage();
            route.RouteToDashboard(driver);

            //Select "Logout"
            var common = new CommonSolutionBuilderPageObjects();
            common.LogoutButton(driver);
            common.DialogueYes(driver);
            string pageValidator = "username";
            common.GenericWait(driver, pageValidator);
            
            //Confirm login page reached
            Assert.IsTrue(driver.Title.Equals("iPipeline Login"));

            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST SIX
        //Client History, primary LINK
        [Test, Parallelizable, Description("Nav to Client History Screen")]
        public void ClientHistoryFullDashboard(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Dashboard - validate
            var route = new DashboardPage();
            route.RouteToDashboard(driver); ;

            //var currentClient = driver.FindElement(By.XPath(".//*[@id='clientAndSearch']/div/div[2]/visible/div/ul/li[1]"));
            //string currentClient = driver.FindElement(By.XPath(".//*[@id='clientAndSearch']/div/div[2]/hidden/div/ul/li[1]")).Text.Trim();
            string firstClient = driver.FindElement(By.Id("clientSearchFirstLifeName_0")).Text.Trim();
            string secondClient = driver.FindElement(By.Id("clientSearchSecondLifeName_0")).Text.Trim();
            string currentClient = firstClient + " " + secondClient;

            //Click Client History validate page loads
            var dashboard = new DashboardPageObjects();
            dashboard.ClientHistoryFull(driver);

            //Read page title and check correct client
            string clientHeader = driver.FindElement(By.XPath(".//*[@id='navigation-bar']/div/hidden/div/div/div[2]/div[2]/hidden/div/span")).Text.Trim();
            Assert.AreEqual(currentClient, clientHeader);

            //Call Cleanup
            CleanUp(driver);
        }


        //////TEST SEVEN
        ////Client History, Flagged Link
        //[Test, Parallelizable, Description("Nav to Client History Screen")]
        //public void ClientHistoryFlaggedDashboard(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        //{
        //    // Call Setup
        //    var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

        //    //Call Shortcut to Dashboard - validate
        //    var support = new DashboardPage();
        //    support.RouteToDashboard(driver);

        //    //Click Client History validate page loads
        //    var dashboard = new DashboardPageObjects();
        //    dashboard.ClientHistoryFlagged(driver);


        //    //****ASSERT VALUE REQUIRED****


        //    //Call Cleanup
        //    CleanUp(driver);
        //}

        //////TEST EIGHT
        ////Client History - expireed/about to expire link
        //[Test, Parallelizable, Description("Nav to Client History Screen")]
        //public void ClientHistoryExpireDashboard(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        //{
        //    // Call Setup
        //    var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

        //    //Call Shortcut to Dashboard - validate
        //    var support = new DashboardPage();
        //    support.RouteToDashboard(driver);

        //    //Click Client History validate page loads
        //    var dashboard = new DashboardPageObjects();
        //    dashboard.ClientHistoryExpire(driver);


        //    //****ASSERT VALUE REQUIRED****


        //    //Call Cleanup
        //    CleanUp(driver);
        //}



        ////TEST NINE
        //Client Search results display
        [Test, Parallelizable, Description("Check Search Field input")]
        public void ClientSearchDashboard(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            var dashboard = new DashboardPageObjects();
            var route = new DashboardPage();
            var support = new CommonSupportObjects();

            //Call Shortcut to Dashboard - validate
            route.RouteToDashboard(driver);

            //Check that title is displayed correctly:
            string titleBeforeSearch = dashboard.ClientSearchTitle(driver);
            Assert.AreEqual(titleBeforeSearch, "Most recent");

            //Begin typing search value
            string searchValue = "tes";
            dashboard.ClientSearchInput(driver, searchValue);

            //Check that title has updated:
            string titleAfterSearch = dashboard.ClientSearchTitle(driver);
            Assert.AreEqual(titleAfterSearch, "Search results");

            //Check results contain at least one result:
            string standardReadElement = "clientSearchFirstLifeName_0";
            string alternativeReadElement = "clientSearchNoClientsFound";
            string returnValue = support.ElementIsPresentRead(driver, standardReadElement, alternativeReadElement);
            if (returnValue != "No clients found")
            {
                //Confirm search term is present:
                Assert.Contains(returnValue.ToLower(), searchValue.ToLower());

            }
            else { }

            //Call Cleanup
            CleanUp(driver);
        }


        #endregion
    }
}
