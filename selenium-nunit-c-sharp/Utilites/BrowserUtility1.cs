using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;

namespace C_Sharp_Selenium_NUnit.Utilites
{
    public class BrowserUtility1
    {
        public static IWebDriver driver;

        public IWebDriver initializeDriver()
        {

            String browserName = "CHROME";

            if (browserName.Equals("CHROME"))
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            }
            else if (browserName.Equals("FIREFOX"))
            {
                driver = new FirefoxDriver();
                driver.Manage().Window.Maximize();
            }
            else if (browserName.Equals("EDGE"))
            {
                driver = new EdgeDriver();
                driver.Manage().Window.Maximize();
            }

            return driver;
        }
    }
}
