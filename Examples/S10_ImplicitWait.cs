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
    class S10_ImplicitWait
    {
        private IWebDriver? driver;
        [Test]
        public void ImplicitWaitTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Url = "http://demo.automationtesting.in/Register.html";

            Thread.Sleep(2000); //always wait upto --->hard wait		
            driver.FindElement(By.XPath("//input[@placeholder='First Name']")).SendKeys("JOHN");
            driver.Quit();
        }

    }
}


