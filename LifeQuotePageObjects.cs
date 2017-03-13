using System;
using NUnit.Framework;
using Selenium;
using System.Web;
using System.Text;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using RegManagerPageObjects;
using SolutionBuilderClientDetailsPageObjects;
using Common;
using System.Collections.Generic;

namespace SolutionBuilderQuoteDetailsPageObjects
{

    //This class contains common actions that occur only on the different results screens

    public class LifeQuotePageObjects
    {


                //APPLY OPTIONS - PROVIDER
                //
                public void ApplyOptionsProvider(IWebDriver driver)
                {
                    var optionsProvider = driver.FindElement(By.XPath(".//*[@id='lifeQuote-apply']/div[2]/div/div/hidden[1]/div/button"));
                    new CommonSupportObjects().TabletClick(optionsProvider, driver);
                }


                //APPLY OPTIONS - DLP
                //
                public void ApplyOptionsDLP(IWebDriver driver)
                {
                    var optionsDlp = driver.FindElement(By.XPath(".//*[@id='lifeQuote-apply']/div[2]/div/div/hidden[2]/div/button"));
                    new CommonSupportObjects().TabletClick(optionsDlp, driver);
                }


                //APPLY OPTIONS - CLOSE
                //
                public void ApplyOptionsClose(IWebDriver driver)
                {
                    var optionsClose = driver.FindElement(By.Id("lifeQuoteApplyClose"));
                    new CommonSupportObjects().TabletClick(optionsClose, driver);
                }


                //APPLY OPTIONS - GET MESSAGE
                //Returns the content of the message element on the Modal (for validation)
                public string ApplyOptionsMessageText(IWebDriver driver)
                {
                    var screenText = driver.FindElement(By.XPath(".//*[@id='lifeQuote-apply']/div[2]/div/div/div[2]/div/span[2]")).Text;
                    string messageText = screenText.ToString().Trim();
                    return messageText;
                }
                //In order to complete your LifeQuote registration please contact LifeQuote on 0800 6529705.


        ////POP UP
        //CLOSE LIFEQUOTE - CLOSE
        //
        public void LifeQuoteModalClose(IWebDriver driver)
        {
            var modalClose = driver.FindElement(By.Id("lifeQuoteRegistrationClose"));
            new CommonSupportObjects().TabletClick(modalClose, driver);
        
        }

        //LIFEQUOTE POP UP
        //
        public void LifeQuoteModalOpen(IWebDriver driver)
        {
            var modalOpen = driver.FindElement(By.XPath(".//*[@id='model-results']/div/ng-include[2]/div/div/div[2]/div[2]"));
            new CommonSupportObjects().TabletClick(modalOpen, driver);

        }

        //CLOSE LIFEQUOTE - OK
        //
        public void LifeQuoteModalOkay(IWebDriver driver)
        {
            var modalOkay = driver.FindElement(By.XPath(".//*[@id='lifeQuote-registration']/div[2]/div/div/button"));
            new CommonSupportObjects().TabletClick(modalOkay, driver);
        }
        //validate on .//*[@id='lifeQuote-registration']/div[2]/div/div/h3[1] contains:
        //   Registering For LifeQuote



    }
}
