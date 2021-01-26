using C_Sharp_Selenium_NUnit.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Test_Cases
{
    [TestFixture]
    class S12_Calendar_Datepicker : BaseTest1
    {
        // Current Date
        String currentDate = DateTime.Now.ToString("MM/dd/yyyy");

        // Current Time
        String currentTime = DateTime.Now.ToString("hh:mm:ss tt");
       
        [Test]
        public void EnableDatePicker1()
        {
            Console.WriteLine(currentDate); // 01/26/2021
            Console.WriteLine(currentTime);
            driver.Url = "http://demo.automationtesting.in/Datepicker.html"; // strDate.substring(3, 5)
            driver.FindElement(By.XPath("//input[@id='datepicker2']")).Click();
            List<IWebElement> days = new List<IWebElement>(driver.FindElements(By.TagName("td")));//(By.TagName("td"));
            Console.WriteLine(days.Count);
           
            for (int i = 0; i < days.Count; i++)
            {
                Console.WriteLine(currentDate.Substring(3, 4));
                Console.WriteLine(days[i].Text);
                if (days[i].Text.Equals(currentDate.Substring(3, 5)))
                {
                    Console.WriteLine(days[i].Text);
                    days[i].Click();
                    break;
                }
            }
            Thread.Sleep(5000);
            //System.Environment.Exit(0);
        }

        [Test]
        public void EnableDatePickee2()
        {
            driver.Url = "http://demo.automationtesting.in/Datepicker.html";
            driver.FindElement(By.XPath("//input[@id='datepicker2']")).SendKeys(currentDate);
        }

        [Test]
        public void disabledDatePicker()
        {
            driver.Url = "http://demo.automationtesting.in/Datepicker.html";
            IJavaScriptExecutor js = ((IJavaScriptExecutor)driver);
            IWebElement disabledDateTxtBx = driver.FindElement(By.XPath("//input[@id='datepicker1']"));
            js.ExecuteScript("arguments[0].value='" + currentDate + "';", disabledDateTxtBx);

        }
    }
    }
