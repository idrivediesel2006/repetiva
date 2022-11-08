using Microsoft.Extensions.Logging;
using Repetiva.Models.Config;

namespace Repetiva.Pages
{
    public class Home
    {
        private readonly WebsiteSettings _websiteSettings;
        private readonly ILogger<Home> _logger;

        public bool HomePageLoadedSuccessfully()
        {
            _logger.LogInformation($"Beginning navigation to home page: {_websiteSettings.HomePageUrl}");
            return true;
        }

        public bool Search(string searchQuery)
        {
            _logger.LogInformation($"Search for {searchQuery}");
            return true;
        }

        public Home(
            WebsiteSettings websiteSettings, 
            ILogger<Home> logger)
        {
            _websiteSettings = websiteSettings;
            _logger = logger;
        }
    }
}