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

    //This class contains actions relating to USER MANAGEMENT BY ENVIRONMENT. You're welcome.

    public class Users
    {
        ////GENERATE "RANDOM" USERNAME & PASSWORD FROM LIST...
        public string RandomUsername()
        {
            var thisPage = new Users();
            string seconds = thisPage.ReturnTensOfSecondsAsString();
            string rndUserName = thisPage.ReturnUserName(seconds);

            return rndUserName;
        }


        ////...USING THESE HELPER CLASSES
        public string ReturnUserName(string seconds)
        {
            List<string> usernames = new List<string>();
            usernames.Add("ncollins");
            usernames.Add("coneill");
            usernames.Add("MKHOLWADIA");
            usernames.Add("jpoulton");
            usernames.Add("hravi");
            usernames.Add("RMARCER");
            usernames.Add("cjones");
            usernames.Add("sfrewer");
            usernames.Add("kweller");
            usernames.Add("obowden");


            string[] array = {"ncollins", "ncollinsSadeX"};






            int number = Int32.Parse(seconds);

            string rndUser = usernames[number].ToString();
            return rndUser;
        }

        ///Return Time in Seconds (single unit)
        public string ReturnTensOfSecondsAsString()
        {
            System.DateTime getSystemTime = DateTime.UtcNow;
            //string time = getSystemTime.ToString("HH:mm:ss");
            string time = getSystemTime.ToString("ss");
            //string timeTrimEnd = time.TrimEnd(time[time.Length - 1]);
            //string seconds = timeTrimEnd.TrimStart(timeTrimEnd[timeTrimEnd.Length - 8]);
            string seconds = time.TrimStart(time[time.Length - 2]);

            return seconds;
        }



    }
}
