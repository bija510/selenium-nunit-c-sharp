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
    class S05_Click_Sendkeys_GetText_Attribute
    {
        [Test]
        public void Demo()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://demo.automationtesting.in/Register.html";

            IWebElement firstName = driver.FindElement(By.XPath("//input[@placeholder='First Name']"));
            firstName.SendKeys("David");

            IWebElement MovieChkBx = driver.FindElement(By.XPath("//input[@id='checkbox1']"));
            MovieChkBx.Click();

            IWebElement pageLabel = driver.FindElement(By.XPath("//h2[contains(text(),'Register')]"));
            Console.WriteLine("====>" + pageLabel.Text);

          
            Console.WriteLine("====>" + firstName.GetAttribute("value"));

            Thread.Sleep(3000);
            driver.Quit();

        }
    }
}
