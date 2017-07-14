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

    //Common page actions for the My iPipeline Services Page

    public class MyServicesPageObjects
    {
        //Confirm page title
        public void ConfirmPageTitle(IWebDriver driver)
        {
            string pageTitle = driver.Title;
            if (!pageTitle.Equals("iPipeline - My iPipeline Services"))
            {
                throw new InvalidOperationException("This is not the expected page. Declared page title is: "
                                                    + pageTitle);
            }

        }


        //Click SolutionBuilder - Find Out More
        public void SolutionBuilderFindOut(IWebDriver driver)
        {
            //Find and Click SolutionBuilder - Find Out More button
            var assureFind = driver.FindElement(By.Id("SolutionBuilderFindOutMoreButton"));
            var common = new CommonSupportObjects();
            common.TabletClick(assureFind, driver);

            //Wait on page load
            var waitTransfer = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var signInButton = waitTransfer.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id("Solution"));
            });

        }


        //Click Assureweb - Find Out More
        public void AssurewebFindOut(IWebDriver driver)
        {
            //Find and Click Assureweb - Find Out More button
            var assureFind = driver.FindElement(By.Id("AssurewebFindOutMoreButton"));
            var common = new CommonSupportObjects();
            common.TabletClick(assureFind, driver);

            //Wait on page load
            var waitTransfer = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var signInButton = waitTransfer.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id("MyIpipelineServicesSignOutButton"));
            });

        }



        //Click XRAE - Find Out More
        public void XRAEFindOut(IWebDriver driver)
        {
            //Find and Click XRAE - Find Out More button
            var assureFind = driver.FindElement(By.Id("XraeFindOutMoreButton"));
            var common = new CommonSupportObjects();
            common.TabletClick(assureFind, driver);

            //Wait on page load
            var waitTransfer = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var signInButton = waitTransfer.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id("MyIpipelineServicesSignOutButton"));
            });

        }

        //Click RetirementBuilder - Find Out More
        public void RetirementBuilderFindOut(IWebDriver driver)
        {
            //Find and Click RetirementBuilder - Find Out More button
            var assureFind = driver.FindElement(By.Id("RetirementBuilderFindOutMoreButton"));
            var common = new CommonSupportObjects();
            common.TabletClick(assureFind, driver);

            //Wait on page load
            var waitTransfer = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var signInButton = waitTransfer.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id("MyIpipelineServicesSignOutButton"));
            });

        }


        //Click LifeQuote - Find Out More
        public void LifeQuoteFindOut(IWebDriver driver)
        {
            //Find and Click LifeQuote - Find Out More button
            var assureFind = driver.FindElement(By.Id("LifeQuoteFindOutMoreButton"));
            var common = new CommonSupportObjects();
            common.TabletClick(assureFind, driver);

            //Wait on page load
            var waitTransfer = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            var signInButton = waitTransfer.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id("LifeQuoteMyServicesSignOutButton"));
            });

        }


        //Logout (with wait options for debug + tablet clicker option)
        public void LogOut(IWebDriver driver)
        {
            var signOut = driver.FindElement(By.Id("SignOutButton"));
            var common = new CommonSupportObjects();
            common.TabletClick(signOut, driver);

            driver.WaitForUpTo(30, "Couldn't reach login page")
            .Until(ExpectedConditions.ElementExists(By.Id("username")));
        }



        //Click SolutionBuilder - Lets Go!
        public void LaunchSolutionBuilder(IWebDriver driver)
        {
            //Find and Click Solution Builder:
                var solutionLaunch = driver.FindElement(By.Id("SolutionBuilder-btn"));
                var common = new CommonSupportObjects();
                common.TabletClick(solutionLaunch, driver);
            
            //while (driver.FindElement(By.ClassName("spinner")).Displayed)
            //{
                driver.WaitForUpTo(60, "Solutionability")
                .Until(ExpectedConditions.ElementToBeClickable(By.Id("btnAddClient")));
            //}
        }



        //Click AssureWeb - Lets Go!
        public void LaunchAssureWeb(IWebDriver driver)
        {
            //Find and Click AssureWeb:
            var assureLaunch = driver.FindElement(By.Id("Assureweb-btn-new"));
            var common = new CommonSupportObjects();
            common.TabletClick(assureLaunch, driver);

            //while (driver.FindElement(By.ClassName("spinner")).Displayed)
            //{
            driver.WaitForUpTo(60, "Assureability")
            .Until(ExpectedConditions.ElementToBeClickable(By.Id("HeaderIpipelineLogo")));
            //}
        }



        //My account!
        public string MyAccount(IWebDriver driver)
        {
            //Click!
            var myAccount = driver.FindElement(By.Id("MyAccountButton"));
            var common = new CommonSupportObjects();
            common.TabletClick(myAccount, driver);

            //validate new page
            var originalWindow = driver.WindowHandles[0];
            var newWindowHandle = driver.WindowHandles[1];
            driver.SwitchTo().Window(newWindowHandle);

            return originalWindow;
        }

    }
}
