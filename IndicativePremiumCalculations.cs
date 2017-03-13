using Gallio.Framework;
using Gallio.Model;
using MbUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using Common;
using RegManagerPageObjects;
using SolutionBuilderClientDetailsTESTS;
using SolutionBuilderClientDetailsPageObjects;

namespace SolutionBuilderClientDetailsTESTS
{
    //
    //
    //

    public class IndicativePremiumCalculations : TestBase
    {
        #region Support Methods

        //A bundle to quickly get you to the New Client Page
        public void RouteToBenefits(IWebDriver driver)
        {
            // Use login methods to call page, validate and attempt login
            var support = new DashboardPage();
            support.RouteToDashboard(driver);

            //Click through to New Quote
            var Benefits = new DashboardPageObjects();
            Benefits.NewQuote(driver);

        }

        #endregion

        #region Tests

        ////INDICATIVE PREMIUM TOTAL MULTIPLE BENFITS - NOT FIB!
        [Test, Parallelizable, Description("Check Indicative Total of Combined Benefits")]
        public void IndicativeTotalMultipleBenefits(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            // Call Setup
            //var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);
            var driver = Setup(appiumVersion, browserName, version, platform, platformVersion, platformName, deviceName, deviceOrientation);

            var route = new IndicativePremiumCalculations();
            var benefit = new BenefitSelectionPageObjects();
            var level = new LevelTermPageObjects();
            var decreasing = new DecreasingTermPageObjects();
            var income = new IncomeProtectionPageObjects();
            var common = new CommonSolutionBuilderPageObjects();
            var indicativePremiumFirstBenefit = "";
            var indicativePremiumSecondBenefit = "";
            var indicativePremiumThirdBenefit = "";
            var indicativePremiumFourthBenefit = "";
            var indicativePremiumFifthBenefit = "";

            //Call Shortcut to Benefits
            route.RouteToBenefits(driver);

            //Select LTA + Enter basic details
            {
                string benefitId = "lta";
                benefit.AddNewBenefit(driver, benefitId);
                string termYears = Constants.ltaTERMYEARS;
                string levelTermValue = Constants.ltaTERMVALUE;
                level.LTAMinimalBenefitDetails(driver, termYears, levelTermValue);
            }

            //Record displayed Indicative Premium + Exit back to Benefit Summary STORE AS 1
            {
                string benefitId = "lta";
                indicativePremiumFirstBenefit = common.BenefitIndicativePremiumReader(driver, benefitId).Replace("£", "");
                common.BenefitSaveButton(driver, benefitId);
            }

            //Select DTA + Enter basic details
            {
                string benefitId = "dta";
                benefit.AddNewBenefit(driver, benefitId);
                string termYears = Constants.dtaTERMYEARS;
                string levelTermValue = Constants.dtaTERMVALUE;
                decreasing.DTAMinimalBenefitDetails(driver, termYears, levelTermValue);
            }

            //Record displayed Indicative Premium + Exit back to Benefit Summary STORE AS 2
            {
                string benefitId = "dta";
                indicativePremiumSecondBenefit = common.BenefitIndicativePremiumReader(driver, benefitId).Replace("£", "");
                common.BenefitSaveButton(driver, benefitId);
            }

            //Call total reader and convert total into INT
            var returnFirstTotal = benefit.TotalIndicativePremiumReader(driver);
            int firstTotalINT = Int32.Parse(returnFirstTotal.Replace("£", ""));

            //Convert benefit values into INTs
            int indicativePremiumFirstBenefitINT = Int32.Parse(indicativePremiumFirstBenefit.Replace("£", ""));
            int indicativePremiumSecondBenefitINT = Int32.Parse(indicativePremiumSecondBenefit.Replace("£", ""));

            //Match values
            Assert.AreEqual(firstTotalINT, (indicativePremiumFirstBenefitINT + indicativePremiumSecondBenefitINT));

            //Select LTA AGAIN + Enter differnt values (FIB Std)
            {
                string benefitId = "lta";
                new BenefitSelectionPageObjects().AddNewBenefit(driver, benefitId);
                string termYears = Constants.ltaTERMYEARS;
                string levelTermValue = Constants.ltaTERMVALUE;
                level.LTAMinimalBenefitDetails(driver, termYears, levelTermValue);
            }

            //Record displayed Indicative Premium + Exit back to Benefit Summary STORE AS 3
            {
                string benefitId = "lta";
                indicativePremiumThirdBenefit = common.BenefitIndicativePremiumReader(driver, benefitId).Replace("£", "");
                common.BenefitSaveButton(driver, benefitId);
            }

            //Call total reader AGAIN and convert total into INT
            var returnSecondTotal = benefit.TotalIndicativePremiumReader(driver);
            int secondTotalINT = Int32.Parse(returnSecondTotal.Replace("£", ""));

            //Convert benefit values into INTs
            int indicativePremiumThirdBenefitINT = Int32.Parse(indicativePremiumThirdBenefit.Replace("£", ""));
            
            //Match values
            Assert.AreEqual(secondTotalINT, (indicativePremiumFirstBenefitINT + indicativePremiumSecondBenefitINT + indicativePremiumThirdBenefitINT));
            
            //Select IP THIS TIME + Enter differnt values
            {
                string benefitId = "ip";
                new BenefitSelectionPageObjects().AddNewBenefit(driver, benefitId);
                string benefitAmount = Constants.ipBENEFITAMOUNT;
                income.IpMinimalBenefitDetails(driver, benefitAmount, browserName);
            }

            //Record displayed Indicative Premium + Exit back to Benefit Summary STORE AS 4
            {
                string benefitId = "ip";
                indicativePremiumFourthBenefit = common.BenefitIndicativePremiumReader(driver, benefitId).Replace("£", "");
                income.IpSaveButton(driver);
            }

            //Call total reader AGAIN AGAIN and convert total into INT
            var returnThirdTotal = benefit.TotalIndicativePremiumReader(driver);
            int thirdTotalINT = Int32.Parse(returnThirdTotal.Replace("£", ""));

            //Convert benefit values into INTs
            int indicativePremiumFourthBenefitINT = Int32.Parse(indicativePremiumFourthBenefit.Replace("£", ""));

            //Match values
            Assert.AreEqual(thirdTotalINT, (indicativePremiumFirstBenefitINT + indicativePremiumSecondBenefitINT + indicativePremiumThirdBenefitINT + indicativePremiumFourthBenefitINT));

            //Select another IP THIS TIME + Enter differnt values
            {
                string benefitId = "ip";
                new BenefitSelectionPageObjects().AddNewBenefit(driver, benefitId);
                string benefitAmount = Constants.ipBENEFITAMOUNT;

                income.PremiumTypeReviewable(driver);
                income.IpMinimalBenefitDetails(driver, benefitAmount, browserName);
            }

            //Record displayed Indicative Premium + Exit back to Benefit Summary STORE AS 5
            {
                string benefitId = "ip";
                indicativePremiumFifthBenefit = common.BenefitIndicativePremiumReader(driver, benefitId).Replace("£", "");
                income.IpSaveButton(driver);
            }

            //Call total reader AGAIN AGAIN and convert total into INT
            var returnFourthTotal = benefit.TotalIndicativePremiumReader(driver);
            int fourthTotalINT = Int32.Parse(returnFourthTotal.Replace("£", ""));

            //Convert benefit values into INTs
            int indicativePremiumFifthBenefitINT = Int32.Parse(indicativePremiumFifthBenefit.Replace("£", ""));

            //Match values
            Assert.AreEqual(fourthTotalINT, (indicativePremiumFirstBenefitINT + indicativePremiumSecondBenefitINT + indicativePremiumThirdBenefitINT + indicativePremiumFourthBenefitINT + indicativePremiumFifthBenefitINT));

            //Call Cleanup
            CleanUp(driver);
        }

        #endregion
    }
}
