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
    public class WholeOfLifePageObjects
    {

        ////INPUT SUM ASSURED
        //Enter the term years required
        public void WOLSumAssured(IWebDriver driver, string sumAssured)
        {
            //Locate link and click
            var wolInput = driver.FindElement(By.Id("wolLifeCoverAmountnew"));
            wolInput.SendKeys(sumAssured);
        }


        ////SELECT JOINT LIFE - FIRST DEATH
        //Enter the term years required
        public void WOLJointLIfeFirst(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var firstLife = driver.FindElement(By.Id(""));
            common.TabletClick(firstLife, driver);
        }

        ////SELECT JOINT LIFE - SECOND DEATH
        //Enter the term years required
        public void WOLJointLIfeSecond(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var secondLife = driver.FindElement(By.Id(""));
            common.TabletClick(secondLife, driver);
        }














        ////LEVEL TERM FORM FILL
        //Complete Level Term Page
        public void WholeOfLifeFormFill(IWebDriver driver)
        {
            ////If spinner displayed, wait 5 seconds
            //while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            //{
            //    Thread.Sleep(5000);
            //}

            ////Check Cleint Details Landing screen reached
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            //IWebElement firstLifeDetails = wait.Until<IWebElement>((d) =>
            //{
            //    return d.FindElement(By.Id("firstlifetitle"));
            //});

            //If spinner displayed, wait 5 seconds
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                Thread.Sleep(5000);
            }

            //Check Client Details screen reached
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement clientDetailsForm = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Name("clientDetails"));
            });
            IWebElement firstLifeEntry = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id("firstlifetitle"));
            });

            //Enter Client Details inputs for 1st Life
            driver.FindElement(By.Id("firstlifetitle")).SendKeys("Mr");
            driver.FindElement(By.Id("firstlifeforename")).SendKeys("Test");
            driver.FindElement(By.Id("firstlifesurname")).SendKeys("Tester");
            driver.FindElement(By.Id("firstlifedobday")).Clear();
            driver.FindElement(By.Id("firstlifedobday")).SendKeys("01");
            driver.FindElement(By.Id("firstlifedobmonth")).Clear();
            driver.FindElement(By.Id("firstlifedobmonth")).SendKeys("01");
            driver.FindElement(By.Id("firstlifedobyear")).Clear();
            driver.FindElement(By.Id("firstlifedobyear")).SendKeys("1977");
            driver.FindElement(By.Id("firstlifegenderfemale")).Click();
            driver.FindElement(By.Id("firstlifegendermale")).Click();
            driver.FindElement(By.Id("firstlifesmokeryes")).Click();
            driver.FindElement(By.XPath("//select[@id='firstlifeemploymentStatus']/option[2]")).Click();
            driver.FindElement(By.Id("firstlifeincome")).Click();
            driver.FindElement(By.Id("firstlifeincome")).Click();
            driver.FindElement(By.Id("firstlifeincome")).SendKeys("35000");
            driver.FindElement(By.Id("firstlifeoccupation")).SendKeys("Acc");
            driver.FindElement(By.LinkText("Accountant")).Click();

            //Add 2nd Life
            driver.FindElement(By.Id("addSecondLifeYes")).Click();

            //Check 2nd Life added
            IWebElement secondLife = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id("secondlifetitle"));
            });

            //Enter Client Details inputs for 2nd Life
            driver.FindElement(By.Id("secondlifetitle")).SendKeys("Mrs");
            driver.FindElement(By.Id("secondlifeforename")).SendKeys("Test");
            driver.FindElement(By.Id("secondlifesurname")).SendKeys("Tester");
            driver.FindElement(By.Id("secondlifedobday")).Click();
            driver.FindElement(By.Id("secondlifedobday")).SendKeys("01");
            driver.FindElement(By.Id("secondlifedobmonth")).Click();
            driver.FindElement(By.Id("secondlifedobmonth")).SendKeys("01");
            driver.FindElement(By.Id("secondlifedobyear")).Click();
            driver.FindElement(By.Id("secondlifedobyear")).SendKeys("1978");
            driver.FindElement(By.XPath("//select[@id='secondlifeemploymentStatus']/option[2]")).Click();
            driver.FindElement(By.Id("secondlifeincome")).SendKeys("25000");
            driver.FindElement(By.Id("secondlifeoccupation")).SendKeys("Acc");
            driver.FindElement(By.LinkText("Accountant")).Click();


            //Click Save Client
            IWebElement saveClient = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id("btnSaveClient"));
            });



            if ((driver.FindElement(By.Id("btnSaveClient"))).Displayed)
            {
                driver.FindElement(By.Id("btnSaveClient")).Click();
                Thread.Sleep(3000);
            }
            else
            {
                //Check Benefit Selection screen reached
                IWebElement benefitScreen = wait.Until<IWebElement>((d) =>
                {
                    return d.FindElement(By.Id("benefit-summary"));
                });
            }

            //*****IMPORTED*****

        }

    }
}