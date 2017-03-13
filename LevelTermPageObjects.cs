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
    public class LevelTermPageObjects
    {
        ////LEVEL TERM FORM FILL
        //Complete Level Term Page
        public void FormFillLTA(IWebDriver driver)
        {

            //*****IMPORTED*****

        }

        ////SELECT JOINT LIFE
        //Find and click the joint  Button
        public void LTASelectJoint(IWebDriver driver)
        {
            //Locate button and click
            var common = new CommonSupportObjects();
            var selectJoint = driver.FindElement(By.Id("ltaJointLivesnew"));
            common.TabletClick(selectJoint, driver);
        }


        ////INPUT TERM YEARS
        //Enter the term years required
        public void LTATermYears(IWebDriver driver, string termYears)
        {
            //Locate link and click
            var termInput = driver.FindElement(By.Id("ltaTermnew"));
            termInput.SendKeys(termYears);
        }

        ////SELECT LEVEL TERM
        //Find and click the level term Button
        public void LTALevelTermSelect(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var selectLevelTerm = driver.FindElement(By.Id("ltaLifeCoverBasisnew"));
            common.TabletClick(selectLevelTerm, driver);
        }

        ////INPUT LEVEL TERM VALUE
        //Input the required amount into the Amount field
        public void LTALevelTermAmount(IWebDriver driver, string levelTermValue)
        {
            //Locate link and click
            var termValue = driver.FindElement(By.Id("ltaLifeCoverAmountnew"));
            termValue.SendKeys(levelTermValue);
        }


        ////MINIMUM DETAILS
        //As above, entry of the bare minimum to complete NO XRAE
        public void LTAMinimalBenefitDetails(IWebDriver driver, string termYears, string levelTermValue)
        {
            var thisPage = new LevelTermPageObjects();
        
            //Run through the three basic steps to complete the LTA benefit:
            thisPage.LTATermYears(driver, termYears);
            thisPage.LTALevelTermSelect(driver);
            thisPage.LTALevelTermAmount(driver, levelTermValue);
        }



    }
}