using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit
{
    [TestFixture]
    public class DataDriving
    {
       
        [Test, Category("DataDriven")]
        [TestCaseSource("DataDrivenTesting")]
        public void Test1(String fName)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://www.facebook.com";
            IWebElement firstName = driver.FindElement(By.XPath("//input[@id='u_0_m']"));
            firstName.SendKeys(fName);
            Thread.Sleep(2000);
            driver.Quit();
            

        }
        static IList DataDrivenTesting()
        {
            ArrayList list = new ArrayList();
            list.Add("Adam");
            list.Add("Bivek");
            list.Add("Cavin");
            return list;
        }
    }
}
