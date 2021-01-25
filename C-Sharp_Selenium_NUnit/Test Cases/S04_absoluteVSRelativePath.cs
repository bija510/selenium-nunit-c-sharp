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
    class S04_absoluteVSRelativePath
    {
        [Test]
        public void Demo()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.facebook.com/signup";

            IWebElement firstName = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div[1]/div/div/div[2]/div[1]/div/div[1]/form/div[1]/div[1]/div[1]/div[1]/div/div[1]/input"));
            firstName.SendKeys("David");

            IWebElement lastName = driver.FindElement(By.XPath("//input[@id='u_0_p']"));
            lastName.SendKeys("lee");

            Thread.Sleep(3000);
            driver.Quit();

        }
    }
}
