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

    public class InformationPage : TestBase
    {

    #region Tests


        ////TEST ONE
        //Checks for common page elements - HEADER
        [Test, Parallelizable, Description("Header Check")]
        public void VerifyCommonHeader(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            var login = new LoginPage();
            login.LoginDefaultUser(driver);

            //FInd out more!
            MyServicesPageObjects services = new MyServicesPageObjects();
            services.SolutionBuilderFindOut(driver);

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
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            var login = new LoginPage();
            login.LoginDefaultUser(driver);

            //FInd out more!
            MyServicesPageObjects services = new MyServicesPageObjects();
            services.SolutionBuilderFindOut(driver);

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
        [Test, Parallelizable, Description("Check Fields for Validation")]
        public void CheckAccordian(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            var login = new LoginPage();
            login.LoginDefaultUser(driver);

            //FInd out more!
            MyServicesPageObjects services = new MyServicesPageObjects();
            services.SolutionBuilderFindOut(driver);

            //Validate Accordian:
            var solutionSectionOpen = driver.FindElement(By.XPath(".//*[@id='solution-text']/p[1]/a")).Displayed;
            string openS = solutionSectionOpen.ToString();
            Assert.AreEqual(openS, "True");

            //Close + Check
            InformationPageObjects information = new InformationPageObjects();
            information.SelectSolutionBuilder(driver);
            var solutionSectionClosed = driver.FindElement(By.XPath(".//*[@id='solution-text']/p[1]/a")).Displayed;
            string closedS = solutionSectionClosed.ToString();
            Assert.AreEqual(closedS, "False");

            //Open Assurewb + Check
            information.SelectAssureweb(driver);
            var assurewebSectionOpen = driver.FindElement(By.XPath(".//*[@id='assureweb-text']/h3[1]")).Displayed;
            string openA = assurewebSectionOpen.ToString();
            Assert.AreEqual(openA, "True");

            //Close + Check
            information.SelectAssureweb(driver);
            var assurewebSectionClosed = driver.FindElement(By.XPath(".//*[@id='assureweb-text']/h3[1]")).Displayed;
            string closedA = assurewebSectionClosed.ToString();
            Assert.AreEqual(closedA, "False");

            //Open XRAE +Check.
            information.SelectXRAE(driver);
            var xraeSectionOpen = driver.FindElement(By.XPath(".//*[@id='xrae-text']/p[1]/a")).Displayed;
            string openX = xraeSectionOpen.ToString();
            Assert.AreEqual(openX, "True");

            //Close + Check
            information.SelectXRAE(driver);
            var xraeSectionClosed = driver.FindElement(By.XPath(".//*[@id='xrae-text']/p[1]/a")).Displayed;
            string closedX = xraeSectionClosed.ToString();
            Assert.AreEqual(closedX, "False");

            //Open Retirement + Check.
            information.SelectRetirementBuilder(driver);
            var retirementSectionOpen = driver.FindElement(By.XPath(".//*[@id='retirement-text']/h3[1]")).Displayed;
            string openR = retirementSectionOpen.ToString();
            Assert.AreEqual(openR, "True");

            //Close + Check.
            information.SelectRetirementBuilder(driver);
            var retirementSectionClosed = driver.FindElement(By.XPath(".//*[@id='retirement-text']/h3[1]")).Displayed;
            string closedR = retirementSectionClosed.ToString();
            Assert.AreEqual(closedR, "False");

            //Sign Out to services
            information.ExitToServices(driver);

            //Where are we now?
            Assert.IsTrue(driver.Title.Contains("iPipeline - My iPipeline Services"));

            //Call Cleanup
            CleanUp(driver);
        }



        ////TEST FOUR
        //Just sign out
        [Test, Parallelizable, Description("Sign Out")]
        public void SignOutTest(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //Call Setup
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            // Use login methods to call page, validate and attempt login
            var login = new LoginPage();
            login.LoginDefaultUser(driver);

            //FInd out more!
            MyServicesPageObjects services = new MyServicesPageObjects();
            services.SolutionBuilderFindOut(driver);

            //Call Footer checks
            InformationPageObjects information = new InformationPageObjects();
            information.AndExit(driver);

            //Are we in the right place
            Assert.IsTrue(driver.Title.Contains("iPipeline Login"));

            //Call Cleanup
            CleanUp(driver);
        }



        #endregion
    }
}
