using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace C_Sharp_Selenium_NUnit.Test_Cases
{
    [TestFixture]
    class S28_Remote_WebDriverManager
    {
        [Test]
        public void demo()
        {
            /*********************************************************************************************************
            NOTE:- since we are using cloud driver we NEED TO open visual studio as Administrator mode by Right click
            ***********************************************************************************************************/

            //new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            //IWebDriver driver = new FirefoxDriver();

            //new WebDriverManager.DriverManager().SetUpDriver(new InternetExplorerConfig());
            //IWebDriver driver = new InternetExplorerDriver();

            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            IWebDriver driver = new EdgeDriver();


            //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            //IWebDriver driver = new ChromeDriver();


            driver.Navigate().GoToUrl("https://www.facebook.com");
        }
    }
}
