using AutomationFramework.Tests.TestData.Models;
using OpenQA.Selenium;

namespace AutomationFramework.UI.Pages;

public class LoginPage : BasePage
{
    private readonly By _username = By.Id("username");
    private readonly By _password = By.Id("password");
    private readonly By _loginBtn = By.CssSelector("button[type='submit']");
    private readonly By _message = By.Id("flash");

    public LoginPage(IWebDriver driver) : base(driver) { }

    public void Open(string url)
    {
        Driver.Navigate().GoToUrl(url);
    }

    public void Login(LoginUser user)
    {
        Type(_username, user.Username);
        Type(_password, user.Password);
        Click(_loginBtn);
    }

    public string GetMessage()
    {
        return GetText(_message);
    }
}