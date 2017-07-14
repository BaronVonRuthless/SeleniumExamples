using Gallio.Framework;
using Gallio.Model;
using MbUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Net;
using Common;
using RegManagerPageObjects;

namespace RegManagerTESTS
{
    //
    //
    //

    public class DLPInformationPage : TestBase
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

            //Use login methods to call page, validate and attempt login
            var login = new LoginPage();
            login.LoginDefaultUser(driver);

            //Find Out More!
            MyServicesPageObjects services = new MyServicesPageObjects();
            services.LifeQuoteFindOut(driver);

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

            //Use login methods to call page, validate and attempt login
            var login = new LoginPage();
            login.LoginDefaultUser(driver);

            //Find Out More!
            MyServicesPageObjects services = new MyServicesPageObjects();
            services.LifeQuoteFindOut(driver);

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
        //Login and then Find Out More
        [Test, Parallelizable, Description("Navigate to Information Page")]
        public void GetToDLPInformationPage(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use login methods to call page, validate and attempt login
            var login = new LoginPage();
            login.LoginDefaultUser(driver);

            //Find Out More!
            MyServicesPageObjects services = new MyServicesPageObjects();
            DLPInformationPageObjects dlpInformation = new DLPInformationPageObjects();
            services.LifeQuoteFindOut(driver);
            
            //In the right place?
            Assert.IsTrue(driver.Url.Equals("https://" + Constants.ENV + ".ipipeline.uk.com/ui#/lifeQuote?findoutmore"));
            
            //Back to Login
            dlpInformation.AndExit(driver);
            Assert.IsTrue(driver.Title.Equals("iPipeline Login"));

            //Call Cleanup
            CleanUp(driver);
        }



        #endregion
    }
}
