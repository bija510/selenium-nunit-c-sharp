using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Test_Cases
{
    [TestFixture]
    class S03_CrossBrowserTest
    {
        IWebDriver driver;
        [Test]
        public void Chrome()
        {
            driver= new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
        }

        [Test]
        public void Firefox()
        {
            driver= new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.amazon.com/");
        }

        [Test]
        public void demo()
        {
            /*The Trick i have done to make it work==> went to this path & Change the driver name from [msedgedriver] to====> MicrosoftWebDriver.exe
             * C:\Users\Bijaya Chhetri\Documents\Selenium-CSharp\C-Sharp_Selenium_NUnit\C-Sharp_Selenium_NUnit\bin\Debug
             * driver = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)); //this also no need 
             */
            driver = new EdgeDriver();
            driver.Navigate().GoToUrl("https://www.walmart.com/");
        }
        [TearDown]
        public void CLose()
        {
            Thread.Sleep(3000);
        
            driver.Quit();
        }
    }

   
}
