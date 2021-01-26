using C_Sharp_Selenium_NUnit.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Test_Cases
{
    [TestFixture]
    class S13_Frame : BaseTest1
    {
        [Test]
        public void demo()
        {
            driver.Url = "https://letskodeit.teachable.com/pages/practice";

            IJavaScriptExecutor JS = (IJavaScriptExecutor)driver;
            JS.ExecuteScript("window.scrollBy(0,1200)");

            // Switch inside the page inside page called frame
            driver.SwitchTo().Frame("courses-iframe");
            IWebElement searchBox = driver.FindElement(By.Id("search-courses"));
            searchBox.SendKeys("python");
            Thread.Sleep(2000);

            // Switch back to default page
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(2000);
            JS.ExecuteScript("window.scrollBy(0,-1000)");
            driver.FindElement(By.Id("name")).SendKeys("Robert");
        }
    }
}