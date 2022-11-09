using Microsoft.Extensions.Logging;
using Repetiva.Pages;

namespace Repetiva.Gherkins
{
    public class When
    {
        private readonly Home _home;
        private readonly ILogger<When> _logger;

        public When And()
        {
            return this;
        }

        public When AUserSearches(string searchQuery)
        {
            _logger.LogInformation($"Performing a search for '{searchQuery}'");
            if (!_home.Search(searchQuery))
                throw new Exception($"The method {nameof(AUserSearches)} has failed to produce the correct results");

            return this;
        }

        public When(
            Home home, 
            ILogger<When> logger)
        {
            _home = home;
            _logger = logger;
        }
    }
}
