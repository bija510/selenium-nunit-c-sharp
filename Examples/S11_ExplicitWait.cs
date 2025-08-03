using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace C_Sharp_Selenium_NUnit.Examples
{
    [TestFixture]
    class S11_ExplicitWait
    {
       private IWebDriver? driver;
       [Test]
        public void ExplicitWaitTest()
        {
            driver = new ChromeDriver(); 
            WebDriverWait ExplicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Url = "https://www.rahulshettyacademy.com/AutomationPractice/";

            // Fix: Ensure ExpectedConditions is resolved by adding SeleniumExtras.WaitHelpers
            IWebElement firstName = ExplicitWait.Until(ExpectedConditions.ElementExists(By.Id("autocomplete")));
            firstName.SendKeys("india");
        }
    }
}