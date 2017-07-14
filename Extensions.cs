using System;
using NUnit.Framework;
using Selenium;
using System.Web;
using System.Text;
using System.Net;
using System.Drawing;
using System.Security.Cryptography;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Common
{
    public static class Extensions
    {
        public static WebDriverWait WaitForUpTo(this IWebDriver driver, int seconds, string message = null)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(seconds))
            {
                Message = message
            };
        }

        public static string GetTextOfElement(this IWebDriver driver, string selector, int index = 0)
        {
            var js = (IJavaScriptExecutor)driver;
            var text = (string)js.ExecuteScript(string.Format("return $('{0}').slice({1}, {2}).text();", selector, index, index + 1));
            return text;
        }
    }



    public class AssertImage
    {
        public static void AreEqual(Bitmap expected, Bitmap actual, string message)
        {
            string asserName = "AssertImage.AreEqual";
            //Test to see if we have the same size of image
            if (expected.Size != actual.Size)
            {
                throw new InvalidOperationException(
                   asserName + " failed. Expected:<Height " + expected.Size.Height + ", Width" + expected.Size.Width +
                                 ">. Actual:<Height " + actual.Size.Height + ",Width " + actual.Size.Width + ">. " +
                                  message);
            }
            //Convert each image to a byte array
            ImageConverter ic = new ImageConverter();
            byte[] btImageExpected = new byte[1];
            btImageExpected = (byte[])ic.ConvertTo(expected, btImageExpected.GetType());
            byte[] btImageActual = new byte[1];
            btImageActual = (byte[])ic.ConvertTo(actual, btImageActual.GetType());

            //Compute a hash for each image
            var shaM = new SHA256Managed();
            byte[] hash1 = shaM.ComputeHash(btImageExpected);
            byte[] hash2 = shaM.ComputeHash(btImageActual);

            //Compare the hash values
            for (int i = 0; i < hash1.Length && i < hash2.Length; i++)
            {
                if (hash1[i] != hash2[i])
                    throw new InvalidOperationException(
                     string.Format(asserName + " failed. Expected:<hash value " + hash1[i] + ">. Actual:<hash value " + hash2[i] + ">. " +
                                   message));
            }
        }



    }
}
