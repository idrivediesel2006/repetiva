using Microsoft.Extensions.Logging;
using Repetiva.Gherkins;
using Repetiva.Models.Config;

namespace Repetiva.ConsoleApp
{
    public class Worker
    {
        private readonly ProgramSettings _programSettings;
        private readonly BrowserSettings _browserSettings;
        private readonly Given _given;
        private readonly When _when;
        private readonly Then _then;
        private readonly ILogger<Worker> _logger;

        private void Initialize()
        {
            _logger.LogInformation($"Moving browser to appropriate screen position");
            if(_browserSettings.XOffset > 0 || _browserSettings.YOffset > 0)
            {
                _logger.LogInformation($"Browser will be moved to position X-{_browserSettings.XOffset} & Y-{_browserSettings.YOffset}");
            }

            if(_browserSettings.Maximize)
            {
                _logger.LogInformation($"Browser will be maximized according to settings found in {nameof(BrowserSettings)}");
            }
        }

        private void CleanUp()
        {
            _logger.LogInformation("Performing cleanup");

            _logger.LogInformation("Quiting browser");

            _logger.LogInformation("Disposing web driver");
        }

        private void Search()
        {
            _given
                .AUserVisitsTheHomePage();
            _when
                .AUserSearches("repetiva");
            _then
                .TheResultWillHave("https://github.com/idrivediesel2006/repetiva");
        }

        public void Run()
        {
            _logger.LogInformation($"{nameof(Worker)} is executing the {nameof(Run)} method in the {_programSettings.Environment} environment.");
            Initialize();
            Search();
            CleanUp();
        }

        public Worker(
            ProgramSettings programSettings, 
            BrowserSettings browserSettings, 
            Given given,
            When when,
            Then then,
            ILogger<Worker> logger)
        {
            _programSettings = programSettings;
            _browserSettings = browserSettings;
            _given = given;
            _when = when;
            _then = then;
            _logger = logger;
        }
    }
}
