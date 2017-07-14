namespace Common
{
    internal static class Constants
    {

        //********************************************************************************
        //*****   VALUES USED TO CONTROL THE ENVIRONMENT UNDER TEST - HAVE AT 'EM!   *****
        //********************************************************************************

        //SaDe or Live Base URL:
        internal const string ENV = "www";
        
        //EXT Base URL:
        //internal const string ENV = "ext";

        //Username & Password:
        internal const string USERNAME = "ncollins";
        internal const string PASSWORD = "choir1234Jensen";

        //Specified Tunnel (Comment as required):
            //*****EXT TUNNEL*****
            //internal const string SAUCE_LABS_SPECIFIED_TUNNEL = "";    
                //*****SADE TUNNEL*****
                internal const string SAUCE_LABS_SPECIFIED_TUNNEL = "tunnel-v4.4.4-SaDe"; // ---> MUST be used for Android tests in EXT/LIVE due to forced security exception.
                    //*****NON SADE TUNNEL*****
                    //internal const string SAUCE_LABS_SPECIFIED_TUNNEL = "tunnel-v4.3.4-NonSaDe";
        
        



        //*********************************************************************************
        //*****   FIXED VALUES BELOW THIS LINE - DON'T GO CHANGIN' 'EM WILLY-NILLY!   *****
        //*********************************************************************************

        //Account Variables:
        internal const string EMAIL = "ncollins@ipipeline.com";
        internal const string FCA = "408285";
        // - this is Openworks FCA number, used for access to the Registration Page

        //SauceLabs account details:
        internal const string SAUCE_LABS_ACCOUNT_NAME = "ipipelineuk";
        internal const string SAUCE_LABS_ACCOUNT_KEY = "badd14c1-a5e6-414b-a273-310213f73254";

        //Other environment variables: 
        internal const string BASEURL = "https://" + ENV + ".ipipeline.uk.com/";
        internal const string TITLE = "iPipeline Login";

        ////Fixed screen messages
        //Dialogue pop-up validation text:
        internal const string BENEFIT = "If you select OK your benefit details will be lost.";
        internal const string CLIENT = "If you select OK your client details will be lost.";
        internal const string CHANGES = "If you select OK your changes will be lost.";
        internal const string LOGOUT = "Are you sure you want to log out?";
        internal const string DELETE = "If you select OK the benefit details will be deleted.";

        //LifeQuote pop-up validation text:
        internal const string LQ_CONTACT = "In order to complete your LifeQuote registration please contact LifeQuote on 0800 6529705.";
        internal const string LQ_PRODUCT = "";
        internal const string LQ_SERVICE = "";
        internal const string LQ_UNAVAILABLE = ""; 
        internal const string LQ_DECLINED = "Your LifeQuote registration has been declined. Please contact LifeQuote on 0800 6529705."; 

        ////Benefit Values for Quotes
        //LTA Quote
        internal const string ltaTERMYEARS = "15";
        internal const string ltaTERMVALUE = "150000";

        //DTA Quote
        internal const string dtaTERMYEARS = "15";
        internal const string dtaTERMVALUE = "150000";

        //FIB Quote
        internal const string fibTERMYEARS = "10";
        internal const string fibCICVALUE = "12000";

        //IP Quote
        internal const string ipBENEFITAMOUNT = "500";

        //WOL Quote
        internal const string wolSUMASSURED = "50000";

        //BP Quote
        internal const string bpTERMYEARS = "10";
        internal const string bpTERMVALUE = "250000";

    }
}