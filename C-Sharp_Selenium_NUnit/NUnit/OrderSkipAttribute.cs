using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit
{
    /******************************************
    * Always clean solution and Rebuild solution
    * taskkill /f /im chromedriver.exe -->C:\Users\Bijaya Chhetri\eclipse-workspace\subi\Driver
    * taskkill /f /im IEDriverServer.exe
    * taskkill /f /im geckodriver.exe
    *******************************************/
    [TestFixture]
    class OrderAndSkipAttribute
    {
        [Test, Order(2), Category("OrderAndSkipAttribute")]
        public void TestMethod1()
        {
            Assert.Ignore("Open Bug");//This is how we Skip Method
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.facebook.com";
            IWebElement firstName = driver.FindElement(By.XPath("//input[@id='u_0_m']"));
            firstName.SendKeys("david2");
            driver.Close();
            Thread.Sleep(2000);
        }
        [Test, Order(1),Category("OrderAndSkipAttribute")] //Start from 0
        public void TestMethod2()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://www.facebook.com";
            IWebElement firstName = driver.FindElement(By.XPath("//input[@id='u_0_m']"));
            firstName.SendKeys("david2");
            driver.Close();
            Thread.Sleep(2000);
        }
        [Test, Order(0), Category("OrderAndSkipAttribute")]
        public void TestMethod3()
        {
            IWebDriver driver = new InternetExplorerDriver();
            driver.Url = "https://www.facebook.com";
            IWebElement firstName = driver.FindElement(By.XPath("//input[@id='u_0_m']"));
            firstName.SendKeys("david2");
            driver.Close();
            Thread.Sleep(2000);
        }
    }
}
