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
    public class FamilyIncomePageObjects
    {



        ////LEVEL TERM FORM FILL
        //Complete Level Term Page
        public void FamilyIncomeFormFill(IWebDriver driver)
        {
 

            //*****IMPORTED*****

        }

        ////INPUT TERM YEARS
        //Enter the term years required
        public void FIBTermYears(IWebDriver driver, string termYears)
        {
            //Locate link and click
            var termInput = driver.FindElement(By.Id("fibTermnew"));
            termInput.SendKeys(termYears);
        }

        ////SELECT LEVEL TERM
        //Find and click the level term Button
        public void FIBCriticalIllnessSelect(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var selectCic = driver.FindElement(By.Id("fibCriticalIllnessCoverBasisnew"));
            common.TabletClick(selectCic, driver);
        }

        ////INPUT LEVEL TERM VALUE
        //Input the required amount into the Amount field
        public void FIBCriticalIllnessAmount(IWebDriver driver, string cicValue)
        {
            //Locate link and click
            var cicValueInput = driver.FindElement(By.Id("fibCriticalIllnessAmountnew"));
            cicValueInput.SendKeys(cicValue);
        }

        ////MINIMUM DETAILS
        //As above, entry of the bare minimum to complete NO XRAE
        public void FIBMinimalBenefitDetails(IWebDriver driver, string termYears, string cicValue)
        {
            var thisPage = new FamilyIncomePageObjects();

            //Run through the three basic steps to complete the LTA benefit:
            thisPage.FIBTermYears(driver, termYears);
            thisPage.FIBCriticalIllnessSelect(driver);
            thisPage.FIBCriticalIllnessAmount(driver, cicValue);
        }

    }
}