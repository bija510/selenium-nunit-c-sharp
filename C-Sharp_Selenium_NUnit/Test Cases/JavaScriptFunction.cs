using C_Sharp_Selenium_NUnit.Utilites;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Test_Cases
{
    [TestFixture]
    class JavaScriptFunction
    {
        IWebDriver driver;
        [Test]
        public void JSFunction()
        {

            var Driver = new BrowserUtility().InitChrome(driver);
            Driver.Url = "https://www.facebook.com/";
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver);

            //SetText Using JavaScript function
            IWebElement firstName = Driver.FindElement(By.XPath("//input[@id='u_0_m']"));
            js.ExecuteScript("arguments[0].value='apple';", firstName);
            Thread.Sleep(2000);

            //GetText Using JavaScript function
            IWebElement headerTest = Driver.FindElement(By.XPath("//h2[@class='_8est']"));
            Console.WriteLine(js.ExecuteScript("return (arguments[0].innerHTML).toString();", headerTest));

            Thread.Sleep(2000);

            //Click Using JavaScript function
            IWebElement forgetPasswordLink = Driver.FindElement(By.XPath("//a[contains(text(),'Forgot account?')]"));
            js.ExecuteScript("arguments[0].click();", forgetPasswordLink);

            js.ExecuteScript("window.scrollBy(0, 1000)");
            Thread.Sleep(1500);
            js.ExecuteScript("window.scrollBy(0, -1000)");


        }
    }
}

