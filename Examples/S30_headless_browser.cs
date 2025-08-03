using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Examples
{
    [TestFixture]
    class S30_headless_browser
    {

        [Test]
        public static void headLessMethod()
        {
            //ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--headless");
            //IWebDriver driver = new ChromeDriver(options);

            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--headless");
            IWebDriver driver = new FirefoxDriver(options);

            driver.Navigate().GoToUrl("https://www.google.com");
            Console.WriteLine(driver.Title);

        }
    }
}
