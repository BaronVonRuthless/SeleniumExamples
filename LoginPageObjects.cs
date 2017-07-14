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
    public class LoginPageObjects
    {


        ////GET LOGIN PAGE
        // Get Login page and verify - command has 30sec timeout.
        public void GetLoginPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(Constants.BASEURL);

            driver.WaitForUpTo(30, "This is not the expected page.")
            .Until(ExpectedConditions.ElementExists(By.Id("signin-btn")));
        }
//CON//////////////////////////////////////////////////////////////////////////////////////
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
//            IWebElement assurewebButton = wait.Until<IWebElement>((d) =>
//            {
//                return d.FindElement(By.Id("signin-btn"));
//            });
//            string pageTitle = driver.Title;
//            if (!pageTitle.Equals(Constants.TITLE))
//           {
//                throw new InvalidOperationException("This is not the expected page. Declared page title is: "
//                                                    + pageTitle);
//            }
///////////////////////////////////////////////////////////////////////////////////////////
        
        /////LOGIN TO MY SERVICES
        //// Login to the My Services page
        //public void LoginValidUser(IWebDriver driver, string Username, string Password)
        //{
        //    //Username
        //    InputUsername(driver, Username);

        //    //Password
        //    InputPassword(driver, Password);

        //    //Sign In (incl. iPad clicker fix)
        //    ClickSignInButton(driver);

        //    //Wait condition
        //    driver.WaitForUpTo(30, "DO YOU WANT TO KNOW MORE?")
        //    .Until(ExpectedConditions.ElementExists(By.Id("SolutionBuilderFindOutMoreButton")));

        //}

        
        ////INPUT USER
        // Attempt login with an invalid USER
        public void InputUsername(IWebDriver driver, string Username)
        {
            //Username
            //var usernameField = driver.FindElement(By.Id("UserName"));
            var usernameField = driver.FindElement(By.Id("username"));
            usernameField.Clear();
            usernameField.SendKeys(Username);
        }


        ////INPUT PASSWORD
        // Attempt login with an invalid PASSWORD
        public void InputPassword(IWebDriver driver, string Password)
        {
            //Password
            //var passwordField = driver.FindElement(By.Id("Password"));
            var passwordField = driver.FindElement(By.Id("password"));
            passwordField.Clear();
            passwordField.SendKeys(Password);
        }


        ////CLICK SIGN-IN BUTTON
        // Attempt login with an invalid PASSWORD
        public void ClickSignInButton(IWebDriver driver)
        {
            //Sign In (incl. iPad clicker fix)
            var loginClick = driver.FindElement(By.Id("signin-btn"));
            var common = new CommonSupportObjects();
            common.TabletClick(loginClick, driver);
        }




        ////FORGOTTEN DETAILS
        //Find and click Forgotten Details link, navigate to Retrieve Password page
        public void ForgottenDetailsLink(IWebDriver driver)
        {
            //Locate link and click
            var forgottenDetails = driver.FindElement(By.LinkText("Forgotten your details?"));
            //var common = new CommonSupportObjects();
            //common.TabletClick(forgottenDetails, driver);
            forgottenDetails.Click();

                driver.WaitForUpTo(30, "This is not the expected page.")
                .Until(ExpectedConditions.ElementExists(By.Id("recoveryEmail")));

        }


        ////LOGIN ADVICE
        //Find and click Having problems? link
        public void OpenAdviceText(IWebDriver driver)
        {
            //Locate link and click
            var loginAdvice = driver.FindElement(By.LinkText("Having problems signing in?"));
            //var common = new CommonSupportObjects();
            //common.TabletClick(loginAdvice, driver);
            loginAdvice.Click();

                driver.WaitForUpTo(30, "This is not the expected page.")
                .Until(ExpectedConditions.ElementExists(By.Id("login-advice-close")));
            
        }


        ////LOGIN ADVICE *****DEPENDENT ACTION!*****
        //Find and close the Having problems? link
        public void CloseAdviceText(IWebDriver driver)
        {
            //Locate link and click
            var closeAdvice = driver.FindElement(By.Id("login-advice-close"));
            //var common = new CommonSupportObjects();
            //common.TabletClick(closeAdvice, driver);
            closeAdvice.Click();
        }


        ////REGISTER NOW
        //Find and click Register Now link. follow to the correct page
        public void RegisterNowLink(IWebDriver driver)
        {
            //Locate link and click
            var registerNow = driver.FindElement(By.Id("register-btn"));
            var common = new CommonSupportObjects();
            common.TabletClick(registerNow, driver);

                driver.WaitForUpTo(30, "This is not the expected page.")
                .Until(ExpectedConditions.ElementExists(By.Id("title")));

//CON//////////////////////////////////////////////////////////////////////////////////////
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//            IWebElement assurewebButton = wait.Until<IWebElement>((d) =>
//            {
//                return d.FindElement(By.Id("title"));
//          });
//////////////////////////////////////////////////////////////////////////////////////////
        }

    }
}