using C_Sharp_Selenium_NUnit.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;

namespace C_Sharp_Selenium_NUnit
{  
    [TestFixture]
    public class Author_Description :BaseTest1
    {

        [Test]
        [Author("Victor", "abc@gmail.com")]
        [Description("facebook signup page")]
        public void Test1()
        {
            driver.Url = "https://www.facebook.com";
            IWebElement firstName = driver.FindElement(By.XPath("//input[@id='u_0_m']"));
            firstName.SendKeys("david2");         

        }
        [Test]
        [Author("Victor", "abc@gmail.com")]
        [Description("facebook signup page")]//not working for some region
        public void Test2()
        {
            driver.Url = "https://www.facebook.com";
            IWebElement firstName = driver.FindElement(By.XPath("//input[@id='u_0_m']"));
            firstName.SendKeys("david2");

        }

    }
}
