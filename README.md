# 🚀 Test Automation Framework (.NET + Selenium)

## 📌 Overview

This project is a **modular, scalable test automation framework** built using **.NET, Selenium, and NUnit**.
It is designed with **clean architecture principles**, strong separation of concerns, and real-world usability in mind.

The framework supports **UI and API testing**, centralized configuration, structured logging, reporting, and reusable components.

---

## 🧱 Architecture

```
AutomationFramework/
├── AutomationFramework.Core        # Core utilities and infrastructure
├── AutomationFramework.UI          # Page Objects and UI interactions
├── AutomationFramework.API         # API clients and models
├── AutomationFramework.Reporting   # Reporting (ExtentReports)
├── AutomationFramework.Tests       # Test layer
```

---

## ⚙️ Tech Stack

* **Language:** C# (.NET 8)
* **Test Framework:** NUnit
* **UI Automation:** Selenium WebDriver
* **Assertions:** FluentAssertions
* **Reporting:** ExtentReports
* **Configuration:** Microsoft.Extensions.Configuration
* **Logging:** Serilog (or custom LoggerManager)

---

## 🧩 Design Principles

The framework follows:

* **Separation of Concerns**
* **Single Responsibility Principle (SRP)**
* **Reusable and maintainable components**
* **Scalability for large test suites**

---

## 🧠 Design Patterns Used

### 1. Page Object Model (POM)

Encapsulates UI elements and actions inside page classes.

```
LoginPage.cs
```

---

### 2. Factory Pattern

Used for WebDriver initialization.

```
WebDriverFactory.cs
```

Allows dynamic browser selection:

```csharp
Driver = WebDriverFactory.Create("chrome");
```

---


### 4. Singleton Pattern

Used in:

* Configuration Manager
* Report Manager

Ensures single instance across framework lifecycle.

---

### 5. Base Test Pattern

Centralized setup and teardown logic.

```
BaseTest.cs
```

Handles:

* Driver lifecycle
* Configuration
* Logging
* Reporting

---

## 📁 Core Components

### 🔹 Config

Loads environment-specific settings from `appsettings.json`

### 🔹 Drivers

WebDriver initialization and browser handling

### 🔹 Helpers

Reusable utilities:

* ScreenshotHelper
* WaitHelper

### 🔹 Logging

Centralized logging across tests

### 🔹 Reporting

ExtentReports integration with:

* Pass/Fail status
* Logs
* Screenshots

---

## 🧪 Test Layer

```
AutomationFramework.Tests
├── Base/        # BaseTest setup
├── UI/          # UI tests
├── TestData/    # Test data models & builders
```

---

## 🧬 Test Data Management

Instead of hardcoding data in tests, we use:

```
UserTestData.cs
LoginUser.cs
```

Example:

```csharp
var user = UserTestData.ValidUser();
loginPage.Login(user);
```

---

## 📊 Reporting

* HTML reports generated via **ExtentReports**
* Includes:

  * Test status
  * Error messages
  * Screenshots on failure

Location:

```
TestResults/Reports/
```

---

## 📸 Screenshot Handling

* Automatically captured on test failure
* Stored in:

```
TestResults/Screenshots/
```

* Attached to report

---

## 🧾 Logging

* Structured logs generated per test
* Helps debugging failures

Location:

```
TestResults/Logs/
```

---

## 🧪 Example Test

```csharp
[Test]
public void ValidUserShouldLoginSuccessfully()
{
    var loginPage = new LoginPage(Driver);
    var user = UserTestData.ValidUser();

    loginPage.Open(BaseUrl);
    loginPage.Login(user);

    loginPage.GetMessage()
        .Should()
        .Contain("You logged into a secure area!");
}
```

---


## 🚀 How to Run

```bash
dotnet test
```

Run specific category:

```bash
dotnet test --filter "Category=Smoke"
```

---

## 📦 Git Ignore

Excluded:

* `.vs`
* `bin/`
* `obj/`
* `TestResults/`

---


## 🎯 Summary

This framework demonstrates:

✔ Clean architecture
✔ Reusable components
✔ Real-world test design
✔ Strong separation of concerns
✔ Scalability for enterprise projects

---

## 👨‍💻 Author

Demetre — QA Automation Engineer
