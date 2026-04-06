using AutomationFramework.Tests.TestData.Models;

namespace AutomationFramework.Tests.TestData;

public static class UserTestData
{
    public static LoginUser ValidUser() => new()
    {
        Username = "tomsmith",
        Password = "SuperSecretPassword!"
    };

    public static LoginUser InvalidUser() => new()
    {
        Username = "wrongUser",
        Password = "wrongPassword"
    };

    public static LoginUser InvalidPasswordUser() => new()
    {
        Username = "tomsmith",
        Password = "wrongPassword"
    };

    public static LoginUser EmptyUser() => new()
    {
        Username = "",
        Password = ""
    };
}