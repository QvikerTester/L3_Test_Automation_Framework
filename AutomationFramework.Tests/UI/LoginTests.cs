using AutomationFramework.Tests.Base;
using AutomationFramework.Tests.TestData;
using AutomationFramework.UI.Pages;
using FluentAssertions;

namespace AutomationFramework.Tests.UI;

[TestFixture]
public class LoginTests : BaseTest
{
    [Test]
    [Category("Smoke")]
    public void ValidUserShouldLoginSuccessfully()
    {
        var loginPage = new LoginPage(Driver!);
        var validUser = UserTestData.ValidUser();

        loginPage.Open(BaseUrl);
        loginPage.Login(validUser);

        loginPage.GetMessage()
            .Should()
            .Contain("You logged into a secure area!");
    }

    [Test]
    [Category("Regression")]
    public void InvalidUserShouldNotLogin()
    {
        var loginPage = new LoginPage(Driver!);
        var user = UserTestData.InvalidUser();

        loginPage.Open(BaseUrl);
        loginPage.Login(user);

        loginPage.GetMessage()
            .Should()
            .Contain("Your username is invalid!");
    }

    [Test]
    [Category("Regression")]
    public void InvalidPasswordShouldNotLogin()
    {
        var loginPage = new LoginPage(Driver!);
        var user = UserTestData.InvalidPasswordUser();

        loginPage.Open(BaseUrl);
        loginPage.Login(user);

        loginPage.GetMessage()
            .Should()
            .Contain("Your password is invalid!");
    }

    [Test]
    [Category("Regression")]
    public void EmptyCredentialsShouldNotLogin()
    {
        var loginPage = new LoginPage(Driver!);
        var user = UserTestData.EmptyUser();

        loginPage.Open(BaseUrl);
        loginPage.Login(user);

        loginPage.GetMessage()
            .Should()
            .Contain("Your username is invalid!");
    }
}