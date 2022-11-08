using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repetiva.ConsoleApp;
using Repetiva.Models.Config;
using Serilog;

IHostBuilder _hostBuilder = Host
    .CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, configuration) =>
    {
        configuration.Sources.Clear();
        configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        configuration.AddCommandLine(args);

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration.Build())
            .Enrich.FromLogContext()
            .CreateLogger();

        Log.Logger.Information("Application Starting...");
    })
    .ConfigureServices((context, services) =>
    {
        // ProgramSettings
        services.AddSingleton(serviceProvider =>
        {
            ProgramSettings programSettings = new ProgramSettings();
            context.Configuration.Bind(nameof(ProgramSettings), programSettings);
            return programSettings;
        });

        // BrowerSettings
        services.AddSingleton(serviceProvider =>
        {
            BrowserSettings browserSettings = new BrowserSettings();
            context.Configuration.Bind(nameof(BrowserSettings), browserSettings);
            return browserSettings;
        });

        // WebsiteSettings
        services.AddSingleton(serviceProvider =>
        {
            WebsiteSettings websiteSettings = new WebsiteSettings();
            context.Configuration.Bind(nameof(WebsiteSettings), websiteSettings);
            return websiteSettings;
        });
    })
    .UseSerilog();

IHost _host = _hostBuilder.Build();
Worker _worker = ActivatorUtilities.CreateInstance<Worker>(_host.Services);
_worker.Run();
