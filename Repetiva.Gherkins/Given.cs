using Microsoft.Extensions.Logging;
using Repetiva.Models.Config;
using Repetiva.Pages;

namespace Repetiva.Gherkins
{
    public class Given
    {
        private readonly WebsiteSettings _websiteSettings;
        private readonly Home _home;
        private readonly ILogger<Given> _logger;

        public Given And()
        {
            return this;
        }

        public Given AUserVisitsTheHomePage()
        {
            _logger.LogInformation($"Home URL that is being visited: {_websiteSettings.HomePageUrl}");
            return this;
        }

        public Given(
            WebsiteSettings websiteSettings,
            Home home, 
            ILogger<Given> logger)
        {
            _websiteSettings = websiteSettings;
            _home = home;
            _logger = logger;
        }
    }
}