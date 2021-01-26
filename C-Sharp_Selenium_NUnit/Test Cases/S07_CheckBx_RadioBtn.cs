using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Test_Cases
{
    [TestFixture]
    class S07_CheckBx_RadioBtn
    {
        [Test]
        public void Demo()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://demo.automationtesting.in/Register.html";
            IWebElement movieChkBx = driver.FindElement(By.XPath("//input[@id='checkbox1']"));
            movieChkBx.Click();

            //driver.findElement(By.xpath("//input[@value='Male']")).click();
            IWebElement maleRadBtn = driver.FindElement(By.XPath("//input[@value='Male']"));
            maleRadBtn.Click();

            Thread.Sleep(3000);
            driver.Quit();

        }
    }
}
