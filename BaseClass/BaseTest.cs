using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using C_Sharp_Selenium_NUnit.Config;
using C_Sharp_Selenium_NUnit.Data;
using OpenQA.Selenium.Chrome;
using Newtonsoft.Json;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using WebDriverManager.Helpers;
using WebDriverManager;
using System.Runtime.Intrinsics.X86;

namespace C_Sharp_Selenium_NUnit.BaseClass
{
    public class BaseTest
    {
        protected IWebDriver? Driver;
        protected static TestData? pd;
        protected ExtentReports? extent;
        protected ExtentTest? test;

        //TestProfile = POCO – Plain Old CLR Object) that define to match the structure of your JSON config file.
        protected static readonly TestProfile Config = ConfigReader.Load();
        private string environment = Config.Environment!;
        private string browser = Config.Browser!.ToUpper();

        protected string baseUrl = Config.BaseUrl!;
        protected string userName = Config.UserName!;
        protected string password = Config.Password!;


        [OneTimeSetUp]
        public void GlobalSetup()
        {
            // Get shared instance
            extent = ExtentReportManager.GetInstance(browser, environment);

            TestContext.WriteLine($"[OneTimeSetUp] Environment: {environment}");
            TestContext.WriteLine($"[OneTimeSetUp] Base URL: {baseUrl}");
            TestContext.WriteLine($"[OneTimeSetUp] Browser: {browser}");

            var testDataReader = TestDataReader.Load();
            pd = testDataReader.pd;

        }

        [SetUp]
        public void Setup()
        {
            // Create a test node in ExtentReports for each test

            //give full name in report  "C_Sharp_Selenium_NUnit.Tests.LoginTest.Login" (ProjectNamespace.FolderName.ClassName.MethodName)
            test = extent?.CreateTest(TestContext.CurrentContext.Test.FullName);

            // Link WebUI wrapper logs to Extent test
            BC.Selenium.WebUI.WebUI.ExtentLogger = msg => test?.Info(msg);

            switch (browser.ToLower())
            {
                case "chrome":
                    // WebDriverManager downloaded a ChromeDriver v139, but your installed Chrome browser v138 mismatch 
                    // System.InvalidOperationException : session not created:
                    //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

                    // ✔️ Best practice:
                    // Use VersionResolveStrategy.MatchingBrowser in WebDriverManager so you avoid this mismatch (v138-chromedriver and v139-browser) without pinning or manual updates.
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    Driver = new ChromeDriver();
                    break;

                case "edge":
                    //new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig(), VersionResolveStrategy.MatchingBrowser);
                    Driver = new EdgeDriver();

                    break;

                case "firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    Driver = new FirefoxDriver();
                    break;

                default:
                    Assert.Fail("Unsupported browser: " + browser);
                    break;
            }


            Log($"Driver initialized for: {browser}");

            Driver!.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            Log($"Page load timeout set to 30 seconds.");

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Log($"Implicit wait set to 10 seconds.");

            Driver.Manage().Window.Maximize();
            Log($"Browser window maximized.");

            test?.Info($"Browser {browser} launched and configured");
        }


        [TearDown]
        public void TearDown()
        {
            var testMethodName = TestContext.CurrentContext.Test.Name;
            var testOutcome = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

            switch (testOutcome)
            {
                case NUnit.Framework.Interfaces.TestStatus.Passed:
                    test?.Pass(AventStack.ExtentReports.MarkupUtils.MarkupHelper
                        .CreateLabel("PASSED", AventStack.ExtentReports.MarkupUtils.ExtentColor.Green));
                    break;

                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    test?.Fail(errorMessage)
                        .Fail(stackTrace)
                        .Fail(AventStack.ExtentReports.MarkupUtils.MarkupHelper
                            .CreateLabel("FAILED", AventStack.ExtentReports.MarkupUtils.ExtentColor.Red));

                    try
                    {
                        string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
                        // string screenshotDir = Path.Combine(projectRoot, "Screenshots"); // Due to github page live report failed scripts screenshot image crash.
                        string screenshotDir = Path.Combine(projectRoot, "Reports");
                        Directory.CreateDirectory(screenshotDir);

                        string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                        string screenshotPath = Path.Combine(screenshotDir, $"{testMethodName}_{timestamp}.png");

                        Screenshot screenshot = ((ITakesScreenshot)Driver!).GetScreenshot();
                        screenshot.SaveAsFile(screenshotPath);

                        Log($"Screenshot saved to: {screenshotPath}");

                        // Attach screenshot in report
                        test?.AddScreenCaptureFromPath(screenshotPath);
                    }
                    catch (Exception ex)
                    {
                        Log($"Failed to take screenshot: {ex.Message}");
                    }
                    break;

                default:
                    test?.Skip(AventStack.ExtentReports.MarkupUtils.MarkupHelper
                        .CreateLabel("SKIPPED / INCONCLUSIVE", AventStack.ExtentReports.MarkupUtils.ExtentColor.Orange));
                    break;
            }

            Log($"Test finished: {testMethodName} with status {testOutcome}");

            // Cleanup driver
            try
            {
                Driver?.Quit();
                Log("Driver quit successfully");
            }
            catch (Exception ex)
            {
                Log($"Failed to quit driver: {ex.Message}");
            }
        }


        private void Log(string message)
        {
            Console.WriteLine($"[WebUI] {DateTime.Now:HH:mm:ss} - {message}");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ExtentReportManager.Flush();
            Log("ExtentReports flushed");
        }

    }
}
