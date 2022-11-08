using Microsoft.Extensions.Logging;
using Repetiva.Models.Config;

namespace Repetiva.ConsoleApp
{
    public class Worker
    {
        private readonly ProgramSettings _programSettings;
        private readonly ILogger<Worker> _logger;

        public void Run()
        {
            _logger.LogInformation($"{nameof(Worker)} is executing the {nameof(Run)} method in the {_programSettings.Environment} environment.");
        }

        public Worker(ProgramSettings programSettings, ILogger<Worker> logger)
        {
            _programSettings = programSettings;
            _logger = logger;
        }
    }
}
