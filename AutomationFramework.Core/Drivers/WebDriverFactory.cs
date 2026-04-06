using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace AutomationFramework.Core.Drivers;

public static class WebDriverFactory
{
    public static IWebDriver Create(string? browser)
    {
        return browser?.ToLower() switch
        {
            "chrome" => new ChromeDriver(),
            "firefox" => new FirefoxDriver(),
            "edge" => new EdgeDriver(),
            _ => throw new ArgumentException($"Unsupported browser: {browser}")
        };
    }
}