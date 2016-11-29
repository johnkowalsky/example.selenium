using System;
using OpenQA.Selenium.Chrome;

namespace Example.Selenium.Framework.Utilities
{
    public static class Settings
    {
        //used to get settings from TeamCity, configure browser from CI
        public static String[] arguments = Environment.GetCommandLineArgs();
        internal static readonly string chromeDriverPath = @"C:\chromedriver\";

        public static string baseUrl { get { return "http://google.com"; } }
        public static TimeSpan implicitWaitTimeout { get { return TimeSpan.FromSeconds(30); } }

    }
}
