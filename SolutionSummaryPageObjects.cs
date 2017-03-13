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

namespace SolutionBuilderQuoteDetailsPageObjects
{
    public class SolutionSummaryPageObjects
    {

        ////OPEN SOLUTION SUMMARY
        //CLick the highltighted folder button to open summary
        public void OpenSolutionSummary(IWebDriver driver)
        {
            //Locate link and click
            string standardElement = "toggleSolutionSummary";
            string alternativeElement = "singleProviderLikeButton";
            new CommonSupportObjects().ElementIsPresentClick(driver, standardElement, alternativeElement);
        }

        //SUMMARY CLOSE
        //
        public void SummaryClose(IWebDriver driver)
        {
            var summaryClose = driver.FindElement(By.Id("solutionSummaryCloseButton"));
            new CommonSupportObjects().TabletClick(summaryClose, driver);
        }


        //SUMMARY SAVE FOR LATER
        //
        public void SummarySaveForLater(IWebDriver driver)
        {
            var saveLater = driver.FindElement(By.Id("solutionSummarySaveChangesButton"));
            new CommonSupportObjects().TabletClick(saveLater, driver);
        }

        //SUMMARY DELETE
        //
        public void SummaryDeleteEntry(IWebDriver driver, string listInstnace)
        {
            var deleteEntry = driver.FindElement(By.Id("removeSolution_" + listInstnace));
            new CommonSupportObjects().TabletClick(deleteEntry, driver);
        }
        

        ////APPLY FIRST IN LIST
        //CLick the Apply link for the first product in the list
        public void ClickFirstApply(IWebDriver driver, string listInstnace)
        {
            //Locate link and click
            var firstProduct = driver.FindElement(By.Id("apply_solution_" + listInstnace + "_product_" + listInstnace));
            new CommonSupportObjects().TabletClick(firstProduct, driver);
        }


        //PRODUCT COUNT IN BADGE - INTERNAL SUMMARY
        //Returns an INT of the current product count
        public int SummaryInternalGetCount(IWebDriver driver)
        {
            string retrieveInnerText = driver.FindElement(By.Id("solutionSummaryHeadingBadge")).Text.Trim();
            int productCount = Int32.Parse(retrieveInnerText);

            return productCount;
        }


        //PRODUCT COUNT IN BADGE - EXTERNAL TAB
        //Returns an INT of the current product count
        public int SummaryExternalGetCount(IWebDriver driver)
        {
            string retrieveInnerText = driver.FindElement(By.Id("solutionCountBadge")).Text.Trim();
            int productCount = Int32.Parse(retrieveInnerText);

            return productCount;
        }



        //***************************************************************************//
        //                           APPLICATION PACKS POP-UP                        //
        //***************************************************************************//

        //GET APPLICATION PACK
        //Select Application Pack and Launch Pop-Up
        public void SummaryGetApplicationPack(IWebDriver driver, int solutionInstance)
        {
            var getPack = driver.FindElement(By.Id("applicationPack_" + solutionInstance));
            new CommonSupportObjects().TabletClick(getPack, driver);
        }

        //CLOSE APPLICATION PACK POP-UP
        //Select close button (tablet clicker, no validation dialogue)
        public void SummaryCloseApplicationPack(IWebDriver driver)
        {
            var closeAppPack = driver.FindElement(By.Id("applicationPackClose"));
            new CommonSupportObjects().TabletClick(closeAppPack, driver);
        }

        //CHECK STATUS OF APPLICATION PACK - KEY FEATURES
        //Timer stack; wait on positive results for all three returns
        public bool SummaryValidateApplicationPack(IWebDriver driver, int waitTime, string documentType, string testText)
        {
            new CommonSolutionBuilderPageObjects().SpecifiedWait(driver, waitTime, documentType);
            
            //Validate against input string:
            string innerText = driver.FindElement(By.Id(documentType)).Text.Trim();
            bool resultsText = (innerText == testText);

            return resultsText;
        }

        //READ SUMMARY TEXT APPLICATION PACK
        //Read and return string containing inner text of Status Information
        public string SummaryReadTextApplicationPack(IWebDriver driver)
        {
            return driver.FindElement(By.Id("applicationPackStatusInformation")).Text.Trim();
        }

        //DOWNLOAD APPLICATION PACK
        //Select "download" option - UNRECOVERABLE ACTION
        public void SummaryDownloadApplicationPack(IWebDriver driver)
        {
            var getPack = driver.FindElement(By.Id("applicationPackDownloadButton"));
            new CommonSupportObjects().TabletClick(getPack, driver);
        }



    }
}