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
    public class MatrixScreenPageObjects
    {
        ////LINK TO ANY BENEFIT
        //Find and click add BENEFIT links
        public void ExitToBenefitSelectionScreen(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var exitMatrix = driver.FindElement(By.XPath(".//*[@id='matrix-quoting']/div/div/button"));
            common.TabletClick(exitMatrix, driver);

            //If spinner displayed, wait...
            while (driver.FindElement(By.Id("loadingWidget")).Displayed)
            {
                driver.WaitForUpTo(30, "Couldn't reach Benefit Summary page")
                .Until(ExpectedConditions.ElementExists(By.Id("quote-button")));
            }
        }


        ////PRINT MATRIX BUTTON
        //printMatrixButton
        public void PrintMatrix(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var printMatrix = driver.FindElement(By.Id("printMatrixButton"));
            common.TabletClick(printMatrix, driver);
        }


        ////RESET MATRIX
        //.//*[@id='matrixQuoteFixedInfoText']/button
        public void ResetMatrix(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var resetMatrix = driver.FindElement(By.XPath(".//*[@id='matrixQuoteFixedInfoText']/button"));
            common.TabletClick(resetMatrix, driver);
        }


        ////X AXIS PLUS
        //xAxisSliderPlus
        public void XaxisPlus(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var xAxisPlus = driver.FindElement(By.Id("xAxisSliderPlus"));
            common.TabletClick(xAxisPlus, driver);
        }



        ////X AXIS MINUS
        //xAxisSliderMinus
        public void XaxisMinus(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var xAxisMinus = driver.FindElement(By.Id("xAxisSliderMinus"));
            common.TabletClick(xAxisMinus, driver);
        }


        ////Y AXIS PLUS
        //yAxisSliderPlus
        public void YaxisPlus(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var yAxisPlus = driver.FindElement(By.Id("yAxisSliderPlus"));
            common.TabletClick(yAxisPlus, driver);
        }


        ////Y AXIS MINUS
        //yAxisSliderMinus
        public void YaxisMinus(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var yAxisMinus = driver.FindElement(By.Id("yAxisSliderMinus"));
            common.TabletClick(yAxisMinus, driver);
        }


        ////SELECT BUTTON
        //matrixCellSelectButton
        public void SelectButton(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var matrixSelect = driver.FindElement(By.Id("matrixCellSelectButton"));
            common.TabletClick(matrixSelect, driver);
        }


        ////READ PREMIUM
        //matrixCellPremium
        public void CheckPremium(IWebDriver driver)
        {
            //Locate link and click
            var common = new CommonSupportObjects();
            var exitMatrix = driver.FindElement(By.Id("matrixCellPremium"));
            
            //READ ELEMENT AND RETURN STRING!
            
            
            common.TabletClick(exitMatrix, driver);
        }



    }
}