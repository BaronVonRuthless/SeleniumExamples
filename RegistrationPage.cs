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

    public class RegistrationPage : TestBase
    {

    #region Tests


        ////TEST ONE
        //Checks for common page elements - HEADER
        [Test, Parallelizable, Description("Header Check")]
        public void VerifyCommonHeader(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            LoginPageObjects login = new LoginPageObjects();
            RegistrationPageObjects registration = new RegistrationPageObjects();
            login.GetLoginPage(driver);
            login.RegisterNowLink(driver);
            registration.ConfirmPageTitle(driver);

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


        ////TEST TWO
        //Checks for common page elements - FOOTER
        [Test, Parallelizable, Description("Footer Check")]
        public void VerifyCommonFooter(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            LoginPageObjects login = new LoginPageObjects();
            RegistrationPageObjects registration = new RegistrationPageObjects();
            login.GetLoginPage(driver);
            login.RegisterNowLink(driver);
            registration.ConfirmPageTitle(driver);

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


        ////TEST THREE
        //Field validation, form validation.
        [Test, Parallelizable, Description("Check Fields on First Page for Validation")]
        public void FormValidationPageOne(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            LoginPageObjects login = new LoginPageObjects();
            RegistrationPageObjects registration = new RegistrationPageObjects();
            login.GetLoginPage(driver);
            login.RegisterNowLink(driver);
            registration.ConfirmPageTitle(driver);

            //Where are we now?
            Assert.IsTrue(driver.Title.Contains("iPipeline - Register Now"));

            //No name details:
            registration.ValidPostcode(driver);
            registration.ValidFcaNumber(driver);
            registration.NextButtonClick(driver);
            Assert.IsTrue(driver.FindElement(By.XPath(".//*[@id='userDetailsForm']/div[3]/div[2]/span[1]")).Displayed);

            //Duff postcode:
            registration.BasicFormFillPageOne(driver);
            registration.InvalidPostcode(driver);
            registration.ValidFcaNumber(driver);
            registration.NextButtonClick(driver);
            Assert.IsTrue(driver.FindElement(By.XPath(".//*[@id='userDetailsForm']/div[7]/div[2]/span[2]")).Displayed);

            //DUff FCA Number
            registration.BasicFormFillPageOne(driver);
            registration.ValidPostcode(driver);
            registration.InvalidFcaNumber(driver);
            registration.NextButtonClick(driver);
            Assert.IsTrue(driver.FindElement(By.XPath(".//*[@id='userDetailsForm']/div[10]/div/span")).Displayed);

            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST FOUR
        //Field validation, form validation.
        [Test, Parallelizable, Description("Check Fields on Second Page for Validation")]
        public void FormValidationPageTwo(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            LoginPageObjects login = new LoginPageObjects();
            RegistrationPageObjects registration = new RegistrationPageObjects();
            login.GetLoginPage(driver);
            login.RegisterNowLink(driver);
            registration.ConfirmPageTitle(driver);

            //Where are we now?
            Assert.IsTrue(driver.Title.Contains("iPipeline - Register Now"));

            //Enter details to form and click through to second page:
            registration.BasicFormFillPageOne(driver);
            registration.ValidPostcode(driver);
            registration.ValidFcaNumber(driver);
            registration.NextButtonClick(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement signInButton = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id("fcaName"));
            });
            Assert.IsTrue(driver.FindElement(By.Id("fcaName")).Displayed);

            //Validate form
            registration.RegisterNowButtonClick(driver);
            Assert.IsTrue(driver.FindElement(By.XPath(".//*[@id='firmAndAddressForm']/div[7]/div[2]/span[1]")).Displayed);

            //Form fill on page two:
            registration.BasicFormFillPageTwo(driver);
            registration.RegisterNowButtonClick(driver);
            Assert.IsTrue(driver.FindElement(By.XPath(".//*[@id='firmAndAddressForm']/div[5]/div[2]/span")).Displayed);

            //Drop-downs on page two:
            registration.AdvancedFormFillPageTwo(driver);
            registration.RegisterNowButtonClick(driver);
            Assert.IsTrue(driver.FindElement(By.XPath(".//*[@id='firmAndAddressForm']/div[31]/div[3]/span")).Displayed);

            //****THESE OPTIONS ARE NOT REVERSIBLE AND CANNOT BE USED IN LIVE REGRESSION*****
            ////Drop-downs on page two:
            //registration.AgreeTermsButton(driver);
            //registration.RegisterNowButtonClick(driver);
            //IWebElement pageTransistion = wait.Until<IWebElement>((d) =>
            //{
            //    return d.FindElement(By.Id("login"));
            //});
            //Assert.IsTrue(driver.FindElement(By.XPath(".//*[@id='confirmationForm']/div[1]/div/h3")).Displayed);

            ////Communication Options and back to LOGIN
            //registration.CommunicationButtons(driver);
            //registration.GoToLogin(driver);
            //WebDriverWait waitTransfer = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //IWebElement loginScreen = waitTransfer.Until<IWebElement>((d) =>
            //{
            //    return d.FindElement(By.Id("UserName"));
            //});
            //Assert.IsTrue(driver.Title.Contains("iPipeline Login"));

            //Call Cleanup
            CleanUp(driver);
        }


        ////TEST FIVE
        //Check links to T&C's on second page
        [Test, Parallelizable, Description("CHeck Terms and Conditions Link")]
        public void DocumentLinksPageTwo(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            LoginPageObjects login = new LoginPageObjects();
            RegistrationPageObjects registration = new RegistrationPageObjects();
            login.GetLoginPage(driver);
            login.RegisterNowLink(driver);
            registration.ConfirmPageTitle(driver);

            //Where are we now?
            Assert.IsTrue(driver.Title.Contains("iPipeline - Register Now"));

            //Enter details to form and click through to second page:
            registration.BasicFormFillPageOne(driver);
            registration.ValidPostcode(driver);
            registration.ValidFcaNumber(driver);
            registration.NextButtonClick(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement signInButton = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id("fcaName"));
            });
            Assert.IsTrue(driver.FindElement(By.Id("fcaName")).Displayed);

            //Document Checks: T&C's
            {
                string originalWindow = registration.TermsConditionsLink(driver);
                Assert.IsTrue(driver.Url.Equals("https://" + Constants.ENV + ".assureweb.co.uk/terms-and-conditions.aspx"));
                new CommonSolutionBuilderPageObjects().NewWindowClose(driver, originalWindow);
            }

            //Privacy Policy
            {
                string originalWindow = registration.PrivacyPolicyLink(driver);
                Assert.IsTrue(driver.Url.Equals("https://" + Constants.ENV + ".assureweb.co.uk/privacy-policy.aspx"));
                new CommonSolutionBuilderPageObjects().NewWindowClose(driver, originalWindow);
            }

            //Call Cleanup
            CleanUp(driver);
        }

        #endregion
    }
}