using Microsoft.Extensions.Configuration;
using Repetiva.Models.Config;

namespace Repetiva.Models
{
    public static class ConfigHelper
    {
        public static BrowserSettings? BrowserSettings { get; set; } = new BrowserSettings();
        public static ProgramSettings? ProgramSettings { get; set; } = new ProgramSettings();

        static ConfigHelper()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            config.GetSection(nameof(BrowserSettings)).Bind(BrowserSettings);
            config.GetSection(nameof(ProgramSettings)).Bind(ProgramSettings);
        }
    }
}
