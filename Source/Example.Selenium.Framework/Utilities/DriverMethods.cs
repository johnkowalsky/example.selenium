using Example.Selenium.Framework.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Drawing.Imaging;
using System.Threading;


namespace Example.Selenium.Framework.Utilities
{
    using OpenQA.Selenium.Chrome;

    public static class DriverMethods
    {
        public static void TakeScreenshotOnException(object sender, WebDriverExceptionEventArgs e)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-hhmm-ss");
            Driver.webDriver.TakeScreenshot().SaveAsFile("Exception-" + timestamp + ".png", ImageFormat.Png);
        }

        public static IWebDriver getDriverType()
        {
            //use directives to configure diffrent instances of browsers
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("test-type");
            options.AddArgument(@"--incognito");
            options.AddArgument("start-maximized");
            return new ChromeDriver(Settings.chromeDriverPath, options);
        }

        public static bool checkElementExists(By by)
        {
            try
            {
                return Driver.webDriver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static IJavaScriptExecutor javaScripts(this IWebDriver driver)
        {
            return (IJavaScriptExecutor)driver;
        }

        public static bool isAlertPresent()
        {
            try
            {
                Driver.webDriver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException Ex)
            {
                return false;
            }
        }

        //method not removed as disucsses about
        public static bool waitForWebElementToLoad(By element, int timeToWait)
        {
            //wait until data shows up after upload
            var counter = 0;
            var elementAppeared = false;
            while (!elementAppeared)
            {
                counter++;

                try
                {
                    Driver.webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(150));
                    IWebElement searchedElement = Driver.webDriver.FindElement(element);
                    Driver.webDriver.Manage().Timeouts().ImplicitlyWait(Settings.implicitWaitTimeout);
                    elementAppeared = searchedElement.Displayed;
                    if (elementAppeared)
                    {
                        return true;
                    }
                }
                catch (NoSuchElementException)
                {
                    elementAppeared = false;
                }

                if (counter > timeToWait * 2)
                {
                    return false;
                }
            }

            return elementAppeared;
        }

        public static void moveToElement(IWebElement element)
        {
            //wait for animations
            Thread.Sleep(500);
            Actions moveToElement = new Actions(Driver.webDriver);
            Driver.implicitWait();
            moveToElement.MoveToElement(element).Build().Perform();
            Thread.Sleep(500);
        }
    }
}
