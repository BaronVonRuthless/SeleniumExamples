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
    public class ForgottenDetailsPageObjects
    {
        //Confirm page title
        public void ConfirmPageTitle(IWebDriver driver)
        {
            string pageTitle = driver.Title;
            if (!pageTitle.Equals("iPipeline - Forgotten Details"))
            {
                throw new InvalidOperationException("This is not the expected page. Declared page title is: "
                                                    + pageTitle);
            }

        }

        //Enter some giberish and submit
        public void InvalidEmail(IWebDriver driver)
        {
            var recoveryEmail = driver.FindElement(By.Id("recoveryEmail"));
            recoveryEmail.Clear();
            recoveryEmail.SendKeys("teddyrooserveltsguns");

            //var emailSubmit = driver.FindElement(By.XPath(".//*[@id='next']"));
            var emailSubmit = driver.FindElement(By.Id("RequestEmailButtonSmall"));
            //emailSubmit.Click();
            var common = new CommonSupportObjects();
            common.TabletClick(emailSubmit, driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement signInButton = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.XPath(".//*[@id='requestVerificationEmailForm']/div[2]/div[2]"));
            });

        }

        //Enter bad email and submit
        public void EmailNotRecognisd(IWebDriver driver)
        {
            var recoveryEmail = driver.FindElement(By.Id("recoveryEmail"));
            recoveryEmail.Clear();
            recoveryEmail.SendKeys("teddy.rooservelt@prezzy4eva.com");

            //var emailSubmit = driver.FindElement(By.XPath(".//*[@id='next']"));
            var emailSubmit = driver.FindElement(By.Id("RequestEmailButtonSmall"));
            //emailSubmit.Click();
            var common = new CommonSupportObjects();
            common.TabletClick(emailSubmit, driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement signInButton = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.XPath(".//*[@id='requestVerificationEmailForm']/div[3]/div"));
            });

        }

        //Enter Valid email and submit
        public void ValidEmailAndSubmit(IWebDriver driver)
        {
            var recoveryEmail = driver.FindElement(By.Id("recoveryEmail"));
            recoveryEmail.Clear();
            recoveryEmail.SendKeys(Constants.EMAIL);

            //var emailSubmit = driver.FindElement(By.XPath(".//*[@id='next']"));
            var emailSubmit = driver.FindElement(By.Id("RequestEmailButtonSmall"));
            emailSubmit.Click();
            //var common = new CommonSupportObjects();
            //common.TabletClick(emailSubmit, driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement signInButton = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.XPath(".//*[@id='requestVerificationEmailForm']/div[4]/div[2]/p"));
            });

        }

        //DEPENDENT ACTION - Exit Page
        public void AndExit(IWebDriver driver)
        {
            var returnLogin = driver.FindElement(By.XPath(".//*[@id='requestVerificationEmailForm']/div[4]/div[2]/a"));
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
