using Serilog;
namespace MVC.Extentions;
public static class LoggerExtentions
{
    public static void LoggerConfigure(this ILoggingBuilder logging, ConfigurationManager config)
    {
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(config)
            .Enrich.FromLogContext()
            .CreateLogger();

        logging.ClearProviders();
        logging.AddSerilog(logger);
    }
}