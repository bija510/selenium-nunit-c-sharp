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
        /********************************************************************************************************************
        1. Encapsulation Object oriented program here [private By variable] will be accessed by all this [public method]
        2. Do not write assertion in page class
        3. All the driver.findElement.....click, getText,...should only write in Page class
        *******************************************************************************************************************/
        public FB_login_PO(IWebDriver driver)
        {
            this.driver = driver; //==> Iniatilazation
        }

        private By firstName = By.XPath("//input[@id='u_0_m']"); //==>Decleration
        private By lastName = By.XPath("//input[@id='u_0_o']");

        public IWebElement firstname() //==> Utilization
        {
            return driver.FindElement(firstName);
        }
        public IWebElement lastname()
        {
            return driver.FindElement(lastName);
        }







    }
}
