using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace C_Sharp_Selenium_NUnit.Examples
{
    [TestFixture]
    public class Try_Catch_finally
    {
        private IWebDriver? driver;
        [Test]
        public void TestMethod1()
        {
            try
            {
                driver = new ChromeDriver();
                driver.Url = "https://www.facebook.com";
                IWebElement firstName = driver.FindElement(By.XPath("//input[@id='u_0_m'"));
                firstName.SendKeys("david2");
                driver.Quit();
                Thread.Sleep(2000);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;

            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();

                }
            }
        }
    }
}