using Example.Selenium.Framework.Pages;
using OpenQA.Selenium.Support.PageObjects;

namespace Example.Selenium.Framework.Browser
{
    public static class Pages
    {
        public static ExamplePage ExamplePage
        {
            get
            {
                var examplePage = new ExamplePage();
                PageFactory.InitElements(Driver.Browser, examplePage);
                return examplePage;
            }
        }
    }
}
