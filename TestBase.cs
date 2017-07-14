using Gallio.Framework;
using Gallio.Model;
using MbUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;

namespace Common
{
    //********************************************************************************
    //*****   VALUES USED TO CONTROL THE ENVIRONMENT UNDER TEST - HAVE AT 'EM!   *****
    //********************************************************************************
    
    [TestFixture]
    [Header("appiumVersion", "browserName", "version", "platform", "platformVersion", "platformName", "deviceName", "deviceOrientation")]

    ////DESKTOP BROWSERS - Internet Explorer 
    //[Row("", "MicrosoftEdge", "latest", "Windows 10", "", "", "", "")]
    //[Row("", "Internet Explorer", "11", "Windows 10", "", "", "", "")]
    //[Row("", "Internet Explorer", "10", "Windows 8", "", "", "", "")]
    //[Row("", "Internet Explorer", "11", "Windows 7", "", "", "", "")]
    //[Row("", "Internet Explorer", "10", "Windows 7", "", "", "", "")] // ---> Login Page "Sign-In" button unresponsive in SL environments?
    ////DESKTOP BROWSERS - Chrome
    [Row("", "chrome", "latest-1", "Windows 7", "", "", "", "")]
    [Row("", "chrome", "latest", "Windows 8.1", "", "", "", "")]
    [Row("", "chrome", "latest", "Windows 10", "", "", "", "")]
    [Row("", "chrome", "latest-1", "Windows 10", "", "", "", "")]
    ////DESKTOP BROWSERS - Firefox
    //[Row("", "firefox", "latest-1", "Windows 7", "", "", "", "")] // ---> My Services "HeaderIpipelineLogo" logo not found in SL environments?
    //[Row("", "firefox", "latest", "Windows 8", "", "", "", "")]
    ////DESKTOP BROWSERS - Safari (OSX Only)
    //[Row("", "Safari", "latest", "OS X 10.11", "", "", "", "")]
    //[Row("", "Safari", "8", "OS X 10.10", "", "", "", "")]

    ////////MOBILE BROWSERS - iOS
    //[Row("1.6.3", "Safari", "", "", "10.0", "iOS", "iPhone 6 Simulator", "portrait")]
    //[Row("1.6.3", "Safari", "", "", "9.3", "iOS", "iPad 2 Simulator", "portrait")]
    //[Row("1.6.3", "Safari", "", "", "10.0", "iOS", "iPad Air Simulator", "portrait")]
    //[Row("1.6.3", "Safari", "", "", "10.0", "iOS", "iPhone 7 Plus Simulator", "portrait")]
    //[Row("1.6.3", "Safari", "", "", "10.0", "iOS", "iPad Retina Simulator", "portrait")]
    //[Row("1.6.3", "Safari", "", "", "10.0", "iOS", "iPhone 5 Simulator", "portrait")] // ---> Fails to POST simulator session.
    //////MOBILE BROWSERS - Android
    //[Row("1.5.3", "Browser", "", "", "4.4", "Android", "Samsung Galaxy S4 GoogleAPI Emulator", "portrait")]
    //[Row("1.5.3", "Browser", "", "", "4.4", "Android", "LG Nexus 4 Emulator", "portrait")]
    //[Row("1.5.3", "Browser", "", "", "4.4", "Android", "Google Nexus 7 HD Emulator", "portrait")]
    //[Row("1.5.3", "Browser", "", "", "4.4", "Android", "Google Nexus 7 HD Emulator", "landscape")]
    //[Row("1.5.3", "Browser", "", "", "4.4", "Android", "Amazon Kindle Fire HD 8.9 GoogleAPI Emulator", "landscape")]



    //*********************************************************************************
    //*****   FIXED VALUES BELOW THIS LINE - DON'T GO CHANGIN' 'EM WILLY-NILLY!   *****
    //*********************************************************************************

    public class TestBase
    {
        //// Setup the Driver session and configure SauceLabs:
        public IWebDriver Setup(string appiumVersion, string browserName, string version, string platform, string platformVersion, string platformName, string deviceName, string deviceOrientation)
        {
            //sauceLabs URL:
            Uri commandExecutorUri = new Uri("https://ondemand.saucelabs.com/wd/hub");

            //set Desired Capabilities:
            DesiredCapabilities caps = new DesiredCapabilities();

            //generic Desktop Browser config':
            if (browserName != "")
            { caps.SetCapability("browserName", browserName); }
            else
            { }
            if (version != "")
            { caps.SetCapability("version", version); }
            else
            { }
            if (platform != "")
            { caps.SetCapability("platform", platform); }
            else
            { }

            //appium ONLY config':
            if (appiumVersion != "")
            {caps.SetCapability("appiumVersion", appiumVersion);}
            else
            {}
            if (platformVersion != "")
            { caps.SetCapability("platformVersion", platformVersion); }
            else
            { }
            if (platformName != "")
            { caps.SetCapability("platformName", platformName); }
            else
            { }
            if (deviceName != "")
            { caps.SetCapability("deviceName", deviceName); }
            else
            { }
            if (deviceOrientation != "")
            { caps.SetCapability("deviceOrientation", deviceOrientation); }
            else
            { }

            //generic Access details:
            caps.SetCapability("username", Constants.SAUCE_LABS_ACCOUNT_NAME);
            caps.SetCapability("accessKey", Constants.SAUCE_LABS_ACCOUNT_KEY);
            caps.SetCapability("name", TestContext.CurrentContext.Test.Name);
            caps.SetCapability("tunnelIdentifier", Constants.SAUCE_LABS_SPECIFIED_TUNNEL);

            //initiate remote web driver session & specfy TIMEOUTS:
            var driver = new RemoteWebDriver(commandExecutorUri, caps, TimeSpan.FromSeconds(240));
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(90));
            //driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(90));
            //driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(90));
            
            return driver;
        }


        //// Cleanup task called to tear down test and post results
        public void CleanUp(IWebDriver driver)
        {
                // Get status
                bool passed = TestContext.CurrentContext.Outcome.Status == TestStatus.Passed;
                try
                {
                    // Log the results to SauceLabs
                    ((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
                }
                finally
                {
                    // Terminate WebDriver session
                    driver.Quit();
                }
        }

    }

}