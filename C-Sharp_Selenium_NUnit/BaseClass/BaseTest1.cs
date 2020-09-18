using C_Sharp_Selenium_NUnit.Utilites;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.BaseClass
{
    public class BaseTest1 : BrowserUtility1
    {
        [OneTimeSetUp]
        public void SetUpEach()
        {
            Console.WriteLine("This will executed one time in begnning");
        }

        [OneTimeTearDown]
        public void TearDownEach()
        {
            Console.WriteLine("This will executed only at the End");
        }

        [SetUp]
        public void initializeTest()
        {
            driver = initializeDriver();
            driver.Manage().Window.Maximize();
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

            if (!(state.ToString() == "Passed"))
            {
                OpenQA.Selenium.ITakesScreenshot ts = driver as ITakesScreenshot;
                Screenshot screenshot = ts.GetScreenshot();
                screenshot.SaveAsFile("C:\\Users\\Bijaya Chhetri\\Documents\\Selenium-C#\\C-Sharp_Selenium_NUnit\\C-Sharp_Selenium_NUnit\\Screenshot\\" + methodName + ".png", ScreenshotImageFormat.Png);
            }

            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
