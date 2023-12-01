using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Task_Logging.Interface;


class Program : ILogLevelControl
{
    static void Main(string[] args)
    {
        //I use ServiceCollection to configure services.
        var serviceCollection = new ServiceCollection();

        //Color-coded console output.
        serviceCollection.AddLogging(configure => configure.AddConsole());

        //I used a singleton because no matter how many times I request an instance of that class, it will always show me the same instance
        serviceCollection.AddSingleton<ILogLevelControl, Program>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        //Create an instance of the ILogger<Program>
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();


        var logLevelControl = serviceProvider.GetRequiredService<ILogLevelControl>();

        // Set log level to Debug 
        logLevelControl.SetLogLevel(LogLevel.Debug);

        // Log messages with different levels
        LogMessages(logger);

        // Set log level to Warning
        logLevelControl.SetLogLevel(LogLevel.Warning);

        LogMessages(logger);
    }

    private static void LogMessages(ILogger<Program> logger)
    {
        logger.LogDebug("This is a Debug message.");
        logger.LogInformation("This is an Information message.");
        logger.LogWarning("This is a Warning message.");
        logger.LogError("This is an Error message.");
        logger.LogCritical("This is a Critical message.");

        Console.WriteLine(); 
    }

    private LogLevel currentLogLevel = LogLevel.Information;

    public void SetLogLevel(LogLevel logLevel)
    {
        currentLogLevel = logLevel;
    }
}
