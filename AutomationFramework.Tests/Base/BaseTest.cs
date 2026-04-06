using AutomationFramework.Core.Config;
using AutomationFramework.Core.Drivers;
using AutomationFramework.Core.Helpers;
using AutomationFramework.Core.Logging;
using AventStack.ExtentReports;
using AutomationFramework.Reporting;
using Microsoft.Extensions.Configuration;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Serilog;

namespace AutomationFramework.Tests.Base;

public abstract class BaseTest
{
    protected IWebDriver? Driver;
    protected IConfiguration Configuration = null!;
    protected string BaseUrl = string.Empty;
    protected ILogger Logger = null!;
    protected ExtentReports Extent = null!;
    protected ExtentTest TestReport = null!;
    [SetUp]
    public void SetUp()
    {
        LoggerManager.Initialize();
        Logger = LoggerManager.GetLogger();

        Extent = ExtentReportManager.GetInstance();
        TestReport = Extent.CreateTest(TestContext.CurrentContext.Test.Name);

        Logger.Information("========== TEST START ==========");
        Logger.Information("Starting test: {TestName}", TestContext.CurrentContext.Test.Name);

        Configuration = ConfigManager.GetConfiguration();
        BaseUrl = Configuration["BaseUrl"]!;

        Logger.Information("Base URL: {BaseUrl}", BaseUrl);
        Logger.Information("Browser: {Browser}", Configuration["Browser"]);

        Driver = WebDriverFactory.Create(Configuration["Browser"]);
        Driver.Manage().Window.Maximize();

        Logger.Information("Browser started successfully");
        TestReport.Info($"Browser started: {Configuration["Browser"]}");
        TestReport.Info($"Base URL: {BaseUrl}");
    }

    [TearDown]
    public void TearDown()
    {
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        var testName = TestContext.CurrentContext.Test.Name;

        Logger.Information("Finishing test: {TestName} with status: {Status}", testName, status);

        if (status == TestStatus.Passed)
        {
            TestReport.Pass("Test passed");
        }
        else if (status == TestStatus.Failed)
        {
            var message = TestContext.CurrentContext.Result.Message;
            TestReport.Fail($"Test failed: {message}");

            if (Driver != null)
            {
                Logger.Error("Test failed. Taking screenshot for: {TestName}", testName);

                var screenshotPath = ScreenshotHelper.TakeScreenshot(Driver, testName);

                if (!string.IsNullOrWhiteSpace(screenshotPath))
                {
                    TestReport.AddScreenCaptureFromPath(screenshotPath);
                }
            }
        }
        else
        {
            TestReport.Warning($"Test finished with status: {status}");
        }

        if (Driver != null)
        {
            Driver.Quit();
            Driver.Dispose();
            Logger.Information("Browser closed");
        }

        ExtentReportManager.Flush();

        Logger.Information("=========== TEST END ===========");
        LoggerManager.CloseAndFlush();
    }
}