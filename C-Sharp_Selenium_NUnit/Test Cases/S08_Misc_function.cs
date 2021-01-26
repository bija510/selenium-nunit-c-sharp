using C_Sharp_Selenium_NUnit.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Test_Cases
{
    [TestFixture]
    class S08_Misc_function : BaseTest1
    {
        [Test]
        public void demo()
        {
            driver.Url= "https://www.facebook.com/login/";
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

            driver.Manage().Cookies.DeleteAllCookies();
            Console.WriteLine("Current Url:- " + driver.Url);
            Console.WriteLine("Current page title:- " + driver.Title);
            Console.WriteLine("Current window Number(handles):- " + driver.CurrentWindowHandle);

            driver.FindElement(By.XPath("//button[@id='loginbutton']")).Submit(); //To submit the Just for form & Enter


        }
    }
}
