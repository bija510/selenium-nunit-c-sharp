using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace C_Sharp_Selenium_NUnit.Examples
{
    [TestFixture]
    public class S01_openCloseBrowser
    {
        private IWebDriver? driver;

        [SetUp]
        public void SetUp()
        {
            // Safely initialize driver before each test
            driver = new ChromeDriver();
        }

        [Test]
        public void openClose()
        {
            // The null-conditional operator (?.) avoids exception if driver is unexpectedly null
            driver?.Navigate().GoToUrl("https://www.google.com/");
            Console.WriteLine("Opened Google");
        }

        [Test]
        public void openClose2()
        {
            driver?.Navigate().GoToUrl("https://www.facebook.com");
            Console.WriteLine("Opened Facebook");
        }

        [TearDown]
        public void TearDown()
        {
            // Close the browser after each test
            driver?.Quit();
        }
    }
}
