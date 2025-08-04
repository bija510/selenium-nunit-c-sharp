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

namespace C_Sharp_Selenium_NUnit.BaseClass
{
    public class BaseTest
    {
        protected IWebDriver? driver;

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
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "edge":
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;

                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                default:
                    Assert.Fail("Unsupported browser: " + browser);
                    break;
            }

            WebUI.OpenBrowser(driver);
            WebUI.SetDefaultTimeout(10);
            WebUI.MaximizeWindow();
        }
        

        [TearDown]
        public void AfterTestMethod()
        {
            var fullTestName = TestContext.CurrentContext.Test.FullName;
            var testMethodName = TestContext.CurrentContext.Test.Name;
            var testOutcome = TestContext.CurrentContext.Result.Outcome;

            Console.WriteLine($"[TearDown] Full Test Name: {fullTestName}");
            Console.WriteLine($"[TearDown] Method Name: {testMethodName}");
            Console.WriteLine($"[TearDown] Test Outcome: {testOutcome}");

            if (!(testOutcome.ToString() == "Passed"))
            {
                Console.WriteLine("[TearDown] Test failed or had issues - capturing screenshot...");
                WebUI.TakeScreenshot(testMethodName);
            }

            WebUI.Delay(2);
            WebUI.CloseBrowser();
        }

        [OneTimeTearDown]
        public void TearDownEach()
        {
            Console.WriteLine("This will executed only at the End");
        }

    }
}