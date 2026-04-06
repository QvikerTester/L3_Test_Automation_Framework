using OpenQA.Selenium;

namespace AutomationFramework.Core.Helpers;

public static class ScreenshotHelper
{
    public static string TakeScreenshot(IWebDriver driver, string testName)
    {
        try
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            var projectPath = GetProjectRootPath();
            var folderPath = Path.Combine(projectPath, "TestResults", "Screenshots");

            Directory.CreateDirectory(folderPath);

            var fileName = $"{SanitizeFileName(testName)}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            var filePath = Path.Combine(folderPath, fileName);

            screenshot.SaveAsFile(filePath);

            Console.WriteLine($"[Screenshot] Saved to: {filePath}");
            return filePath;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Screenshot ERROR] {ex.Message}");
            return string.Empty;
        }
    }

    private static string GetProjectRootPath()
    {
        var baseDir = AppDomain.CurrentDomain.BaseDirectory;
        var projectPath = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.FullName;

        return projectPath ?? baseDir;
    }

    private static string SanitizeFileName(string name)
    {
        foreach (var c in Path.GetInvalidFileNameChars())
        {
            name = name.Replace(c, '_');
        }

        return name;
    }
}