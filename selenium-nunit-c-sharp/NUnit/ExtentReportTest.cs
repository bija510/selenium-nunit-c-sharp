using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System.IO;

namespace C_Sharp_Selenium_NUnit
{
    [TestFixture]
    public class ExtentReportTest
    {
        ExtentReports extent = null;

        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..")) + "\\ExtentReports\\htmlExtReport10.html");
            extent.AttachReporter(htmlReporter);

        }
        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();//will close 

        }
        [Test]
        public void Test1()
        {
            IWebDriver driver = null;
            ExtentTest test = null;
            try
            {
                test = extent.CreateTest("Test1").Info("Test Started");
                driver = new FirefoxDriver();
                driver.Manage().Window.Maximize();
                test.Log(Status.Info, "Chrome browser lunched");

                driver.Url = "https://www.facebook.com";
                IWebElement firstName = driver.FindElement(By.XPath("//input[@id='email']"));
                firstName.SendKeys("david");
                test.Log(Status.Info, "First name Entered");

                Thread.Sleep(2000);

                driver.Quit();
                test.Log(Status.Pass, "Test1 passed Successfully");
            }
            catch (Exception e)
            {
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

        [Test]
        public void Test2()
        {
            IWebDriver driver = null;
            ExtentTest test = null;
            try
            {
                test = extent.CreateTest("Test2").Info("Test Started");
                driver = new FirefoxDriver();
                driver.Manage().Window.Maximize();
                test.Log(Status.Info, "Chrome browser lunched");

                driver.Url = "https://www.facebook.com";
                IWebElement firstName = driver.FindElement(By.XPath("//input[@id='email']"));
                firstName.SendKeys("david");
                test.Log(Status.Info, "First name Entered");

                Thread.Sleep(2000);

                driver.Quit();
                test.Log(Status.Pass, "Test2 passed Successfully");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
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
