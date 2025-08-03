using C_Sharp_Selenium_NUnit.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Examples
{
    [TestFixture]
    class S27_GetToolTipText
    {
        private IWebDriver? driver;
        [Test]
        public void tooltipText()
        {
            driver = new ChromeDriver();    
            driver.Url = "https://jqueryui.com/tooltip/";
            driver.Manage().Window.Maximize();
            driver.SwitchTo().Frame(0);

            var agebox = driver.FindElement(By.Id("age"));
            String tooltiptext = agebox.GetAttribute("title");
            if (tooltiptext.Equals("We ask for your age only for statistical purposes."))
            {
                Console.WriteLine("Tooltip test passed");
            }
            else
            {
                Console.WriteLine("Tooltip test failed");
            }
        }
    }
}
