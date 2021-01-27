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
    class S23_JavaScriptFunction
    {
        IWebDriver driver;
        [Test]
        public void JSFunction()
        {
            //NOte >>-----> [s]string and [S]String are same coz they both are same type <<<<--System.String-->>> Method==> .GetType().FullName

            var Driver = new BrowserUtility().InitChrome(driver);
            Driver.Url = "http://demo.automationtesting.in/Register.html";
            IJavaScriptExecutor js = ((IJavaScriptExecutor)Driver);

            //SetText Using JavaScript function
            String aFor = "david";
            IWebElement firstName = Driver.FindElement(By.XPath("//input[@placeholder='First Name']"));
            js.ExecuteScript("arguments[0].value='"+aFor+"';", firstName);
            Thread.Sleep(2000);

            //GetText Using JavaScript function
            IWebElement headerTest = Driver.FindElement(By.XPath("//h1[contains(text(),'Automation Demo Site')]"));
            Console.WriteLine(js.ExecuteScript("return (arguments[0].innerHTML).toString();", headerTest));

            Thread.Sleep(2000);

            //Click Using JavaScript function
            IWebElement forgetPasswordLink = Driver.FindElement(By.XPath("//input[@id='checkbox1']"));
            js.ExecuteScript("arguments[0].click();", forgetPasswordLink);

            js.ExecuteScript("window.scrollBy(0, 1000)");
            Thread.Sleep(1500);
            js.ExecuteScript("window.scrollBy(0, -1000)");


        }
    }
}

