using C_Sharp_Selenium_NUnit.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace C_Sharp_Selenium_NUnit.Test_Cases
{
    [TestFixture]
    class S11_ExplicitWait : BaseTest1
    {
        [Test]
        public void demo()
        {
           
            WebDriverWait ExplicitWait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            driver.Url = "https://www.rahulshettyacademy.com/AutomationPractice/";

            IWebElement firstName = ExplicitWait.Until(ExpectedConditions.ElementExists(By.Id("autocomplete")));
            firstName.SendKeys("india");

        }
    }
}