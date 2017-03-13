using Gallio.Framework;
using Gallio.Model;
using MbUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using Common;
using RegManagerPageObjects;
using SolutionBuilderClientDetailsPageObjects;

namespace SolutionBuilderClientDetailsTESTS
{
    //
    //
    //

    public class MatrixScreen : TestBase
    {
        #region Support Methods

        #endregion

        #region Tests

        ////TEST ONE
        //Help Overlay
        [Test, Parallelizable, Description("Link to Help Overlay")]
        public void MatrixScreenFromLTA(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup + Get to Benefits
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            new BenefitSelectionPage().RouteToBenefits(driver);
            var benefits = new BenefitSelectionPageObjects();
            var common = new CommonSolutionBuilderPageObjects();
            string benefitId = "bp";

            //Add WOL + Input basic details and Save out to Benefit Selection screen
            var support = new CommonSupportObjects();
            support.AddBasicBusinessProtectionBenefit(driver);

            //Check matrix is accesible
            benefits.EnterMatrixFromSummary(driver, benefitId);










            //Call Cleanup
            CleanUp(driver);



            ////FIB CAN RETURN INDICATIVE! JUST QUOTE AS LIFE+CIC
        }

        #endregion
    }
}
