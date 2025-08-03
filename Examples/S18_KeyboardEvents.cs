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
    class S18_KeyboardEvents
    {
        private IWebDriver? driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void using1Keys()
        {
            driver.Navigate().GoToUrl("https://www.rahulshettyacademy.com/AutomationPractice/");
            var autoSuggestTextBox = driver.FindElement(By.XPath("//input[@id='autocomplete']"));
            autoSuggestTextBox.SendKeys("Au");
            Thread.Sleep(2000);
            autoSuggestTextBox.SendKeys(Keys.ArrowDown);
            autoSuggestTextBox.SendKeys(Keys.Enter);

        }

        [Test]
        public void using2Keys()
        {
            driver.Url = "https://www.facebook.com/login/";

            var userName = driver.FindElement(By.XPath("//input[@id='email']"));
            userName.SendKeys(Keys.NumberPad2);
            Thread.Sleep(2000);
            userName.SendKeys(Keys.Backspace);

            Thread.Sleep(2000);
            var signUpLinkText = driver.FindElement(By.LinkText("Sign Up"));
            signUpLinkText.SendKeys(Keys.Control + Keys.Enter);
            Thread.Sleep(2000);
        }
    }
}
