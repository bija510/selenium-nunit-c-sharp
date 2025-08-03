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


namespace C_Sharp_Selenium_NUnit.Examples
{
    [TestFixture]
    class S28_Remote_WebDriverManager
    {
        [Test]
        public void demo()
        {
            /***********************************************
            NOTE:- No need since Selenium webdriver 4.29.0
            ************************************************/

            //new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            //IWebDriver driver = new FirefoxDriver();

            //new WebDriverManager.DriverManager().SetUpDriver(new InternetExplorerConfig());
            //IWebDriver driver = new InternetExplorerDriver();

        
            IWebDriver driver = new EdgeDriver();


            //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            //IWebDriver driver = new ChromeDriver();


            driver.Navigate().GoToUrl("https://www.facebook.com");
        }
    }
}
