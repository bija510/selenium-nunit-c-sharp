using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace C_Sharp_Selenium_NUnit.BaseClass
{

    internal class BaseTest
    {
        // Base class for tests, providing a setup and teardown for the WebDriver
        protected IWebDriver? driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
        }
    }
}