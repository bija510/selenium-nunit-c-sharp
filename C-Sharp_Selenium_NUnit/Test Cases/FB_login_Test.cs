using C_Sharp_Selenium_NUnit.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Test_Cases
{
    [TestFixture]
    class FB_login_Test
    {
        [Test]
        public void loginPageTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.facebook.com/";

            FB_login_PO loginpage = new FB_login_PO(driver);
            loginpage.firstname().SendKeys("david");
            loginpage.lastname().SendKeys("lee");

        }
    }
}
