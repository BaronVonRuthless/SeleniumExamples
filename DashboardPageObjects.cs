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

namespace SolutionBuilderClientDetailsPageObjects
{
    public class DashboardPageObjects
    {

        ////LINK TO NEW CLIENT
        //Find and click Add Client link
        public void AddNewClient(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var addClient = driver.FindElement(By.Id("btnAddClient"));
            common.TabletClick(addClient, driver);

            //If spinner displayed, wait...
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "Couldn't find Title field")
                .Until(ExpectedConditions.ElementExists(By.Id("firstlifetitle")));
            }
        }


        ////LINK TO NEW QUOTE
        //Find and click New Quote link
        public void NewQuote(IWebDriver driver)
        {
            //Set element to use AND alternative element
            string standardElement = "newQuoteBtn";
            string alternativeElement = "clientSearchLastVisited_0";
            
            //Locate link and click using Element Is Present validator
            var common = new CommonSupportObjects();
            common.ElementIsPresentClick(driver, standardElement, alternativeElement);

            //If spinner displayed, wait...
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(60, "Couldn't find Benefit Summary header")
                .Until(ExpectedConditions.ElementExists(By.Id("quote-button")));
            }
        }





        ////CLIENT SEARCH INPUT
        //Client Search check and load
        public void ClientSearchInput(IWebDriver driver, string searchValue)
        {
            var searchInput = driver.FindElement(By.Id("clientSearchInput"));
            searchInput.Clear();
            searchInput.SendKeys(searchValue);
        }


        ////CLIENT SEARCH TITLE
        //Client Search check and load
        public string ClientSearchTitle(IWebDriver driver)
        {
            string displayedTitle = driver.FindElement(By.Id("resultsSearchTitle")).Text;
            return displayedTitle.Trim();
        }


        //RESULTS SELECTION
        //Click through to results screen from "recent quotes" table
        public void RecentResultsSelection(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var newQuote = driver.FindElement(By.Id("recentQuotesReturnToResultsBtn_0"));
            common.TabletClick(newQuote, driver);

            //If spinner displayed, wait...
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(60, "Results not loaded")
                .Until(ExpectedConditions.ElementExists(By.Id("resultsSummaryFullDetails")));
            }

        }



        ////LINK TO CLIENT HISTORY - FULL
        //Find and click the Client History button
        public void ClientHistoryFull(IWebDriver driver)
        {
            //Locate link and click
            var newQuote = driver.FindElement(By.Id("fullClientHistoryBtn"));
            newQuote.Click();

            //If spinner displayed, wait...
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "Page not reached?")
                .Until(ExpectedConditions.ElementExists(By.Id("client-history")));
            }

        }


        ////LINK TO CLIENT HISTORY - FLAGGED
        //Find and click the Client History button
        public void ClientHistoryFlagged(IWebDriver driver)
        {
            //Locate link and click
            var newQuote = driver.FindElement(By.Id("dashboardLikesPanelViewDetails"));
            newQuote.Click();

            //If spinner displayed, wait...
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "Page not loaded/filter not set")
                .Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='likedFilterMenuOption']/span[1]")));
            }
        }


        ////LINK TO CLIENT HISTORY - EXPIRE
        //Find and click the Client History button
        public void ClientHistoryExpire(IWebDriver driver)
        {
            //Locate link and click
            var newQuote = driver.FindElement(By.Id("dashboardExpiringPanelViewDetails"));
            newQuote.Click();

            //If spinner displayed, wait...
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "Page not loaded/filter not set")
                .Until(ExpectedConditions.ElementExists(By.XPath(".//*[@id='aboutToExpireFilterMenuOption']/span[1]")));
            }
        }


        //or find .//*[@id='client-history']/hidden/div/div/div/div/h4 with inner text "There are no existing quotes for this client."

    }
}