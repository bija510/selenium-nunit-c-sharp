// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using C_Sharp_Selenium_NUnit.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

/******************************************
    * Always clean solution and Rebuild solution
    * taskkill /f /im chromedriver.exe -->C:\Users\Bijaya Chhetri\eclipse-workspace\subi\Driver
    * taskkill /f /im IEDriverServer.exe
    * taskkill /f /im geckodriver.exe
    *******************************************/
namespace C_Sharp_Selenium_NUnit
{
    [TestFixture]
    public class OrderSkipAttribute : BaseTest
    {
        [Test, Category("Smoke Testing")] //Choose from Test Explorer -->Traits to see by grouping= Category
        public void TestMethod()
        {
            IWebElement firstName = driver.FindElement(By.XPath("//input[@id='u_0_m']"));
            firstName.SendKeys("david1");
            IWebElement monthDDL = driver.FindElement(By.CssSelector("select[id='month']"));
            SelectElement element = new SelectElement(monthDDL);
            element.SelectByText("Dec");
            Thread.Sleep(2000);
            element.SelectByIndex(2);
            Thread.Sleep(2000);
            element.SelectByValue("3");

            Thread.Sleep(2000);
        }
        [Test, Category("Regression Testing")]
        public void TestMethod1()
        {
            IWebElement firstName = driver.FindElement(By.XPath("//input[@id='u_0_m']"));
            firstName.SendKeys("david2");
            Thread.Sleep(2000);
        }
        [Test, Category("Regression Testing")]
        public void TestMethod2()
        {
            IWebElement firstName = driver.FindElement(By.XPath("//input[@id='u_0_m']"));
            firstName.SendKeys("david3");
            IWebElement forgetPassword = driver.FindElement(By.LinkText("Forgot account?"));
            forgetPassword.SendKeys(Keys.Control);
            forgetPassword.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
        }
    }
}
