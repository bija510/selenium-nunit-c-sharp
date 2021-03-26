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
    class S24_WindowAuthPopUpTest : BaseTest1
    {
        [Test]
        public void setPopUpUserNamePwd()
        {
            //driver.Url = "http://the-internet.herokuapp.com/";

            driver.Navigate().GoToUrl("http://admin:admin@the-internet.herokuapp.com/"); //this is the window authentication popUp
            driver.FindElement(By.LinkText("Basic Auth")).Click();

        }
    }
}
