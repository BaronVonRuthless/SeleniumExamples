using Gallio.Framework;
using Gallio.Model;
using MbUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using Common;
using RegManagerPageObjects;

namespace RegManagerTESTS
{
    //
    //
    //
        
    public class LoginPage : TestBase
    {

        #region Support Methods

        //Get to and confirm the Login Page - Add valida user and submit to iPipeline Services
        public void LoginDefaultUser(IWebDriver driver)
        {
            // Use login methods to call pag and validate
            var login = new LoginPageObjects();
            login.GetLoginPage(driver);

            //Add valid Username & Password:
            if (Constants.SAUCE_LABS_SPECIFIED_TUNNEL == "tunnel-v4.4.4-SaDe")
            {
                string userName = new Users().RandomUsername();
                login.InputUsername(driver, userName);

                string Password = userName + "SadeX";
                login.InputPassword(driver, Password);
            }
            else
            {
                string userName = Constants.USERNAME;
                login.InputUsername(driver, userName);

                string Password = Constants.PASSWORD;
                login.InputPassword(driver, Password);
            }

            //Click Sign In
            login.ClickSignInButton(driver);

            //Wait condition
            driver.WaitForUpTo(30, "DO YOU WANT TO KNOW MORE?")
            .Until(ExpectedConditions.ElementExists(By.Id("SolutionBuilderFindOutMoreButton")));
        }


        #endregion

        #region Tests

        ////TEST ONE
        //Login to iPipeline from RegManager - Valid User
        [Test, Parallelizable, Description ("Login Valid User")]
        public void LoginValidUser(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login Default User support method to call page, validate and Login
            LoginDefaultUser(driver);

            // Have we made it to My iPipeline Services?
            Assert.IsTrue(driver.Title.Equals("iPipeline - My iPipeline Services"));

            //Log out, using Sign Out button
            var myServices = new MyServicesPageObjects();
            myServices.LogOut(driver);

            //Have we made it back to the Login Page?
            Assert.IsTrue(driver.Title.Equals("iPipeline Login"));

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST TWO
        //Checks for common page elements - HEADER
        [Test, Parallelizable, Description("Header Check")]
        public void VerifyCommonHeader(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            var login = new LoginPageObjects();
            login.GetLoginPage(driver);

            //Call Header checks
            CommonRegManagerPageObjects common = new CommonRegManagerPageObjects();

            //Header Image:
            string BannerCheckHeaderLogo = common.BannerCheckHeaderLogo(driver);
            Assert.IsNotNull(BannerCheckHeaderLogo);

            //Telephone Number:
            string BannerCheckTelephone = common.BannerCheckTelephone(driver);
            Assert.IsNotNull(BannerCheckTelephone);

            //EMail Address:
            string BannerCheckMailTo = common.BannerCheckMailTo(driver);
            Assert.IsNotNull(BannerCheckMailTo);

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST THREE
        //Checks for common page elements - FOOTER
        [Test, Parallelizable, Description("Footer Check")]
        public void VerifyCommonFooter(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            var login = new LoginPageObjects();
            login.GetLoginPage(driver);

            //Call Footer checks
            CommonRegManagerPageObjects common = new CommonRegManagerPageObjects();

            //Check COrporate Site:
            {
                string originalWindow = common.FooterCoporateSite(driver);
                Assert.IsTrue(driver.Title.Equals("Financial and Insurance Solutions Provider | iPipeline"));
                new CommonSolutionBuilderPageObjects().NewWindowClose(driver, originalWindow);
            }

            //Check Terms & Conditions:
            {
                string originalWindow = common.FooterTermsConditions(driver);
                //Assert.IsTrue(driver.Title.Equals("iPipeline - Terms and Conditions"));
                Assert.IsTrue(driver.Url.Equals("https://" + Constants.ENV + ".assureweb.co.uk/terms-and-conditions.aspx"));
                new CommonSolutionBuilderPageObjects().NewWindowClose(driver, originalWindow);
            }

            //Check XRAE Terms:
            {
                string originalWindow = common.FooterXraeTerms(driver);
                Assert.IsTrue(driver.Url.Contains("TermsAndConditions.pdf"));
                new CommonSolutionBuilderPageObjects().NewWindowClose(driver, originalWindow);
            }

            //Check  Privacy Policy:
            {
                string originalWindow = common.FooterPrivacyPolicy(driver);
                Assert.IsTrue(driver.Url.Equals("https://" + Constants.ENV + ".assureweb.co.uk/privacy-policy.aspx"));
                new CommonSolutionBuilderPageObjects().NewWindowClose(driver, originalWindow);
            }

            //Call Cleanup
            CleanUp(driver);
        }

        

        ////TEST FOUR .01
        //Checks validation on the USERNAME field
        [Test, Parallelizable, Description("Field Validation")]
        public void InvalidUsername(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            var login = new LoginPageObjects();
            login.GetLoginPage(driver);

            //Add INVALID Username
            string Username = "Testy McTesterson";
            login.InputUsername(driver, Username);

            //Add valid Password:
            if (Constants.SAUCE_LABS_SPECIFIED_TUNNEL == "tunnel-v4.4.4-SaDe")
            {
                string userNameRetrieval = new Users().RandomUsername();
                string Password = userNameRetrieval + "SadeX";
                login.InputPassword(driver, Password);
            }
            else
            {
                string Password = Constants.PASSWORD;
                login.InputPassword(driver, Password);
            }

            // Attempt login with duff user
            login.ClickSignInButton(driver);

            // Check that errortext is displayed
            var userValidationText = driver.FindElement(By.ClassName("errortext")).Displayed;
            userValidationText.ToString();
            Assert.IsNotNull(userValidationText);

            //Call Cleanup
            CleanUp(driver);
        }

        ////TEST FOUR .02
        //Checks validation on the PASSWORD field
        [Test, Parallelizable, Description("Field Validation")]
        public void InvalidPassword(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            var login = new LoginPageObjects();
            login.GetLoginPage(driver);

            //Add valid Username:
            if (Constants.SAUCE_LABS_SPECIFIED_TUNNEL == "tunnel-v4.4.4-SaDe")
            {
                string userName = new Users().RandomUsername();
                login.InputUsername(driver, userName);
            }
            else
            {
                string userName = Constants.USERNAME;
                login.InputUsername(driver, userName);
            }

            //Add INVALID Password
            string Password = "inV4l1dPassw0rd";
            login.InputPassword(driver, Password);

            // Attempt login with duff password
            login.ClickSignInButton(driver);

            // Check that errortext is displayed
            var passwordValidationText = driver.FindElement(By.ClassName("errortext")).Displayed;
            passwordValidationText.ToString();
            Assert.IsNotNull(passwordValidationText);

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST FIVE
        //Checks link and navigation to the Forgotten Details page
        [Test, Parallelizable, Description("Forgotten Your Details")]
        public void OpenForgottenDetailsPage(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            LoginPageObjects login = new LoginPageObjects();
            login.GetLoginPage(driver);

            //Locate "Forgotten your details link" and click
            login.ForgottenDetailsLink(driver);

            //Where are we now?
            Assert.IsTrue(driver.Title.Contains("iPipeline - Forgotten Details"));

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST SIX
        //Checks the text pop-in on "Having problems signing in?"
        [Test, Parallelizable, Description("Problems Signing In")]
        public void AdviceText(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            LoginPageObjects login = new LoginPageObjects();
            login.GetLoginPage(driver);

            // Locate "Having problems" and click
            login.OpenAdviceText(driver);

            //Can we see the text?
            string displayedYes = driver.FindElement(By.Id("login-advice")).Displayed.ToString();
            Assert.IsTrue(displayedYes.Equals("True"));

            //Close Advice Text
            login.CloseAdviceText(driver);

            //Is the text hiddden?
            string displayedNo = driver.FindElement(By.Id("login-advice")).Displayed.ToString();
            Assert.IsTrue(displayedNo.Equals("False"));

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST SEVEN
        //Check the link and navigate to the Registration page
        [Test, Parallelizable, Description("Register Now")]
        public void RegistrationLink(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            LoginPageObjects login = new LoginPageObjects();
            login.GetLoginPage(driver);

            // Locate "Register Now" and click
            login.RegisterNowLink(driver);

            //Are we in the right place
            Assert.IsTrue(driver.Title.Contains("iPipeline - Register Now"));

            //Call Cleanup
            CleanUp(driver);
        }
        
        #endregion
    }
}
