using Microsoft.Extensions.Logging;
using Repetiva.Pages;

namespace Repetiva.Gherkins
{
    public class Then
    {
        private readonly Home _home;
        private readonly ILogger<Then> _logger;

        public Then And()
        {
            return this;
        }

        public Then TheResultWillHave(string searchQuery)
        {
            _logger.LogInformation($"Check to see if the search result includes: {searchQuery}");
            return this;
        }

        public Then(
            Home home, 
            ILogger<Then> logger)
        {
            _home = home;
            _logger = logger;
        }
    }
}
