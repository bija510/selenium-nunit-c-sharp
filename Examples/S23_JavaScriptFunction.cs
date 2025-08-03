using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace C_Sharp_Selenium_NUnit.Examples
{
    [TestFixture]
    class S23_JavaScriptFunction
    {
        private IWebDriver? driver;
        [Test]
        public void JSFunction()
        {
            //NOte >>-----> [s]string and [S]String are same coz they both are same type <<<<--System.String-->>> Method==> .GetType().FullName

            driver = new ChromeDriver();
            driver.Url = "http://demo.automationtesting.in/Register.html";
            IJavaScriptExecutor js = ((IJavaScriptExecutor)driver);

            //SetText Using JavaScript function
            String aFor = "david";
            IWebElement firstName = driver.FindElement(By.XPath("//input[@placeholder='First Name']"));
            js.ExecuteScript("arguments[0].value='" + aFor + "';", firstName);
            Thread.Sleep(2000);

            //GetText Using JavaScript function
            IWebElement headerTest = driver.FindElement(By.XPath("//h1[contains(text(),'Automation Demo Site')]"));
            Console.WriteLine(js.ExecuteScript("return (arguments[0].innerHTML).toString();", headerTest));

            Thread.Sleep(2000);

            //Click Using JavaScript function
            IWebElement forgetPasswordLink = driver.FindElement(By.XPath("//input[@id='checkbox1']"));
            js.ExecuteScript("arguments[0].click();", forgetPasswordLink);

            js.ExecuteScript("window.scrollBy(0, 1000)");
            Thread.Sleep(1500);
            js.ExecuteScript("window.scrollBy(0, -1000)");


        }
    }
}

