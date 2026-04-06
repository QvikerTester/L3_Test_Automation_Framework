using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace AutomationFramework.Reporting;

public static class ExtentReportManager
{
    private static ExtentReports? _extent;
    private static ExtentSparkReporter? _sparkReporter;
    private static string _reportPath = string.Empty;

    public static ExtentReports GetInstance()
    {
        if (_extent != null)
        {
            return _extent;
        }

        var projectPath = GetProjectRootPath();
        var reportsFolder = Path.Combine(projectPath, "TestResults", "Reports");
        Directory.CreateDirectory(reportsFolder);

        _reportPath = Path.Combine(reportsFolder, $"ExtentReport_{DateTime.Now:yyyyMMdd_HHmmss}.html");

        _sparkReporter = new ExtentSparkReporter(_reportPath);
        _sparkReporter.Config.DocumentTitle = "Automation Framework Report";
        _sparkReporter.Config.ReportName = "UI Automation Test Results";

        _extent = new ExtentReports();
        _extent.AttachReporter(_sparkReporter);

        _extent.AddSystemInfo("Framework", ".NET + NUnit + Selenium");
        _extent.AddSystemInfo("Environment", "QA");
        _extent.AddSystemInfo("OS", Environment.OSVersion.ToString());

        return _extent;
    }

    public static void Flush()
    {
        _extent?.Flush();
    }

    public static string GetReportPath()
    {
        return _reportPath;
    }

    private static string GetProjectRootPath()
    {
        var baseDir = AppDomain.CurrentDomain.BaseDirectory;
        var projectPath = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.FullName;

        return projectPath ?? baseDir;
    }
}