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
using System.Drawing.Imaging;

namespace Common
{

    //This class contains common actiosn that can be used on most pages; tablet style clicks, URL goTo etc...

    public class CommonSupportObjects
    {
        ////GET PAGE TITLE
        //Return page title as trimmed string
        public void ConfirmPageTitle(IWebDriver driver, string expectedPage)
        {
            string pageTitle = driver.Title;
            if (!pageTitle.Equals(expectedPage))
            {
                throw new InvalidOperationException("This is not the expected page. Declared page title is: "
                                                    + pageTitle);
            }
        }

        ////TABLET CLICKER
        //TabletClicker for uncooperative buttons
        public void TabletClick(IWebElement webElement, IWebDriver driver)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("$(arguments[0]).click();", webElement);
        }



        ////CONFIRM NAVIGATION
        //Accept the Browser generated "Leave This Page" popup
        public void ConfirmNavigation(IWebDriver driver)
        {
            driver.SwitchTo().Alert().Accept();
        }



        ////ELEMENT IS PRESENT VERIFICATION & CLICK
        //Uses validation to determin if element is visible on device/orientation
        //Uses IF ELSE to find and use alternative ***TAKES TWO INPUT VALUES***
        public void ElementIsPresentClick(IWebDriver driver, string standardElement, string alternativeElement)
        {
            //Check page for the button you want and click IF found:
            IList<IWebElement> findElementOnPage = driver.FindElements(By.Id(standardElement));
            if (findElementOnPage.Count > 0 && findElementOnPage[0].Displayed)
            {
                var standardButton = driver.FindElement(By.Id(standardElement));
                TabletClick(standardButton, driver);
            }
            //ELSE, you're using an iPhone! Use the alternative button instead:
            else
            {
                var alternativeButton = driver.FindElement(By.Id(alternativeElement));
                TabletClick(alternativeButton, driver);
            }
        }

        ////ELEMENT IS PRESENT - READ
        //Uses validation to determin if element is visible on device/orientation
        //Uses IF ELSE to find and use alternative ***TAKES TWO INPUT VALUES***
        //Returns a string value that contains trimmed value of premium window
        public string ElementIsPresentRead(IWebDriver driver, string standardReadElement, string alternativeReadElement)
        {
            //Set variable to report value to:
            var returnValue = "";

            //Check page for correct premium window (scaling dependant)
            IList<IWebElement> findElementOnPage = driver.FindElements(By.Id(standardReadElement));
            if (findElementOnPage.Count > 0 && findElementOnPage[0].Displayed)
            {
                returnValue = driver.FindElement(By.Id(standardReadElement)).Text;
            }
            //ELSE, you're using an iPhone! Use the alternative element instead:
            else
            {
                returnValue = driver.FindElement(By.Id(alternativeReadElement)).Text;
            }

            return returnValue.Trim();
        }



        ////HIDDEN ELEMENT - BY ID
        //Quick checker to validate the PRESENCE or ABSENCE of elements
        //Returns FALSE if unable to locate, returns TRUE if pressent on page
        public bool ElementPresentConfirmById(IWebDriver driver, string elementId)
        {
            try
            {
                if (driver.FindElement(By.Id(elementId)).Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
            catch
            {
                return false;
            }
        }

        ////HIDDEN ELEMENT - BY XPATH
        //Quick checker to validate the PRESENCE or ABSENCE of elements
        //Returns FALSE if unable to locate, returns TRUE if pressent on page
        public bool ElementPresentConfirmByXpath(IWebDriver driver, string elementPath)
        {
            try
            {
                if (driver.FindElement(By.XPath(elementPath)).Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch
            {
                return false;
            }
        }



        ////"ONE OR THE OTHER" ELEMENT - BY ID
        //Quick checker to validate the PRESENCE or ABSENCE of ONE ELEMENT OR ANOTHER
        //Returns FALSE if unable to locate, returns TRUE if pressent on page
        public bool ElementOneOrElementTwoPresentById(IWebDriver driver, string firstElementId, string secondElementId)
        {
            try
            {
                if (driver.FindElement(By.Id(firstElementId)).Displayed)
                {
                    return true;
                }
                if (driver.FindElement(By.Id(secondElementId)).Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch
            {
                return false;
            }
        }



        ////ADD LTA - SINGLE LIFE MINIMAL DETAILS
        //Use the "Minimal DEtails" objects to inoput a basic LTA.
        public void AddBasicLevelTermBenefit(IWebDriver driver)
        {
            string termYears = Constants.ltaTERMYEARS;
            string levelTermValue = Constants.ltaTERMVALUE;
            string benefitId = "lta";
            new BenefitSelectionPageObjects().AddNewBenefit(driver, benefitId);
            new LevelTermPageObjects().LTAMinimalBenefitDetails(driver, termYears, levelTermValue);
            new CommonSolutionBuilderPageObjects().BenefitSaveButton(driver, benefitId);
        }

        ////ADD DTA - SINGLE LIFE MINIMAL DETAILS
        //Use the "Minimal DEtails" objects to inoput a basic DTA.
        public void AddBasicDecreasingTermBenefit(IWebDriver driver)
        {
            string termYears = Constants.dtaTERMYEARS;
            string levelTermValue = Constants.dtaTERMVALUE;
            string benefitId = "dta";
            new BenefitSelectionPageObjects().AddNewBenefit(driver, benefitId);
            new DecreasingTermPageObjects().DTAMinimalBenefitDetails(driver, termYears, levelTermValue);
            new CommonSolutionBuilderPageObjects().BenefitSaveButton(driver, benefitId);
        }

        ////ADD FIB - SINGLE LIFE MINIMAL DETAILS
        //Use the "Minimal DEtails" objects to inoput a basic FIB.
        public void AddBasicFamilyIncomeBenefit(IWebDriver driver)
        {
            string termYears = Constants.fibTERMYEARS;
            string cicValue = Constants.fibCICVALUE;
            string benefitId = "fib";
            new BenefitSelectionPageObjects().AddNewBenefit(driver, benefitId);
            new FamilyIncomePageObjects().FIBMinimalBenefitDetails(driver, termYears, cicValue);
            new CommonSolutionBuilderPageObjects().BenefitSaveButton(driver, benefitId);
        }

        ////ADD IP - SINGLE LIFE MINIMAL DETAILS
        //Use the "Minimal DEtails" objects to inoput a basic IP.
        public void AddBasicIncomeProtectionBenefit(IWebDriver driver, string browserName)
        {
            string benefitAmount = Constants.ipBENEFITAMOUNT;
            string benefitId = "ip";
            new BenefitSelectionPageObjects().AddNewBenefit(driver, benefitId);
            new IncomeProtectionPageObjects().IpMinimalBenefitDetails(driver, benefitAmount, browserName);
            new CommonSolutionBuilderPageObjects().BenefitSaveButton(driver, benefitId);
        }

        ////ADD WOL - SINGLE LIFE MINIMAL DETAILS
        //Use the "Minimal DEtails" objects to inoput a basic WOL.
        public void AddBasicWholeOfLifeBenefit(IWebDriver driver)
        {
            string sumAssured = Constants.wolSUMASSURED;
            string benefitId = "wol";
            new BenefitSelectionPageObjects().AddNewBenefit(driver, benefitId);
            new WholeOfLifePageObjects().WOLSumAssured(driver, sumAssured);
            new CommonSolutionBuilderPageObjects().BenefitSaveButton(driver, benefitId);
        }

        ////ADD BP - SINGLE LIFE MINIMAL DETAILS
        //Use the "Minimal DEtails" objects to inoput a basic BP.
        public void AddBasicBusinessProtectionBenefit(IWebDriver driver)
        {
            string termYears = Constants.bpTERMYEARS;
            string businessTermValue = Constants.bpTERMVALUE;
            string benefitId = "bp";
            new BenefitSelectionPageObjects().AddNewBenefit(driver, benefitId);
            new BusinessProtectionPageObjects().BPMinimalBenefitDetails(driver, termYears, businessTermValue);
            new CommonSolutionBuilderPageObjects().BenefitSaveButton(driver, benefitId);
        }



        ////SCREENSHOT TO FILE - OUTOUTS PNG
        //Takes context details and saves a file to LOCAL DRIVE
        public void ScreenshotToFile(IWebDriver driver, string testName, string browserName, string version, string platform, string deviceName, string deviceOrientation)
        {
            //Build screenshot filename
            string ssFilename = testName.ToString().Trim() + browserName.ToString().Trim() + version.ToString().Trim() + platform.ToString().Trim() + deviceName.ToString().Trim();

            //Take screenshot & save to file: C:\\AutomationSolutions\\Screenshots\...
            Screenshot shotShot = ((ITakesScreenshot)driver).GetScreenshot();
            shotShot.SaveAsFile("C:\\AutomationSolutions\\Screenshots\\UI_" + ssFilename + ".png", ImageFormat.Png);
        }



        ////SCRRENSHOT TO HASH - OUTPUTS STRING
        public string ScreenshotToString(IWebDriver driver)
        {
            //Possible alternative control to take SCREENSHOT at close of test...
            Screenshot picpic = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotBase64 = picpic.AsBase64EncodedString;
            
            //Other return options...
            //byte[] screenshotAsByteArray = picpic.AsByteArray;
            //shotshot.ToString();

            return screenshotBase64;
        }

    }
}
