using C_Sharp_Selenium_NUnit.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace C_Sharp_Selenium_NUnit.Examples
{
    [TestFixture]
    internal class S13_Frame
    {
        private IWebDriver? driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void Demo()
        {
            driver.Navigate().GoToUrl("https://www.letskodeit.com/practice");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,1200)");

            // Wait for the iframe to be present, then switch to it
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("courses-iframe")));

            // Wait for the search box inside iframe to be visible and enabled
            IWebElement searchBox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("search")));
            Thread.Sleep(3000);
            searchBox.SendKeys("Python");

            // Switch back to the main page
            driver.SwitchTo().DefaultContent();

            js.ExecuteScript("window.scrollBy(0,-1000)");

            // Wait for the name box and type into it
            IWebElement nameBox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("name")));
            nameBox.SendKeys("Robert");
        }
    }
}
