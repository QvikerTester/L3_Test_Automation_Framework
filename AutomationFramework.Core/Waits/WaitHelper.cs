using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework.Core.Waits;

public class WaitHelper
{
    private readonly IWebDriver _driver;

    public WaitHelper(IWebDriver driver)
    {
        _driver = driver;
    }

    public IWebElement WaitForElementVisible(By locator, int timeoutInSeconds = 10)
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return wait.Until(ExpectedConditions.ElementIsVisible(locator));
    }

    public IWebElement WaitForElementClickable(By locator, int timeoutInSeconds = 10)
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
    }

    public bool WaitForUrlContains(string value, int timeoutInSeconds = 10)
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return wait.Until(driver => driver.Url.Contains(value, StringComparison.OrdinalIgnoreCase));
    }
}