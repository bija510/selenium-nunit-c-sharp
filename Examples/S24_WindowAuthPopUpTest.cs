using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace C_Sharp_Selenium_NUnit.Examples
{
    [TestFixture]
    class S24_WindowAuthPopUpTest
    {
        private IWebDriver? driver;
        [Test]
        public void setPopUpUserNamePwd()
        {
            driver = new ChromeDriver();
            //driver.Url = "http://the-internet.herokuapp.com/";

            driver.Navigate().GoToUrl("http://admin:admin@the-internet.herokuapp.com/"); //this is the window authentication popUp
            driver.FindElement(By.LinkText("Basic Auth")).Click();

        }
    }
}
