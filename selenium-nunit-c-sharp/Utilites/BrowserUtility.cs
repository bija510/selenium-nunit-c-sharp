using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Utilites
{
    public class BrowserUtility
    {
        public IWebDriver InitChrome(IWebDriver driver)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.facebook.com";
            return driver;

        }

        public IWebDriver initFirefox(IWebDriver driver)
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.facebook.com";
            return driver;

        }
        public IWebDriver InitChrome2(IWebDriver driver)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Url = "https://www.facebook.com";
            return driver;


        }
    }
}
