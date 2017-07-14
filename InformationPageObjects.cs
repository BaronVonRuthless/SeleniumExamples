using System;
using NUnit.Framework;
using Selenium;
using System.Web;
using System.Text;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Common;

namespace RegManagerPageObjects
{

    //Common page actions for the Password Recovery page
    public class InformationPageObjects
    {
        //Confirm page title
        public void ConfirmPageTitle(IWebDriver driver)
        {
            string pageTitle = driver.Title;
            if (!pageTitle.Equals("iPipeline - Services Information"))
            {
                throw new InvalidOperationException("This is not the expected page. Declared page title is: "
                                                    + pageTitle);
            }

        }


        //Open and close the accordian - SOLUTION BUILDER
        public void SelectSolutionBuilder(IWebDriver driver)
        {
            var solutionArrow = driver.FindElement(By.Id("Solution"));
            var common = new CommonSupportObjects();
            common.TabletClick(solutionArrow, driver);
        }


        //Open and close the accordian - ASSUREWEB
        public void SelectAssureweb(IWebDriver driver)
        {
            var assurewebArrow = driver.FindElement(By.Id("Assureweb"));
            var common = new CommonSupportObjects();
            common.TabletClick(assurewebArrow, driver);
        }


        //Open and close the accordian - ASSUREWEB
        public void SelectXRAE(IWebDriver driver)
        {
            var xraeArrow = driver.FindElement(By.Id("xrae"));
            var common = new CommonSupportObjects();
            common.TabletClick(xraeArrow, driver);
        }


        //Open and close the accordian - ASSUREWEB
        public void SelectRetirementBuilder(IWebDriver driver)
        {
            var retirementArrow = driver.FindElement(By.Id("Retirement"));
            var common = new CommonSupportObjects();
            common.TabletClick(retirementArrow, driver);
        }


        //DEPENDENT ACTION - Exit Page to Services
        public void ExitToServices(IWebDriver driver)
        {
            var returnLogin = driver.FindElement(By.Id("MyIpipelineServicesSignOutButton"));
            var common = new CommonSupportObjects();
            common.TabletClick(returnLogin, driver);
            
            //CON//////////////////////////////////////////////////////////////////////////////////////
            //            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //            IWebElement signInButton = wait.Until<IWebElement>((d) =>
            //            {
            //                return d.FindElement(By.Id("SolutionBuilder-btn"));
            //            });
            //        }
            ///////////////////////////////////////////////////////////////////////////////////////////

            driver.WaitForUpTo(30, "This is not the expected page.")
                .Until(ExpectedConditions.ElementExists(By.Id("SolutionBuilder-btn")));
        }
        

        //DEPENDENT ACTION - Exit Page to Login
        public void AndExit(IWebDriver driver)
        {
            var returnLogin = driver.FindElement(By.Id("ServiceInformationSignOutButton"));
            var common = new CommonSupportObjects();
            common.TabletClick(returnLogin, driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement signInButton = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id("username"));
            });
        }

    }
}
