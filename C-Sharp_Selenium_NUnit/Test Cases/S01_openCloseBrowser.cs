using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Test_Cases
{
    [TestFixture]
    class S01_openCloseBrowser
    {
        //NOTE: AUTO_FORMAT = CTRL + K FOLLOWED BY F

        IWebDriver driver = new ChromeDriver();
        [Test]
        public void openClose()
        {
            
            driver.Navigate().GoToUrl("https://www.google.com/");
        }

        [Test]
        public void openCLose2()
        {
            driver.Url = "https://www.facebook.com";
        }
    }
}
