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

    //This class contains common actions that occur only on the differetn results screens

    public class PremiumCellMenuObjects
    {
        //new premium cell menu open takes int = cellPosition
        public void PremiumCellMenuOpenSpecified(IWebDriver driver, int cellPosition)
        {
            //Check page for the button you want and click IF found:

            IList<IWebElement> findElementOnPage = driver.FindElements(By.Id("premiumCellMenuButton"));
            if (findElementOnPage.Count > cellPosition && findElementOnPage[cellPosition].Displayed)
            {
                var optionOne = driver.FindElement(By.Id("premiumCellMenuButton"));
                new CommonSupportObjects().TabletClick(optionOne, driver);

            }
            //ELSE, you've cocked up the logic somewhere, just hit any of 'em.
            else
            {
                var optionTwo = driver.FindElement(By.Id("premiumCellMenuButton"));
                new CommonSupportObjects().TabletClick(optionTwo, driver);

            }


        }




        //COMPARISON REPORT WITH COMM
        //premiumCellOptionsReportCommission_SingleBenefit_
        public void ComparisonReportMitCom(IWebDriver driver, string quoteType, string benefitInstance)
        {
            var reportWith = driver.FindElement(By.Id("premiumCellOptionsReportCommission_" + quoteType + "_" + benefitInstance));
            new CommonSupportObjects().TabletClick(reportWith, driver);
        }

        //COMPARISON REPORT - NO COMM
        //premiumCellOptionsReportNoCommission_SingleBenefit_
        public void ComparisonReportNonCom(IWebDriver driver, string quoteType, string benefitInstance)
        {
            var reportWithout = driver.FindElement(By.Id("premiumCellOptionsReportNoCommission_" + quoteType + "_" + benefitInstance));
            new CommonSupportObjects().TabletClick(reportWithout, driver);
        }





        //QUOTE DETAILS
        //premiumCellOptionsQuoteDetails_SingleBenefit_
        public void QuoteDetailsOpen(IWebDriver driver, string quoteType, string benefitInstance)
        {
            var detailsOpen = driver.FindElement(By.Id("premiumCellOptionsQuoteDetails_" + quoteType + "_" + benefitInstance));
            new CommonSupportObjects().TabletClick(detailsOpen, driver);
        }


                //QUOTE DETAILS - WARNINGS
                //
                public void QuoteDetailsWarnings(IWebDriver driver)
                {
                    string elementId = "productDetails_ProviderWarningsChevron";
                    bool warningsPresent = new CommonSupportObjects().ElementPresentConfirmById(driver, elementId);
                    
                    if (warningsPresent == true)
                    {
                        var qdWarnings = driver.FindElement(By.Id(elementId));
                        new CommonSupportObjects().TabletClick(qdWarnings, driver);
                    }
                    else
                    {
                        //No action required
                    }

                }

                //QUOTE DETAILS - XRAE
                //
                public void QuoteDetailsXrae(IWebDriver driver)
                {
                    string elementId = "xraeRatings_ProviderWarningsChevron";
                    bool xraePresent = new CommonSupportObjects().ElementPresentConfirmById(driver, elementId);

                    if (xraePresent == true)
                    {
                        var qdXrae = driver.FindElement(By.Id(elementId));
                        new CommonSupportObjects().TabletClick(qdXrae, driver);
                    }
                    else
                    {
                        //No action required
                    }
                }


                //QUOTE DETAILS _ BENEFITS
                //Uses ElementIsPresent IN COMMON SUPPORT
                public void QuoteDetailsBenefits(IWebDriver driver)
                {
                    //Set element to use AND alternative element
                    string standardElement = "productDetails_BenefitNameChevronLG";
                    string alternativeElement = "productDetails_BenefitNameChevronXS";

                    //Locate link and click using Element Is Present validator
                    var common = new CommonSupportObjects();
                    common.ElementIsPresentClick(driver, standardElement, alternativeElement);
                }


                //QUOTE DETAILS - LITERATURE
                //
                public void QuoteDetailsLiterature(IWebDriver driver)
                {
                    var qdLit = driver.FindElement(By.Id("productDetails_ProviderLiteratureChevron"));
                    new CommonSupportObjects().TabletClick(qdLit, driver);
                }


                //QUOTE DETAILS - COMMISSION
                //
                public void QuoteDetailsCommission(IWebDriver driver)
                {
                    var qdCom = driver.FindElement(By.Id("productDetails_CommissionChevron"));
                    new CommonSupportObjects().TabletClick(qdCom, driver);
                }


                //QUOTE DETAILS - CLOSE
                //
                public void QuoteDetailsClose(IWebDriver driver)
                {
                    var qdClose = driver.FindElement(By.Id("productDetailsCloseButton"));
                    new CommonSupportObjects().TabletClick(qdClose, driver);
                }


                //QUOTE DETAILS - XRAE INFO
                //
                public void QuoteDetailsXraeInfo(IWebDriver driver)
                {
                    var xraeInfo = driver.FindElement(By.Id("xraeInfo"));
                    new CommonSupportObjects().TabletClick(xraeInfo, driver);
                }

        



        //POP OVER MENU APPLY
        //
        public void CellOptionsApply(IWebDriver driver, string quoteType, string benefitInstance)
        {
            var optionsApply = driver.FindElement(By.Id("premiumCellOptionsApply_" + quoteType + "_" + benefitInstance));
            new CommonSupportObjects().TabletClick(optionsApply, driver);
        }

    }
}
