using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace C_Sharp_Selenium_NUnit.Examples
{
    [TestFixture]
    public class S12_Calendar_Datepicker
    {
        private IWebDriver? driver;
        private string? currentDate;
        private string? currentDay;
        private string? currentTime;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            currentDate = DateTime.Now.ToString("MM/dd/yyyy");     // e.g., 08/02/2025
            currentDay = DateTime.Now.Day.ToString();              // e.g., 2
            currentTime = DateTime.Now.ToString("hh:mm:ss tt");    // e.g., 09:00:00 PM
        }

        [Test]
        public void EnableDatePickerClickDay()
        {
            Console.WriteLine("Current Date: " + currentDate);
            Console.WriteLine("Current Time: " + currentTime);

            driver!.Navigate().GoToUrl("http://demo.automationtesting.in/Datepicker.html");

            driver.FindElement(By.Id("datepicker2")).Click();
            List<IWebElement> days = new List<IWebElement>(driver.FindElements(By.XPath("//table[@class='ui-datepicker-calendar']//td[not(contains(@class, 'ui-datepicker-other-month'))]")));

            Console.WriteLine("Day count: " + days.Count);

            foreach (IWebElement day in days)
            {
                if (day.Text == currentDay)
                {
                    Console.WriteLine("Clicking day: " + day.Text);
                    day.Click();
                    break;
                }
            }
        }

        [Test]
        public void EnableDatePickerSendKeys()
        {
            driver!.Navigate().GoToUrl("http://demo.automationtesting.in/Datepicker.html");
            driver.FindElement(By.Id("datepicker2")).SendKeys(currentDate!);
        }

        [Test]
        public void SetDisabledDatePickerViaJS()
        {
            driver!.Navigate().GoToUrl("http://demo.automationtesting.in/Datepicker.html");

            IWebElement disabledInput = driver.FindElement(By.Id("datepicker1"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].value='" + currentDate + "';", disabledInput);
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                driver?.Quit();
                driver?.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("⚠️ Error during TearDown: " + ex.Message);
            }
        }
    }
}
