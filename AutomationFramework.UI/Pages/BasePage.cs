using AutomationFramework.Core.Waits;
using OpenQA.Selenium;

namespace AutomationFramework.UI.Pages;

public abstract class BasePage
{
    protected readonly IWebDriver Driver;
    protected readonly WaitHelper WaitHelper;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        WaitHelper = new WaitHelper(driver);
    }

    protected void Click(By locator)
    {
        WaitHelper.WaitForElementClickable(locator).Click();
    }

    protected void Type(By locator, string text)
    {
        var element = WaitHelper.WaitForElementVisible(locator);
        element.Clear();
        element.SendKeys(text);
    }

    protected string GetText(By locator)
    {
        return WaitHelper.WaitForElementVisible(locator).Text;
    }
}