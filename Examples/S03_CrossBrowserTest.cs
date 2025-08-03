using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace C_Sharp_Selenium_NUnit.Examples
{
    [TestFixture]
    public class S03_CrossBrowserTest
    {
        private IWebDriver driver;

        [Test]
        public void ChromeTest()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
        }

        [Test]
        public void FirefoxTest()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.amazon.com/");
        }

        [Test]
        public void EdgeTest()
        {
            // Make sure the latest msedgedriver.exe matching your Edge version is present in PATH or output folder

            var edgeOptions = new EdgeOptions();
            driver = new EdgeDriver(edgeOptions); // or pass specific path if needed
            driver.Navigate().GoToUrl("https://www.walmart.com/");
        }

        [TearDown]
        public void Close()
        {
            Thread.Sleep(3000); // for demo purposes only, avoid in real test runs
            driver?.Quit();
        }
    }
}
