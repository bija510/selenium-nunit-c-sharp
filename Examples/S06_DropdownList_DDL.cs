using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Examples
{
    //NOTE: AUTO_FORMAT = CTRL + K FOLLOWED BY F
   
   [TestFixture]
    class S06_DropdownList_DDL
    {
        private IWebDriver? driver;

        [Test]
        public void Dropdown()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.rahulshettyacademy.com/AutomationPractice/";

            IWebElement DDL = driver.FindElement(By.XPath("//select[@id='dropdown-class-example']"));
            SelectElement selectDDL = new SelectElement(DDL);
            //OR
            //var selectDDL = new SelectElement(DDL);
            //selectDDL.SelectByText("Option2");
            selectDDL.SelectByIndex(2);
            Thread.Sleep(2000);

            //selectDDL.SelectByText("Option1");
            selectDDL.SelectByIndex(1);
            Thread.Sleep(2000);

            //selectDDL.SelectByText("Option3");
            selectDDL.SelectByIndex(3);
            Thread.Sleep(2000);
            driver.Quit();

        }
    }
}

