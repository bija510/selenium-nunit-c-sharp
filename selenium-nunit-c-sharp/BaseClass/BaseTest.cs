using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.BaseClass
{/******************************************
    * Always clean solution and Rebuild solution
    * taskkill /f /im chromedriver.exe -->C:\Users\Bijaya Chhetri\eclipse-workspace\subi\Driver
    * taskkill /f /im IEDriverServer.exe
    * taskkill /f /im geckodriver.exe
    *******************************************/
    public class BaseTest
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void SetUpEach()
        {
            Console.WriteLine("This will executed one time in begnning");
        }

        [OneTimeTearDown]
        public void TearDownEach()
        {
            Console.WriteLine("This will executed only at the End");
        }

        [SetUp]
        public void BeforeMethod()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.facebook.com";
            //driver.Url = "https://www.youtube.com";
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void AfterMethod()
        {
            driver.Quit(); 
        }
    }
}
