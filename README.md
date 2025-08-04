# Selenium NUnit C# Automation Framework

A lightweight yet powerful Selenium automation framework built with C# and NUnit, designed to be flexible, maintainable, and easy to extend. This framework supports environment-based configurations, reusable UI interaction methods (via a Katalon-style wrapper), logging, and automatic screenshot capture on test failure.

---

## 🚀 Features

- ✅ **Selenium WebDriver + NUnit Integration**
- 🧱 **Modular TestBase** setup with config-driven initialization
- 🌐 **Environment-specific profiles** via `testSettings.json`
- 🔁 **BC.Selenium.Wrapper**: WebUI-style reusable actions
- 📝 **Automatic logging** of user actions
- 📸 **Screenshot capture** on test failures
- 🔍 Easy-to-read, maintainable test code

---

## 🛠 Project Structure
```
selenium-nunit-c-sharp/
├── BaseClass/
│ └── BaseTest.cs # Global setup, teardown, and WebDriver init
│
├── Config/
│ ├── ConfigReader.cs # Loads config based on active environment
│ └── testSettings.json # Environment-based browser/baseUrl setup
│
├── Wrapper/
│ └── WebUI.cs # Custom wrapper methods like Click, Type, etc.
│ └── Utils.cs # general-purpose reusable utility.
│
├── Examples/
│
├── PageObjects/
│
├── Tests/
│ └── DemoTest.cs # Sample test using the BC.Selenium.Wrapper
│
├── Screenshots/
│
├── Reports/

```
## 🔠 Naming Conventions

| Element          | Convention    | Example               |
|------------------|---------------|-----------------------|
| File Name        | PascalCase.cs | `LoginTest.cs`        |
| Folder Name      | PascalCase    | `PageObjects`         |
| Class Name       | PascalCase   | `AuthService`         |
| Method Name      | PascalCase   | `GetUserInfo()`       |
| Variable Name    | camelCase    | `userEmail`           |
| Property Name    | PascalCase   | `UserEmail`           |
| Constant Name    | PascalCase   | `MaxRetries`          |
| Boolean Name     | camelCase    | `isLoggedIn`          |
| Test Method Name | PascalCase   | `ShouldLoginSuccessfully()` |



## ⚙️ Configuration

### testSettings.json

```json
{
    "Environment": "QA" ,
    "BaseUrl"    : "https://demo.automationtesting.in/Register.html",
    "Browser"    : "chrome"
}

```

## 🧪 Writing Tests
```csharp
[Test]
public void SampleLoginTest()
{
    WebUI.OpenUrl("https://example.com/login");
    WebUI.Type(By.Id("username"), "admin");
    WebUI.Type(By.Id("password"), "pass123");
    WebUI.Click(By.Id("loginBtn"));
    WebUI.VerifyElementPresent(By.Id("dashboard"));
}
```
> ✅ All wrapper methods auto-log and handle exceptions cleanly.

## 📸 Screenshot on Failure
- Screenshots are saved under /Reports/Screenshots/ with a timestamped filename.
- Automatically triggered from TearDown() if test fails.

## ▶️ Running Tests
You can run the tests using Visual Studio Test Explorer or via CLI:
```bash
dotnet test
```
> Optional: You can also pass config profile via CLI using environment variable override or update testSettings.json.

## 📦 NuGet Packages Used
- BC.WebUlWrapper (O.O.1-alpha)
- DotNetSeleniumExtras.WaitHelpers (3.11.0)
- Microsoft.NET.Test.Sdk (17.14.1)
- Microsoft.Office.lnterop.Excel (15.0.4795.1001)
- Newtonsoft.Json (13.0.3)
- NIJnit (4.3.2)
- NUnit3TestAdapter (5.0.0)
- Selenium.Support (4.34.0)
- Selenium.WebDriver (4.34.0)
- WebDriverManager (2.17.6)

## 👥 Author
Bijay Chhetri
🔗 github.com/bija510
