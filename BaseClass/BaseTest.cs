using BC.Selenium.WebUI;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Firefox;
using C_Sharp_Selenium_NUnit.Config;
using System;
using OpenQA.Selenium.BiDi.Communication;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;


namespace C_Sharp_Selenium_NUnit.BaseClass
{
    public class BaseTest
    {
        protected IWebDriver? Driver;

        //TestProfile = POCO – Plain Old CLR Object) that define to match the structure of your JSON config file.
        protected static readonly TestProfile Config = ConfigReader.Load();
        private string environment = Config.Environment;
        protected string baseUrl = Config.BaseUrl;
        private string browser = Config.Browser;


        [OneTimeSetUp]
        public void GlobalSetup()
        {
            TestContext.WriteLine($"[OneTimeSetUp] Environment: {environment}");
            TestContext.WriteLine($"[OneTimeSetUp] Base URL: {baseUrl}");
            TestContext.WriteLine($"[OneTimeSetUp] Browser: {browser}");
        }

        [SetUp]
        public void Setup()
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");
                    chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal; // Normal / Eager
                    Driver = new ChromeDriver(chromeOptions);
                    break;

                case "edge":
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("--start-maximized");
                    Driver = new EdgeDriver(edgeOptions);
                    break;

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("--start-maximized");
                    break;

                default:
                    Assert.Fail("Unsupported browser: " + browser);
                    break;
            }
        }
        

        [TearDown]
        public void TearDown()
        {
            var fullTestName = TestContext.CurrentContext.Test.FullName;
            var testMethodName = TestContext.CurrentContext.Test.Name;
            var testOutcome = TestContext.CurrentContext.Result.Outcome.Status;

            Console.WriteLine($"[TearDown] {DateTime.Now:HH:mm:ss} Full Test Name: {fullTestName}");
            Console.WriteLine($"[TearDown] {DateTime.Now:HH:mm:ss} Method Name: {testMethodName}");
            Console.WriteLine($"[TearDown] {DateTime.Now:HH:mm:ss} Test Outcome: {testOutcome.ToString().ToUpper()}");

            // Only log error details if test failed
            if (testOutcome == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var errorMessage = TestContext.CurrentContext.Result.Message;
                var stackTrace = TestContext.CurrentContext.Result.StackTrace;

                Console.WriteLine($"[TearDown] ❌ Test Failed: {errorMessage}");
                Console.WriteLine($"[TearDown] 🔍 Stack Trace: {stackTrace}");

                try
                {
                    string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
                    string screenshotDir = Path.Combine(projectRoot, "Screenshots");
                    Directory.CreateDirectory(screenshotDir); // Ensure the folder exists

                    string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    string screenshotPath = Path.Combine(screenshotDir, $"{testMethodName}_{timestamp}.png");

                    Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                    screenshot.SaveAsFile(screenshotPath);
                    Console.WriteLine($"[TearDown] 📸 Screenshot saved to: {screenshotPath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[TearDown][ERROR] Failed to take screenshot: {ex.Message}");
                }
            }

            // Cleanup driver
            try
            {
                Driver?.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TearDown][ERROR] Failed to quit driver: {ex.Message}");
            }
        }


        private void Log(string message)
        {
            Console.WriteLine($"[WebUI] {DateTime.Now:HH:mm:ss} - {message}");
        }

        [OneTimeTearDown]
        public void TearDownEach()
        {
            Console.WriteLine("This will executed only at the End");
        }

    }
}