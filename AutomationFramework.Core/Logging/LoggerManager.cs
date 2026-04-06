using Serilog;

namespace AutomationFramework.Core.Logging;

public static class LoggerManager
{
    private static bool _isInitialized;

    public static void Initialize()
    {
        if (_isInitialized)
        {
            return;
        }

        var projectPath = GetProjectRootPath();
        var logsPath = Path.Combine(projectPath, "TestResults", "Logs");

        Directory.CreateDirectory(logsPath);

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File(
                Path.Combine(logsPath, "automation-.log"),
                rollingInterval: RollingInterval.Day,
                outputTemplate:
                "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        _isInitialized = true;
    }

    public static ILogger GetLogger()
    {
        if (!_isInitialized)
        {
            Initialize();
        }

        return Log.Logger;
    }

    public static void CloseAndFlush()
    {
        Log.CloseAndFlush();
        _isInitialized = false;
    }

    private static string GetProjectRootPath()
    {
        var baseDir = AppDomain.CurrentDomain.BaseDirectory;
        var projectPath = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.FullName;

        return projectPath ?? baseDir;
    }
}