using System;
using NUnit.Framework;
using Selenium;
using System.Web;
using System.Text;
using System.Net;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Common;
using RegManagerPageObjects;

namespace SolutionBuilderClientDetailsPageObjects
{
    public class BusinessProtectionPageObjects
    {



        ////LEVEL TERM FORM FILL
        //Complete Level Term Page
        public void BusinessDProtectionFormFill(IWebDriver driver)
        {


            //*****IMPORTED*****

        }

        ////INPUT TERM YEARS
        //Enter the term years required
        public void BPTermYears(IWebDriver driver, string termYears)
        {
            //Locate link and click
            var termInput = driver.FindElement(By.Id("bpTermnew"));
            termInput.SendKeys(termYears);
        }

        ////SELECT LEVEL TERM
        //Find and click the level term Button
        public void BPLevelTermSelect(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var selectLevelTerm = driver.FindElement(By.Id("bpLifeCoverBasisnew"));
            common.TabletClick(selectLevelTerm, driver);
        }

        ////INPUT LEVEL TERM VALUE
        //Input the required amount into the Amount field
        public void BPLevelTermAmount(IWebDriver driver, string levelTermValue)
        {
            //Locate link and click
            var termValue = driver.FindElement(By.Id("bpLifeCoverAmountnew"));
            termValue.SendKeys(levelTermValue);
        }


        ////MINIMUM DETAILS
        //As above, entry of the bare minimum to complete NO XRAE
        public void BPMinimalBenefitDetails(IWebDriver driver, string termYears, string businessTermValue)
        {
            var thisPage = new BusinessProtectionPageObjects();

            //Run through the three basic steps to complete the LTA benefit:
            thisPage.BPTermYears(driver, termYears);
            thisPage.BPLevelTermSelect(driver);
            thisPage.BPLevelTermAmount(driver, businessTermValue);
        }

    }
}