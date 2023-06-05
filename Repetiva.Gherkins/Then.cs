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
            if (!_home.FindInResults("https://www.selenium.dev/"))
                throw new Exception($"The method {nameof(TheResultWillHave)} has failed to render the expected results.");

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
