using C_Sharp_Selenium_NUnit.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Test_Cases
{
    [TestFixture]
    class S21_Screenshot : BaseTest1
    {
        [Test]
        public void demo()
        {
            driver.Url = "https://www.google.com";
            OpenQA.Selenium.ITakesScreenshot ts = driver as ITakesScreenshot;
            Screenshot screenshot = ts.GetScreenshot();
            screenshot.SaveAsFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..")) + "\\Screenshot\\" + "TestScreensot" + ".png", ScreenshotImageFormat.Png);
        }
    }
}

