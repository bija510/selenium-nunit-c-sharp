using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.PageObject
{
    class FB_login_PO
    {
        public IWebDriver driver;
        

        public FB_login_PO(IWebDriver driver)
        {
            this.driver = driver;
        }

        By firstName = By.XPath("//input[@id='u_0_m']");
        By lastName = By.XPath("//input[@id='u_0_o']");

        public IWebElement firstname()
        {
            return driver.FindElement(firstName);
        }
        public IWebElement lastname()
        {
            return driver.FindElement(lastName);
        }







    }
}
