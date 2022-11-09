using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using Repetiva.Extensions;
using Repetiva.Gherkins;
using Repetiva.Models.Config;

namespace Repetiva.ConsoleApp
{
    public class Worker
    {
        private readonly IWebDriver _webDriver;
        private readonly Given _given;
        private readonly When _when;
        private readonly Then _then;
        private readonly ProgramSettings _programSettings;
        private readonly BrowserSettings _browserSettings;
        private readonly ILogger<Worker> _logger;

        private void Initialize()
        {
            _logger.LogInformation($"Moving browser to appropriate screen position");
            if(_browserSettings.XOffset > 0 || _browserSettings.YOffset > 0)
            {
                _logger.LogInformation($"Browser will be moved to position X-{_browserSettings.XOffset} & Y-{_browserSettings.YOffset}");
                _webDriver.Manage().Window.Position = new System.Drawing.Point(_browserSettings.XOffset, _browserSettings.YOffset);
            }

            if(_browserSettings.Maximize)
            {
                _logger.LogInformation($"Browser will be maximized according to settings found in {nameof(BrowserSettings)}");
                _webDriver.Manage().Window.Maximize();
            }
            
            // By default we wait 60 seconds for a page to load when looking for an element
            // However, if the page loads sooner and the element is found the element is returned before.
            // If this is not working you can try the extention method:
            // Repetiva.Extensions.WebDriverExtensions.WaitUntilElementExists()
            // If the extension method still doesn't work you can try an explicit wait (Thread.Sleep())
            // There is an extension method that automatically does that for you in the WebDriverExtensions.
            if(_browserSettings.WaitTimeInSeconds > 0)
                _webDriver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(_browserSettings.WaitTimeInSeconds);
        }

        private void CleanUp()
        {
            _logger.LogInformation("Performing cleanup");

            _logger.LogInformation("Quiting browser");
            _webDriver.Quit();

            _logger.LogInformation("Disposing web driver");
            _webDriver.Dispose();
        }

        private void Search()
        {
            _given
                .AUserVisitsTheHomePage();
            _when
                .AUserSearches("selenium");
            _then
                .TheResultWillHave("https://www.selenium.dev");
        }

        public void Run()
        {
            _logger.LogInformation($"{nameof(Worker)} is executing the {nameof(Run)} method in the {_programSettings.Environment} environment.");
            Initialize();
            Search();

            // The search is so fast that we need to put an implicit wait here
            // Remove if when it's not in demo.
            _webDriver.Wait();

            CleanUp();
        }

        public Worker(
            IWebDriver webDriver,
            Given given,
            When when,
            Then then,
            ProgramSettings programSettings, 
            BrowserSettings browserSettings, 
            ILogger<Worker> logger)
        {
            _webDriver = webDriver;
            _given = given;
            _when = when;
            _then = then;
            _programSettings = programSettings;
            _browserSettings = browserSettings;
            _logger = logger;
        }
    }
}
