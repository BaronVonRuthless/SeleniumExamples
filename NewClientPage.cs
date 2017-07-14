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

    public class NewClientPage : TestBase
    {
        #region Support Methods

        #endregion

        #region Tests

        //TEST ONE
        // Login to RegManager, navigate to Dashboard



        ////TEST TWO
        //
        [Test, Parallelizable, Description("Add New Client")]
        public void AddNewClient(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Call Shortcut to Add Client - validate 
            var support = new DashboardPage();
            var dashboard = new DashboardPageObjects();
            support.RouteToDashboard(driver);
            dashboard.AddNewClient(driver);
            Assert.IsTrue(driver.FindElement(By.Id("firstlifegenderfemale")).Displayed);

            //Use page object to fill form IMPORTED
            NewClientPageObjects client = new NewClientPageObjects();
            client.NewClientFormFill(driver);
            client.SaveClient(driver);
            Assert.IsTrue(driver.FindElement(By.Id("commission-button")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST FIVE
        //Logout
        [Test, Parallelizable, Description("Header Logout Button")]
        public void LogoutButtonClient(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            var login = new LoginPage();
            login.LoginDefaultUser(driver);

            // Have we made it to My iPipeline Services?
            Assert.IsTrue(driver.Title.Contains("iPipeline - My iPipeline Services"));

            //Log out, using Sign Out button
            var myServices = new MyServicesPageObjects();
            myServices.LaunchSolutionBuilder(driver);

            //Have we made it back to the Login Page?
            Assert.IsTrue(driver.Title.Equals("Solution Builder"));

            //Select "Logout"
            var common = new CommonSolutionBuilderPageObjects();
            common.LogoutButton(driver);

            Assert.IsTrue(driver.Title.Equals("iPipeline Login"));

            //Call Cleanup
            CleanUp(driver);
        }


        #endregion
    }
}
