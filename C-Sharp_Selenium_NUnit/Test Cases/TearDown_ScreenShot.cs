using C_Sharp_Selenium_NUnit.Utilites;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

namespace C_Sharp_Selenium_NUnit.Test_Cases
{
    [TestFixture]
    class TearDown_ScreenShot
    {
        IWebDriver driver = null;

        [OneTimeTearDown]
        public void BeforeAllMethod()
        {
            Console.WriteLine("This Is Executed only one time in Beginning");

        }

        [SetUp]
        public void BeforeMethod()
        {
            driver = new ChromeDriver();
            driver.Url = "http://demo.automationtesting.in/Register.html";

        }

        [Test]
        public void DemoAutomation()
        {
            IWebElement firstName = driver.FindElement(By.XPath("//input[@placeholder='First Name']"));
            firstName.SendKeys("David");

            IWebElement lastName = driver.FindElement(By.XPath("//input[@placeholder='Last Name'"));
            lastName.SendKeys("Lee");

        }

        [TearDown]
        public void AfterMethod()
        {
            // inc. class name
            var fullNameOfTheMethod = NUnit.Framework.TestContext.CurrentContext.Test.FullName;
            Console.WriteLine("===========>" + fullNameOfTheMethod);//C_Sharp_Selenium_NUnit.Test_Cases.TearDown_ScreenShot.TestMethod

            // method name only
            var methodName = NUnit.Framework.TestContext.CurrentContext.Test.Name;
            Console.WriteLine("===========>" + methodName); //TestMethod

            // the state of the test execution
            var state = NUnit.Framework.TestContext.CurrentContext.Result.Outcome; // TestState enum
            Console.WriteLine("===========>" + state.ToString()); // 1. (Failed:Error) 2. (Passed)
            
             if (!(state.ToString()=="Passed")) 
            {
                ITakesScreenshot ts = driver as ITakesScreenshot;
                Screenshot screenshot = ts.GetScreenshot();
                screenshot.SaveAsFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..")) + "\\Screenshot\\" + methodName + ".png", ScreenshotImageFormat.Png);
            }

            Thread.Sleep(3000);
            driver.Quit();

        }

        [OneTimeTearDown]
        public void AfterAllMethod()
        {
            Console.WriteLine("This Is Executed only one time at End");

        }



    }
}
