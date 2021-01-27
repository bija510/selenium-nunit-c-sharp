using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit
{
    [TestFixture]
    public class Try_Catch_finally
    {
        public IWebDriver driver = null;
        [Test]
        public void TestMethod1()
        {
            try
            {
                driver = new ChromeDriver();
                driver.Url = "https://www.facebook.com";
                IWebElement firstName = driver.FindElement(By.XPath("//input[@id='u_0_m'"));
                firstName.SendKeys("david2");
                driver.Quit();
                Thread.Sleep(2000);
            }
            catch(Exception e)
            {
                ITakesScreenshot ts = driver as ITakesScreenshot;
                Screenshot screenshot = ts.GetScreenshot();
                screenshot.SaveAsFile("C:\\Users\\Bijaya Chhetri\\Documents\\Selenium-C#\\C-Sharp_Selenium_NUnit\\C-Sharp_Selenium_NUnit\\Screenshot\\s2.png", ScreenshotImageFormat.Png);
                Console.WriteLine(e.StackTrace);
                throw;

            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();

                }
            }
        }
    }
}