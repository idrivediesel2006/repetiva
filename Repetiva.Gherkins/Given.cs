using Microsoft.Extensions.Logging;
using Repetiva.Models.Config;
using Repetiva.Pages;

namespace Repetiva.Gherkins
{
    public class Given
    {
        private readonly Home _home;
        private readonly ILogger<Given> _logger;

        public Given And()
        {
            return this;
        }

        public Given AUserVisitsTheHomePage()
        {
            _logger.LogInformation("Given a user visits the home page");
            if (!_home.HomePageLoadedSuccessfully())
                throw new Exception("Failed to load page");
            return this;
        }

        public Given(
            Home home, 
            ILogger<Given> logger)
        {
            _home = home;
            _logger = logger;
        }
    }
}