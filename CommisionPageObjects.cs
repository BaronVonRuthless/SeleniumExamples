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
    public class CommissionPageObjects
    {

        ////COMMISSION BUTTONS - FULL
        //Commission = Full
        public void SelectFull(IWebDriver driver)
        {
            var common = new CommonSupportObjects();
            var fullCommission = driver.FindElement(By.Id("commissionTypeFull"));
            common.TabletClick(fullCommission, driver);

        }

        ////COMMISSION BUTTONS - MODIFIED
        //Commission = Modified
        public void SelectModified(IWebDriver driver)
        {
            var common = new CommonSupportObjects();
            var modCommission = driver.FindElement(By.Id("commissionTypeModified"));
            common.TabletClick(modCommission, driver);
        }

        ////COMMISSION BUTTONS - NIL
        //Commission = Nil
        public void SelectNil(IWebDriver driver)
        {
            var common = new CommonSupportObjects();
            var nilCommission = driver.FindElement(By.Id("commissionTypeNil"));
            common.TabletClick(nilCommission, driver);

        }

        ////INPUT PERCENTAGE VALUE
        //Percentage of normal initial commision required
        public void PercentageInput(IWebDriver driver, string inputPercentage)
        {
            var inputValue = driver.FindElement(By.Id("percentageInput"));
            inputValue.Clear();
            inputValue.SendKeys(inputPercentage);

        }

        ////INDEMNITY = YES
        //Set indemnity option to yes
        public void IndemnityYes(IWebDriver driver)
        {
            var common = new CommonSupportObjects();
            var yesIndemnity = driver.FindElement(By.Id("indemnityRequiredYes"));
            common.TabletClick(yesIndemnity, driver);

        }

        ////INDEMNITY = No
        //Set indemnity option to no
        public void IndemnityNo(IWebDriver driver)
        {
            var common = new CommonSupportObjects();
            var noIndemnity = driver.FindElement(By.Id("indemnityRequiredNo"));
            common.TabletClick(noIndemnity, driver);

        }

        ////SAVE CLIENT
        //Find and click Save Button
        public void SaveBenefitCommission(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var saveCommission = driver.FindElement(By.Id("commission-save-button"));
            common.TabletClick(saveCommission, driver);
        }

    }
}