using System;
using NUnit.Framework;
using Selenium;
using System.Web;
using System.Text;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Common
{

    //This class contains common actiosn that can be used on most pages; tablet style clicks, URL goTo etc...

    public class CommonRegManagerPageObjects
    {

        //TabletClicker for uncooperative buttons
        public void TabletClick(IWebElement webElement, IWebDriver driver)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("$(arguments[0]).click();", webElement);
        }


        //Footer link-check for all RegManager Pages
        public string FooterCoporateSite(IWebDriver driver)
        {
            //Corporate Site
            var corporateSite = driver.FindElement(By.Id("corporateFooterLink"));
            corporateSite.Click();

            //validate new page and close
            var originalWindow = driver.WindowHandles[0];
            var newWindowHandleCorporate = driver.WindowHandles[1];
            driver.SwitchTo().Window(newWindowHandleCorporate);

            driver.WaitForUpTo(30, "Didn't make it to the expected page")
                .Until(ExpectedConditions.ElementExists(By.Id("main-container")));

            return originalWindow;
        }


        //Footer link-check for all RegManager Pages
        public string FooterTermsConditions(IWebDriver driver)
        {
            //Terms Site link - click
            var termsConditions = driver.FindElement(By.Id("TermsAndConditionsLink"));
            termsConditions.Click();

            //validate new page and close
            var originalWindow = driver.WindowHandles[0];
            var newWindowHandleTerms = driver.WindowHandles[1];
            driver.SwitchTo().Window(newWindowHandleTerms);

            driver.WaitForUpTo(30, "Didn't make it to the expected page")
                .Until(ExpectedConditions.ElementExists(By.Id("iPipeLogo")));

            //****HOW ABOUT THIS AS A NEW WAIT TYPE?*****
            //IWait<IWebDriver> waitNEW = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(30.00));
            //waitNEW.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

            return originalWindow;
        }



        //Footer link-check for all RegManager Pages
        public string FooterXraeTerms(IWebDriver driver)
        {
            //Corporate Site
            var corporateSite = driver.FindElement(By.Id("XraeTermsAndConditionsLink"));
            corporateSite.Click();

            //validate new page and close
            var originalWindow = driver.WindowHandles[0];
            var newWindowHandleCorporate = driver.WindowHandles[1];
            driver.SwitchTo().Window(newWindowHandleCorporate);

            return originalWindow;

        }

        //Footer link-check for all RegManager Pages
        public string FooterPrivacyPolicy(IWebDriver driver)
        {
            //Corporate Site
            var corporateSite = driver.FindElement(By.Id("PrivacyPolicyLink"));
            corporateSite.Click();

            //validate new page and close
            var originalWindow = driver.WindowHandles[0];
            var newWindowHandleCorporate = driver.WindowHandles[1];
            driver.SwitchTo().Window(newWindowHandleCorporate);

            return originalWindow;
        }


        //Banner Header Logo check for all RegManager Pages
        public string BannerCheckHeaderLogo(IWebDriver driver)
        {
            //Header logo
            string headerLogo = driver.FindElement(By.ClassName("logo")).Displayed.ToString();
            return headerLogo;
        }

        //Banner Telephone number check for all RegManager Pages
        public string BannerCheckTelephone(IWebDriver driver)
        {
            //Telephone
            string telephoneNumber = driver.FindElement(By.ClassName("telephone")).Displayed.ToString();
            return telephoneNumber;
        }

        //Banner Email address check for all RegManager Pages
        public string BannerCheckMailTo(IWebDriver driver)
        {
            //Mailto Link
            string customerMail = driver.FindElement(By.LinkText("uk.support@ipipeline.com")).Displayed.ToString();
            return customerMail;
        }

    }
}
