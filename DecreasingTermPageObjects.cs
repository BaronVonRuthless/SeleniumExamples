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
    public class DecreasingTermPageObjects
    {
        ////LEVEL TERM FORM FILL
        //Complete Level Term Page
        public void DecreasingTermFormFill(IWebDriver driver)
        {


            //*****IMPORTED*****

        }


        ////INPUT TERM YEARS
        //Enter the term years required
        public void DTATermYears(IWebDriver driver, string termYears)
        {
            //Locate link and click
            var termInput = driver.FindElement(By.Id("dtaTermnew"));
            termInput.SendKeys(termYears);
        }

        ////SELECT LEVEL TERM
        //Find and click the level term Button
        public void DTALevelTermSelect(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var selectLevelTerm = driver.FindElement(By.Id("dtaLifeCoverBasisnew"));
            common.TabletClick(selectLevelTerm, driver);
        }

        ////INPUT LEVEL TERM VALUE
        //Input the required amount into the Amount field
        public void DTALevelTermAmount(IWebDriver driver, string levelTermValue)
        {
            //Locate link and click
            var termValue = driver.FindElement(By.Id("dtaLifeCoverAmountnew"));
            termValue.SendKeys(levelTermValue);
        }

        ////MINIMUM DETAILS
        //As above, entry of the bare minimum to complete NO XRAE
        public void DTAMinimalBenefitDetails(IWebDriver driver, string termYears, string levelTermValue)
        {
            var thisPage = new DecreasingTermPageObjects();

            //Run through the three basic steps to complete the LTA benefit:
            thisPage.DTATermYears(driver, termYears);
            thisPage.DTALevelTermSelect(driver);
            thisPage.DTALevelTermAmount(driver, levelTermValue);
        }

    }
}