using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using C_Sharp_Selenium_NUnit.Config;
using C_Sharp_Selenium_NUnit.Data;
using OpenQA.Selenium.Chrome;
using Newtonsoft.Json;


namespace C_Sharp_Selenium_NUnit.BaseClass
{
    public class BaseTest
    {
        protected IWebDriver? Driver;
        protected static TestData pd;


        //TestProfile = POCO – Plain Old CLR Object) that define to match the structure of your JSON config file.
        protected static readonly TestProfile Config = ConfigReader.Load();
        private string environment = Config.Environment;       
        private string browser = Config.Browser;

        protected string baseUrl = Config.BaseUrl;
        protected string userName = Config.UserName;
        protected string password = Config.Password;

        // Load the test data from TestData.json
        

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            TestContext.WriteLine($"[OneTimeSetUp] Environment: {environment}");
            TestContext.WriteLine($"[OneTimeSetUp] Base URL: {baseUrl}");
            TestContext.WriteLine($"[OneTimeSetUp] Browser: {browser}");

            var testDataReader = TestDataReader.Load();
            pd = testDataReader.pd;

        }

        [SetUp]
        public void Setup()
        {
            
            switch (browser.ToLower())
            {
                case "chrome":
                    var chromedriverManager = new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    Driver = new ChromeDriver();
                    break;

                case "edge":
                    var edgeDriverManager = new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    Driver = new EdgeDriver();
                    
                    break;

                case "firefox":
                    var firefoxDriverManager = new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    Driver = new FirefoxDriver();
                    break;

                default:
                    Assert.Fail("Unsupported browser: " + browser);
                    break;
            }
            
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [SETUP] Driver initialized for: {browser}");

            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            Log($"[Setup] Page load timeout set to 30 seconds.");

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Log($"[Setup] Implicit wait set to 10 seconds.");

            Driver.Manage().Window.Maximize();
            Log($"[Setup] Browser window maximized.");
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


                //Driver?.Quit();
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