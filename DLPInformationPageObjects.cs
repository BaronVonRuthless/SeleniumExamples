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
    public class DLPInformationPageObjects
    {
            //Confirm page title
            public void ConfirmPageTitle(IWebDriver driver)
            {
                string pageURL = driver.Url;
                if (!pageURL.Equals("https://" + Constants.ENV + ".ipipeline.uk.com/ui#/lifeQuote?findoutmore"))
                {
                    throw new InvalidOperationException("This is not the expected page. Declared page title is: "
                                                        + pageURL);
                }

            }



            //DEPENDENT ACTION - Exit Page to Services
            public void ExitToServices(IWebDriver driver)
            {
                var returnLogin = driver.FindElement(By.Id("LifeQuoteMyServicesSignOutButton"));
                var common = new CommonSupportObjects();
                common.TabletClick(returnLogin, driver);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                IWebElement signInButton = wait.Until<IWebElement>((d) =>
                {
                    return d.FindElement(By.Id("SolutionBuilder-btn"));
                });
            }



            //DEPENDENT ACTION - Exit Page to Login
            public void AndExit(IWebDriver driver)
            {
                var returnLogin = driver.FindElement(By.Id("LifeQuoteSignOutButton"));
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
