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

namespace RegManagerTESTS
{
    //
    //
    //

    public class MyServicesPage : TestBase
    {

    #region Tests

        ////TEST ONE
        //Login and validate page content
        [Test, Parallelizable, Description("Page Validation")]
        public void GetToServices(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            
            //Use login methods to call page, validate and attempt login
            var login = new LoginPage();
            login.LoginDefaultUser(driver);

            //Validate 
            MyServicesPageObjects services = new MyServicesPageObjects();
            services.ConfirmPageTitle(driver);

            //Logout
            services.LogOut(driver);

            //Verify page and close
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
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            
            // Use login methods to call page, validate and attempt login
            var login = new LoginPage();
            login.LoginDefaultUser(driver);

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
            var login = new LoginPage();
            login.LoginDefaultUser(driver);

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
        public void GetToInformationPages(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            //Use login methods to call page, validate and attempt login
            var login = new LoginPage();
            login.LoginDefaultUser(driver);

            //Find Out More! Pages:
            MyServicesPageObjects services = new MyServicesPageObjects();
            InformationPageObjects information = new InformationPageObjects();
            DLPInformationPageObjects dlpInformation = new DLPInformationPageObjects();
            
            //Solution Builder
            services.SolutionBuilderFindOut(driver);
            Assert.IsTrue(driver.Title.Equals("iPipeline - Services Information"));
            information.ExitToServices(driver);

            //Assureweb
            services.AssurewebFindOut(driver);
            Assert.IsTrue(driver.Title.Equals("iPipeline - Services Information"));
            information.ExitToServices(driver);

            //XRAE
            services.XRAEFindOut(driver);
            Assert.IsTrue(driver.Title.Equals("iPipeline - Services Information"));
            information.ExitToServices(driver);

            //Retirement Builder
            services.RetirementBuilderFindOut(driver);
            Assert.IsTrue(driver.Title.Equals("iPipeline - Services Information"));
            information.ExitToServices(driver);

            //DLP
            services.LifeQuoteFindOut(driver);
            Assert.IsTrue(driver.Url.Equals("https://" + Constants.ENV + ".ipipeline.uk.com/ui#/lifeQuote?findoutmore"));
            dlpInformation.ExitToServices(driver);
            
            //Back to Services?
            Assert.IsTrue(driver.Title.Equals("iPipeline - My iPipeline Services"));

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST FIVE
        //Opens Account Details and verifys landing page.
        [Test, Parallelizable, Description("My Account")]
        public void MyAccountLink(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            var login = new LoginPage();
            login.LoginDefaultUser(driver);

            //Check Account Details Link:
            MyServicesPageObjects services = new MyServicesPageObjects();
            string originalWindow = services.MyAccount(driver);

            //Check My Details page has loaded:
            Assert.IsTrue(driver.Title.Equals("iPipeline - My Details"));

            //Call close window:
            new CommonSolutionBuilderPageObjects().NewWindowClose(driver, originalWindow);

            //Call Cleanup
            CleanUp(driver);
        }



        #endregion
    }
}
