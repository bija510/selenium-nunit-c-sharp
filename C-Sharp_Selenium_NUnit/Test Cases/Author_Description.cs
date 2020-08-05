using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit
{  //taskkill /f /im geckodriver.exe
    [TestFixture]
    public class Author_Description
    {
        public IWebDriver driver = null;
        [Test]
        [Author("Victor", "abc@gmail.com")]
        [Description("facebook signup page")]
        public void Test1()
        {
            driver = new FirefoxDriver();
            driver.Url = "https://www.facebook.com";
            IWebElement firstName = driver.FindElement(By.XPath("//input[@id='u_0_m']"));
            firstName.SendKeys("david2");
            driver.Quit();
            Thread.Sleep(2000);

        }
        [Test]
        [Author("Victor", "abc@gmail.com")]
        [Description("facebook signup page")]//not working for some region
        public void Test2()
        {
            driver = new FirefoxDriver();
            driver.Url = "https://www.facebook.com";
            IWebElement firstName = driver.FindElement(By.XPath("//input[@id='u_0_m']"));
            firstName.SendKeys("david2");
            driver.Quit();
            Thread.Sleep(2000);

        }

    }
}
