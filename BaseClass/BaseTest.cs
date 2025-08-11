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
        private string environment = Config.Environment;
        private string browser = Config.Browser.ToUpper();

        protected string baseUrl = Config.BaseUrl;
        protected string userName = Config.UserName;
        protected string password = Config.Password;


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

            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
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
            var fullTestName = TestContext.CurrentContext.Test.FullName;
            var testMethodName = TestContext.CurrentContext.Test.Name;
            var testOutcome = TestContext.CurrentContext.Result.Outcome.Status;
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

            switch (status)
            {
                case NUnit.Framework.Interfaces.TestStatus.Passed:
                    test?.Pass("Test passed");
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    test?.Fail(errorMessage);
                    test?.Fail(stackTrace);
                    break;
                default:
                    test?.Skip("Test skipped or inconclusive");
                    break;
            }

            Log($"Test finished: {testMethodName} with status {testOutcome}");




            if (testOutcome == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test?.Fail("Test Failed: " + errorMessage);
                test?.Fail(stackTrace);

                try
                {
                    string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
                    string screenshotDir = Path.Combine(projectRoot, "Screenshots");
                    Directory.CreateDirectory(screenshotDir);

                    string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    string screenshotPath = Path.Combine(screenshotDir, $"{testMethodName}_{timestamp}.png");

                    Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                    screenshot.SaveAsFile(screenshotPath);

                    Log($"Screenshot saved to: {screenshotPath}");

                    // Add screenshot to report
                    test?.AddScreenCaptureFromPath(screenshotPath);
                }
                catch (Exception ex)
                {
                    Log($"Failed to take screenshot: {ex.Message}");
                }
            }
            else if (testOutcome == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                test?.Pass("Test Passed");
            }
            else
            {
                test?.Skip("Test Skipped or Inconclusive");
            }

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
