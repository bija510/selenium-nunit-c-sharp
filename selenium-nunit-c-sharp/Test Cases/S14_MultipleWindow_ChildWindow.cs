using C_Sharp_Selenium_NUnit.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace C_Sharp_Selenium_NUnit.Test_Cases
{
    [TestFixture]
    class S14_MultipleWindow_ChildWindow : BaseTest1
    {
      
        [Test]
        public void openNewTab()
        {
            driver.Url = "https://www.rahulshettyacademy.com/AutomationPractice/";
            driver.FindElement(By.XPath("//a[@id='opentab']")).Click();

            Console.WriteLine("num of open window" + driver.WindowHandles.Count);
            foreach (var item in driver.WindowHandles)
            {
                Console.WriteLine(item);
            }

            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Console.WriteLine(driver.FindElement(By.XPath("//span[contains(text(),'World class')]")).Text);

            Thread.Sleep(2000);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            Thread.Sleep(2000);
        }


    }

}

