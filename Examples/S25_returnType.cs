using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace C_Sharp_Selenium_NUnit.Examples
{
    [TestFixture]
    class S25_returnType
    {
        public IWebDriver driverForChrome()
        {
            /*********************************************************************************************************
            NOTE:- since we are using cloud driver we NEED TO open visual studio as Administrator mode by Right click
            ***********************************************************************************************************/

            ChromeDriver driver = new ChromeDriver();
            return driver;
        }
        public String dataFName()
        {
            String fName = "Ram";
            return fName;
        }

        public IWebElement setFirstName(IWebDriver driver)
        {
            var firstNameTextBox = driver.FindElement(By.XPath("//input[@placeholder='First Name']"));
            return firstNameTextBox;
        }

        [Test]
        public void pagetab()
        {
            IWebDriver driver = driverForChrome();
            driver.Url = "http://demo.automationtesting.in/Register.html";

            // setFirstName(driver) = sending driver & receiving WebElement
            setFirstName(driver).SendKeys(dataFName());

            var lastNameTextBox = driver.FindElement(By.CssSelector("input[placeholder='Last Name'"));
            lastNameTextBox.SendKeys("sharma");
            Thread.Sleep(3000);
            driver.Quit();

        }
    }
}
