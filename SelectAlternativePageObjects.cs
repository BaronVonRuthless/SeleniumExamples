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
    public class SelectAlternativePageObjects
    {
        
        //SELECT ALTERNATIVE - OPEN FROM MENU
        //premiumCellOptionsAlternative_SingleProvider_MB
        public void SelectAlternativeOpenMenu(IWebDriver driver, string quoteType, string benefitInstance)
        {
            var selectAlternativeMenu = driver.FindElement(By.Id("premiumCellOptionsAlternative_" + quoteType + "_" + benefitInstance));
            new CommonSupportObjects().TabletClick(selectAlternativeMenu, driver);
        }



        //SELECT ALTERNATIVE _ OPEN FROM ICON
        //premiumCellComparisonAlternatives_SingleBenefit_
        public void SelectAlternativeOpenIcon(IWebDriver driver, string quoteType, string benefitInstance)
        {
            var selectAlternativeIcon = driver.FindElement(By.Id("premiumCellComparisonAlternatives_" + quoteType + "_" + benefitInstance));
            new CommonSupportObjects().TabletClick(selectAlternativeIcon, driver);
        }



        //SELECT ALTERNATIVE - SELECT
        //Use 1-99 to select required product (default of "1") eg. selectProductButton_1
        public void SelectAlternativeSelect(IWebDriver driver, int productInTable)
        {
            var commonObjects = new CommonSupportObjects();

            if (productInTable >0)
            {
                //Original, simple method:
                //var buttonClick = driver.FindElement(By.Id("selectProductButton_" + productInTable));
                //commonObjects.TabletClick(buttonClick, driver);

                //Inserted variable selector to cope with SR51 workstreams (new SelectAlternative page):
                string standardElement = "selectProductButton_" + productInTable;
                string alternativeElement = "quote-results-quote-button_" + productInTable;
                commonObjects.ElementIsPresentClick(driver, standardElement, alternativeElement);
            }
            else
            {
                //Original, simple method:
                //var buttonClick = driver.FindElement(By.Id("selectProductButton_1"));
                //commonObjects.TabletClick(buttonClick, driver);

                //Inserted variable selector to cope with SR51 workstreams (new SelectAlternative page):
                string standardElement = "selectProductButton_1";
                string alternativeElement = "quote-results-quote-button_1";
                commonObjects.ElementIsPresentClick(driver, standardElement, alternativeElement);
            }

            string pageValidator = "resultsSummaryBenefitAndClientDetails";
            new CommonSolutionBuilderPageObjects().GenericWait(driver, pageValidator);
        }


        //SELECT ALTERNATIVE - EXPAND
        //   .//*[@id='selectProductRow_1']/div[1]/h4/a/div/div[6]/span OR selectProductRow
        public void SelectAlternativeExpandRow(IWebDriver driver, int productInTable)
        {
            var expandRow = driver.FindElement(By.XPath(".//*[@id='selectProductRow_" + productInTable + "']/div[1]"));
            new CommonSupportObjects().TabletClick(expandRow, driver);
        }

            //SELECT ALTERNATIVE - XRAE INFO BUTTON
            //
            public void SelectAlternativeXRAEInfo(IWebDriver driver)
            {
                var xraeInfo = driver.FindElement(By.Id("xraeInfo"));
                new CommonSupportObjects().TabletClick(xraeInfo, driver);
            }


        //SELECT ALTERNATIVE - CLOSE
        //
        public void SelectAlternativeClose(IWebDriver driver)
        {
            var alternativeClose = driver.FindElement(By.Id("premiumCellResultsClose"));
            new CommonSupportObjects().TabletClick(alternativeClose, driver);
        }


        //SELECT ALTERNATIVE - XRAE
        //
        public void XRAEUnderwritingSelect(IWebDriver driver)
        {
            var underwritingSelect = driver.FindElement(By.Id("xraeUnderwriting"));
            new CommonSupportObjects().TabletClick(underwritingSelect, driver);
            string pageValidator = "xraeLifeDetails";
            new CommonSolutionBuilderPageObjects().SpinnerWait(driver, pageValidator);
        }


        //SELECT ALTERNATIVE - PNQ
        //
        public void ProvidersNotQuotingSelect(IWebDriver driver)
        {
            var notQuoting = driver.FindElement(By.Id("premiumCellDialogToProvidersNotQuoting"));
            new CommonSupportObjects().TabletClick(notQuoting, driver);

            string pageValidator = "providersNotQuotingModalBody";
            new CommonSolutionBuilderPageObjects().SpinnerWait(driver, pageValidator);
        }

        

        //***************************************************************************//
        //              SR51 Select Alternative SCREEN - Rewrite Project             //
        //***************************************************************************//

        //SELECT ALTERNATIVE - CLOSE - SR51
        //
        public void SelectAlternativeCloseSR51(IWebDriver driver)
        {
            var alternativeClose = driver.FindElement(By.Id("backToBenefitsButton"));
            new CommonSupportObjects().TabletClick(alternativeClose, driver);
        }


        //SELECT ALTERNATIVE - ALL PREMIUM TYPES - SR51
        //
        public void SelectAlternativeFilterAllSR51(IWebDriver driver)
        {
            var filterAll = driver.FindElement(By.Id("filterAll"));
            new CommonSupportObjects().TabletClick(filterAll, driver);
        }


        //SELECT ALTERNATIVE - GUARANTEED ONLY - SR51
        //
        public void SelectAlternativeFilterGuaranteedSR51(IWebDriver driver)
        {
            var filterGuaranteed = driver.FindElement(By.Id("filterGuaranteed"));
            new CommonSupportObjects().TabletClick(filterGuaranteed, driver);
        }

        //SELECT ALTERNATIVE - REVIEWABLE ONLY - SR51
        //
        public void SelectAlternativeFilterReviewableSR51(IWebDriver driver)
        {
            var filterReviewable = driver.FindElement(By.Id("filterReviewable"));
            new CommonSupportObjects().TabletClick(filterReviewable, driver);
        }

        //SELECT ALTERNATIVE - AGE BANDED ONLY - SR51
        //
        public void SelectAlternativeFilterAgeBandedSR51(IWebDriver driver)
        {
            var filterAgeBandedOnly = driver.FindElement(By.Id("filterAgeBandedOnly"));
            new CommonSupportObjects().TabletClick(filterAgeBandedOnly, driver);
        }

        //SELECT ALTERNATIVE - LIMITED PAYMENT ONLY - SR51
        //
        public void SelectAlternativeFilterLimitedPaymenSR51(IWebDriver driver)
        {
            var filterLimitedPaymentPlanOnly = driver.FindElement(By.Id("filterLimitedPaymentPlanOnly"));
            new CommonSupportObjects().TabletClick(filterLimitedPaymentPlanOnly, driver);
        }


        //SELECT ALTERNATIVE - PNQ SR51
        //
        public void ProvidersNotQuotingSelectSR51(IWebDriver driver)
        {
            var notQuoting = driver.FindElement(By.Id("providersNotQuotingResultsCount"));
            //premium-cell-not-quoted
            new CommonSupportObjects().TabletClick(notQuoting, driver);

            string pageValidator = "backToBenefitsButton";
            new CommonSolutionBuilderPageObjects().SpinnerWait(driver, pageValidator);
        }

        //SELECT ALTERNATIVE - QUOTE RESULTS SR51
        //
        public void ProvidersQuotingSelectSR51(IWebDriver driver)
        {
            var providersQuoting = driver.FindElement(By.Id("quoteResultsCount"));
            //quote-results-badge
            new CommonSupportObjects().TabletClick(providersQuoting, driver);

            string pageValidator = "backToBenefitsButton";
            new CommonSolutionBuilderPageObjects().SpinnerWait(driver, pageValidator);
        }

        //PNQ - EXPAND/HIDE DETAILS SECTION
        //expandPnqRow_0
        public void ProvidersNotQuotingExpandDetailsSR51(IWebDriver driver, int rowInstance)
        {
            var expandDetails = driver.FindElement(By.Id("expandPnqRow_" + rowInstance));
            new CommonSupportObjects().TabletClick(expandDetails, driver);

            string pageValidator = "backToBenefitsButton";
            new CommonSolutionBuilderPageObjects().SpinnerWait(driver, pageValidator);
        }
        


    }
}