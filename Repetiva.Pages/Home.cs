using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using Repetiva.Extensions;
using Repetiva.Models.Config;

namespace Repetiva.Pages
{
    public class Home
    {
        private readonly IWebDriver _webDriver;
        private readonly WebsiteSettings _websiteSettings;
        private readonly ILogger<Home> _logger;

        public bool HomePageLoadedSuccessfully()
        {
            _webDriver.Navigate().GoToUrl(_websiteSettings.HomePageUrl);
            IWebElement searchInputText = _webDriver.FindElement(By.TagName("form"));
            if (searchInputText != null)
                return true;
            else
                return false;
        }

        public bool Search(string searchQuery)
        {
            _logger.LogInformation($"Search for {searchQuery}");

            // Find the form
            IWebElement searchForm = _webDriver.FindElement(By.TagName("form"));

            // Find the text box and type something
            IWebElement searchText = searchForm.FindElement(By.TagName("input"));
            searchText.SendKeys(searchQuery);

            // Find the submit button and click it
            IWebElement submit = searchForm.FindElement(By.XPath(".//*[@value='Google Search']"));
            submit.Click();

            // Wait for the results to appear
            IWebElement results = _webDriver.WaitUntilElementExists(By.Id("search"));
            if (results != null)
                return true;
            else
                return false;
        }

        public bool FindInResults(string resultString)
        {
            _logger.LogInformation($"Inspecting page for: {resultString}");
            IWebElement searchInputText = _webDriver.FindElement(By.XPath($"//*[text()='{resultString}']"));
            if (searchInputText != null)
                return true;
            else
                return false;
        }

        public Home(
            IWebDriver webDriver,
            WebsiteSettings websiteSettings, 
            ILogger<Home> logger)
        {
            _webDriver = webDriver;
            _websiteSettings = websiteSettings;
            _logger = logger;
        }
    }
}