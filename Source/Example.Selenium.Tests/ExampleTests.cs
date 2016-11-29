using Example.Selenium.Framework.Browser;
using Example.Selenium.Framework.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.Events;

namespace Example.Selenium.Tests
{
    [TestClass]
    public class ExampleTests
    {
        [TestInitialize]
        public void Initialize()
        {
            var screensotDriver = new EventFiringWebDriver(DriverMethods.getDriverType());
            screensotDriver.ExceptionThrown += DriverMethods.TakeScreenshotOnException;
            Driver.webDriver = screensotDriver;

        }

        [TestMethod]
        public void LoadExampleShouldSuccess()
        {
            //arrange
            Driver.implicitWait();
            string searchText = "site: 10minutemail";
            string resultLink = "10 Minute Mail";
            string pageTitle = "10-minutowy Mail - 10 Minute Mail";
            string previousEmail = "";
            string newEmail = "";

            //act
            Pages.ExamplePage.goToExample();
            Pages.ExamplePage.typeIntoSearch(searchText);
            Pages.ExamplePage.clickLinkFromSearch(resultLink);

            previousEmail = Pages.ExamplePage.getCurrentEmail();
            Pages.ExamplePage.clickGenerateNewEmail();
            newEmail = Pages.ExamplePage.getCurrentEmail();

            //assert
            Assert.IsTrue(Driver.getPageTitle == pageTitle);
            Assert.IsFalse(previousEmail == newEmail);
        }

        [ClassCleanup]
        public static void teardown()
        {
            Driver.quit();
        }
    }
}
