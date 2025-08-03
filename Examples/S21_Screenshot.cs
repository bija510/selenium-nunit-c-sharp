using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Examples
{
    [TestFixture]
    class S21_Screenshot
    {

        [Test]
        public void TakeScreenshot()
        {
            using IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");

            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
            string screenshotDir = Path.Combine(projectRoot, "Screenshots");
            Directory.CreateDirectory(screenshotDir); // Ensure folder exists

            string filePath = Path.Combine(screenshotDir, "GoogleScreenshot.png");
            screenshot.SaveAsFile(filePath);

            TestContext.WriteLine("Screenshot saved at: " + filePath);
        }


    }
}

