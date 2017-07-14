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

    public class ForgottenDetailsPage : TestBase
    {

    #region Tests

        //TEST ONE




        ////TEST TWO
        //Checks for common page elements - HEADER
        [Test, Parallelizable, Description("Header Check")]
        public void VerifyCommonHeader(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            LoginPageObjects login = new LoginPageObjects();
            login.GetLoginPage(driver);
            login.ForgottenDetailsLink(driver);

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
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            LoginPageObjects login = new LoginPageObjects();
            login.GetLoginPage(driver);
            login.ForgottenDetailsLink(driver);

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



        ////TEST FOUR
        //Checks link and navigation to the Forgotten Details page
        [Test, Parallelizable, Description("Forgotten Your Details")]
        public void PasswordRecovery(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            LoginPageObjects login = new LoginPageObjects();
            login.GetLoginPage(driver);
            login.ForgottenDetailsLink(driver);

            //Where are we now?
            Assert.IsTrue(driver.Title.Contains("Forgotten Details"));

            //Find email field and enter VALID details
            ForgottenDetailsPageObjects forgottenDetails = new ForgottenDetailsPageObjects();
            forgottenDetails.ValidEmailAndSubmit(driver);

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST FIVE
        //Checks that validation throws correctly - Pt.1
        [Test, Parallelizable, Description("Input Invalid Address")]
        public void InvalidEMailAddress(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            LoginPageObjects login = new LoginPageObjects();
            login.GetLoginPage(driver);
            login.ForgottenDetailsLink(driver);

            //Submit some giberish
            ForgottenDetailsPageObjects forgottenDetails = new ForgottenDetailsPageObjects();
            forgottenDetails.InvalidEmail(driver);

            //Check for validation warning
            var emailIsInvlaid = driver.FindElement(By.XPath(".//*[@id='requestVerificationEmailForm']/div[2]/div[2]"));
            emailIsInvlaid.ToString();
            Assert.IsNotNull(emailIsInvlaid);

            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST SIX
        //Checks that validation throws correctly - Pt.2
        [Test, Parallelizable, Description("Input Incorect Address")]
        public void IncorectEmailAddress(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            LoginPageObjects login = new LoginPageObjects();
            login.GetLoginPage(driver);
            login.ForgottenDetailsLink(driver);

            //Submit an unrecognised email address
            ForgottenDetailsPageObjects forgottenDetails = new ForgottenDetailsPageObjects();
            forgottenDetails.EmailNotRecognisd(driver);

            //Check for validation warning
            var emailIsInvlaid = driver.FindElement(By.XPath(".//*[@id='requestVerificationEmailForm']/div[3]/div"));
            emailIsInvlaid.ToString();
            Assert.IsNotNull(emailIsInvlaid);

            //Call Cleanup
            CleanUp(driver);
        }



        #endregion
    }
}
