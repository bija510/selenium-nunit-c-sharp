using C_Sharp_Selenium_NUnit.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Examples
{
    [TestFixture]
    class S20_DisplayedSelectedEnabled
    {
        private IWebDriver? driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void SelAndDesMethod()
        {
            driver.Url = "https://www.rahulshettyacademy.com/AutomationPractice/";

            //Example:- 1
            var option1TxtBx = driver.FindElement(By.XPath("//input[@id='checkBoxOption1']"));
            Assert.That(option1TxtBx.Selected, Is.False);

            //Example:- 2
            var showHideTxtBx = driver.FindElement(By.XPath("//input[@id='displayed-text']"));
            Assert.That(showHideTxtBx.Displayed, Is.True);
        }

        [Test]
        public void isEnabled()
        {
            driver.Url = "http://www.testdiary.com/training/selenium/selenium-test-page/";
            var saveBtn = driver.FindElement(By.XPath("//button[@id='demo']"));
            Console.WriteLine("is Btn Enabled?:- " + saveBtn.Enabled);
        }
    }
}
