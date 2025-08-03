using C_Sharp_Selenium_NUnit.BaseClass;
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
    class S16_Alert
    {
        private IWebDriver? driver;
        [Test]
        public void acceptAlert()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.rahulshettyacademy.com/AutomationPractice/";
            IWebElement alertBtn = driver.FindElement(By.XPath("//input[@id='alertbtn']"));
            alertBtn.Click();
            Thread.Sleep(3000);
            //driver.switchTo().alert().accept();
            driver.SwitchTo().Alert().Dismiss();

        }
    }
}
