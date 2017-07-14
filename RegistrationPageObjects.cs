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
    public class RegistrationPageObjects
    {
        //TabletClicker for uncooperative buttons
        public void TabletClick(IWebElement webElement, IWebDriver driver)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("$(arguments[0]).click();", webElement);
        }



        //Confirm page title
        public void ConfirmPageTitle(IWebDriver driver)
        {
            string pageTitle = driver.Title;
            if (!pageTitle.Equals("iPipeline - Register Now"))
            {
                throw new InvalidOperationException("This is not the expected page. Declared page title is: "
                                                    + pageTitle);
            }

        }

        //Enter some giberish and submit PAGE ONE
        public void BasicFormFillPageOne(IWebDriver driver)
        {
            var title = driver.FindElement(By.Id("title"));
            title.Clear();
            title.SendKeys("Mrs");

            var firstName = driver.FindElement(By.Id("firstName"));
            firstName.Clear();
            firstName.SendKeys("Testy");

            var middleInitial = driver.FindElement(By.Id("middleInitials"));
            middleInitial.Clear();
            middleInitial.SendKeys("T");

            var lastName = driver.FindElement(By.Id("lastName"));
            lastName.Clear();
            lastName.SendKeys("Testerson");
        }



        //An invalid Postcode for Validation Tests
        public void InvalidPostcode(IWebDriver driver)
        {
            var postCode = driver.FindElement(By.Id("postcode"));
            postCode.Clear();
            postCode.SendKeys("teddyroo");
        }

        //A valid Postcode for Validation Tests
        public void ValidPostcode(IWebDriver driver)
        {
            var postCode = driver.FindElement(By.Id("postcode"));
            postCode.Clear();
            postCode.SendKeys("GL50 1TY");
        }

        //An invalid FCA Number for Validation Tests
        public void InvalidFcaNumber(IWebDriver driver)
        {
            var fcaNumber = driver.FindElement(By.Id("fcaNumber"));
            fcaNumber.Clear();
            fcaNumber.SendKeys("111111");
        }

        //A valid FCA Number for Validation Tests
        public void ValidFcaNumber(IWebDriver driver)
        {
            var fcaNumber = driver.FindElement(By.Id("fcaNumber"));
            fcaNumber.Clear();
            fcaNumber.SendKeys(Constants.FCA);
        }

        //Click the NEXT Button
        public void NextButtonClick(IWebDriver driver)
        {         
            var nextButton = driver.FindElement(By.Id("NextButton"));
            var common = new CommonSupportObjects();
            common.TabletClick(nextButton, driver);
        }





        //Click the REGISTER NOW Button
        public void RegisterNowButtonClick(IWebDriver driver)
        {
            var nextButton = driver.FindElement(By.Id("registerNow"));
            var common = new CommonSupportObjects();
            common.TabletClick(nextButton, driver);
        }



        //Enter some giberish and submit PAGE TWO
        public void BasicFormFillPageTwo(IWebDriver driver)
        {
            var frn = driver.FindElement(By.Id("individualFrn"));
            frn.Clear();
            frn.SendKeys("0001");

            var addressOne = driver.FindElement(By.Id("address1"));
            addressOne.Clear();
            addressOne.SendKeys("3rd Floor Montpellier House");

            var town = driver.FindElement(By.Id("town"));
            town.Clear();
            town.SendKeys("Cheltenham");

            var phoneNumber = driver.FindElement(By.Id("phoneNumber"));
            phoneNumber.Clear();
            phoneNumber.SendKeys("03454 084022");

            var emailAddress = driver.FindElement(By.Id("email"));
            emailAddress.Clear();
            emailAddress.SendKeys("uk.customer.services@ipipeline.com");

            var confirmEmailAddress = driver.FindElement(By.Id("confirmEmail"));
            confirmEmailAddress.Clear();
            confirmEmailAddress.SendKeys("uk.customer.services@ipipeline.com");

            var mothersMaiden = driver.FindElement(By.Id("mothersMaidenName"));
            mothersMaiden.Clear();
            mothersMaiden.SendKeys("Ma");

            var questionOne = driver.FindElement(By.Id("questionAnswer1"));
            questionOne.Clear();
            questionOne.SendKeys("Blue, no yellow");

            var questionTwo = driver.FindElement(By.Id("questionAnswer2"));
            questionTwo.Clear();
            questionTwo.SendKeys("Halcyon");

            var recoveryEmail = driver.FindElement(By.Id("recoveryEmail"));
            recoveryEmail.Clear();
            recoveryEmail.SendKeys("uk.customer.services@ipipeline.com");

            var confirmRecoveryEmail = driver.FindElement(By.Id("confirmRecoveryEmail"));
            confirmRecoveryEmail.Clear();
            confirmRecoveryEmail.SendKeys("uk.customer.services@ipipeline.com");
        }



        //Enter some listed and predefined giberish and submit PAGE TWO
        public void AdvancedFormFillPageTwo(IWebDriver driver)
        {
            //roleInFirm ""
            driver.FindElement(By.XPath("//select[@id='roleInFirm']/option[2]")).Click();
            
            //firmAuthorisation ""
            driver.FindElement(By.XPath("//select[@id='firmAuthorisation']/option[2]")).Click();
            
            //questionGroupDropdown1 ""
            driver.FindElement(By.XPath("//select[@id='questionGroupDropdown1']/option[2]")).Click();
            
            //questionGroupDropdown2 ""
            driver.FindElement(By.XPath("//select[@id='questionGroupDropdown2']/option[2]")).Click();
            
            //sourceReference ""
            driver.FindElement(By.XPath("//select[@id='sourceReference']/option[2]")).Click();
            
            //backOfficeSoftware ""
            driver.FindElement(By.XPath("//select[@id='backOfficeSoftware']/option[2]")).Click();
        }



        //Read T&C's button
        public void AgreeTermsButton(IWebDriver driver)
        {
            var nextButton = driver.FindElement(By.Id("termsAndConditionsAccepted"));
            var common = new CommonSupportObjects();
            common.TabletClick(nextButton, driver);
        }



        //Communication Buttons
        public void CommunicationButtons(IWebDriver driver)
        {
            var essentialService = driver.FindElement(By.Id("essentialServiceInfoCheckBox"));
            var common = new CommonSupportObjects();
            common.TabletClick(essentialService, driver);

            var newsEnhancements = driver.FindElement(By.Id("newsAndEnhancementsCheckBox"));
            common.TabletClick(newsEnhancements, driver);

            var productProvider = driver.FindElement(By.Id("prodProvAndThirdPartyCheckBox"));
            common.TabletClick(productProvider, driver);
        }


        //Back to LOGIN
        public void GoToLogin(IWebDriver driver)
        {
            var nextButton = driver.FindElement(By.Id("login"));
            var common = new CommonSupportObjects();
            common.TabletClick(nextButton, driver);
        }


        //T&C link check
        public string TermsConditionsLink(IWebDriver driver)
        {
            //Corporate Site
            var termsConditions = driver.FindElement(By.Id("FaaTermsAndConditionsLink"));
            termsConditions.Click();

            //validate new page and close
            var originalWindow = driver.WindowHandles[0];
            var newWindowHandle = driver.WindowHandles[1];
            driver.SwitchTo().Window(newWindowHandle);

            return originalWindow;
        }



        //Privacy link check
        public string PrivacyPolicyLink(IWebDriver driver)
        {
            //Corporate Site
            var privacyPolicy = driver.FindElement(By.Id("FaaPrivacyPolicyLink"));
            privacyPolicy.Click();

            //validate new page and close
            var originalWindow = driver.WindowHandles[0];
            var newWindowHandle = driver.WindowHandles[1];
            driver.SwitchTo().Window(newWindowHandle);
            
            return originalWindow;
        }




    }
}
