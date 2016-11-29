using Example.Selenium.Framework.Browser;
using Example.Selenium.Framework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace Example.Selenium.Framework.Pages
{
    public class ExamplePage
    {
        [FindsBy(How = How.Id, Using = "lst-ib")]
        private IWebElement searchInput;

        [FindsBy(How = How.XPath, Using = "//div/h3/a[contains(.,'10 Minute Mail')]")]
        private IWebElement searchResultLink;

        [FindsBy(How = How.Id, Using = "fe_text")]
        private IWebElement emailInput;

        [FindsBy(How = How.LinkText, Using = "Wygeneruj nowy adres e-mail (obecny wygaśnie).")]
        private IWebElement generateNewEmailLink;

        public void goToExample()
        {
            Driver.webDriver.Url = Settings.baseUrl;

        }

        public void typeIntoSearch(string text)
        {
            this.searchInput.SendKeys(text);
            this.searchInput.SendKeys(Keys.Enter);
           
        }

        public void clickLinkFromSearch()
        {

            this.searchResultLink.Click();
        }

        public void clickLinkFromSearch(string text)
        {
            string locator = "//div/h3/a[contains(.,'"+text+"')]";
            IWebElement link = Driver.webDriver.FindElement(By.XPath(locator));
            link.Click();
        }

        public string getCurrentEmail()
        {
            return this.emailInput.GetAttribute("value");
        }

        public void clickGenerateNewEmail()
        {
            generateNewEmailLink.Click();
        }

        /*
         * chaining example, not used
        public ExamplePage goToLink1()
        {
            return Browser.Pages.ExamplePage;
        }

        public ExamplePage goToLink2()
        {
            return Browser.Pages.ExamplePage;
        }
        */
    }
}
