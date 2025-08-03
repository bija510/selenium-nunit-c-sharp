using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Examples
{
    [TestFixture]
    class S02_refreshForwardBack
    {
        IWebDriver driver = new ChromeDriver();
        [Test]
        public void NavigationCommands()
        {
            driver.Url = "https://www.facebook.com";
            Thread.Sleep(2000);
            driver.Navigate().Refresh();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//a[normalize-space()='Forgot Password?']")).Click();
            Thread.Sleep(2000);
            driver.Navigate().Back();
            Thread.Sleep(2000);
            driver.Navigate().Forward();
        }
    }
}
