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

    public class CommonAssureWebPageObjects
    {
        ////PAGE TRANSITION - GENERIC WAIT BY CLASS
        //Generic WAIT method for non-spinner transitions (Hard Wait)
        public void GenericWaitByClass(IWebDriver driver, string pageValidator)
        {
            driver.WaitForUpTo(60, "Didn't make it to the expected page. Did not find: " + pageValidator)
            .Until(ExpectedConditions.ElementExists(By.ClassName(pageValidator)));
        }



        ////PAGE TRANSITION - SPECIFIED WAIT BY CLASS
        //Specified WAIT method for non-spinner transitions (Hard Wait)
        public void SpecifiedWaitByClass(IWebDriver driver, int waitTime, string pageValidator)
        {
            driver.WaitForUpTo(waitTime, "Didn't make it to the expected page. Did not find: " + pageValidator)
            .Until(ExpectedConditions.ElementExists(By.ClassName(pageValidator)));
        }



        ////MOVE TO NEW PAGE / iFRAME
        //Method for transitioning to sub-frame BY CLASS NAME
        public void PageFocusIFrame(IWebDriver driver, string frameIdentifier)
        {
            //Wait for iFrame
            //driver.WaitForUpTo(60, "Didn't make it to the expected page.")
            //    .Until(ExpectedConditions.ElementExists(By.ClassName("tpi-iframe")));

            //Switch focus
            driver.SwitchTo().Frame(driver.FindElement(By.ClassName(frameIdentifier)));
        }



        ////MOVE TO NEW PAGE / iFRAME
        //Method for transitioning to sub-frame BY CLASS NAME
        public void PageFocusNewTab(IWebDriver driver)
        {
            //Switch to New Tab
            var originalWindow = driver.WindowHandles[0];
            
            string oldPageTitle = driver.Title.ToString();
            
            var newWindowHandle = driver.WindowHandles[1];

            //Switch to NewWindow
            Assert.IsNotNull(newWindowHandle);

            driver.SwitchTo().Window(newWindowHandle);

            string newPageTitle = driver.Title.ToString();
        }




    }
}
