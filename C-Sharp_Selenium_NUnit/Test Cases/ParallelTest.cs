using C_Sharp_Selenium_NUnit.Utilites;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit
    {
    /**************************************************************************************************************************
    * TIPS:-----> C:\Users\Bijaya Chhetri>  taskkill /f /im chromedriver.exe
    * always clean solution and Rebuild same solution
    * To create AssemblyInfo.cs -->R-click -->Properties-->In assembly Information -->give just title name<--Assembltinfo--->
    ***************************************************************************************************************************/
    [TestFixture]
    class ParallelTest
    {
        // Order Attribute = priority 1, 2, 3...
        // Ignore Attribute = just ignoring that Method
        // var---->Hold any type of Datatypes variable
        IWebDriver driver;

        [Test, Category("UAT Testing"), Category("Module1")]
        public void TestMethodParallel1()
        {
            var Driver = new BrowserUtility().initFirefox(driver);
            IWebElement emailTextField = Driver.FindElement(By.XPath("//input[@id='email']"));
            emailTextField.SendKeys("abc@gmail.com");
            Thread.Sleep(2000);
            Driver.Close();
        }

        [Test, Category("UAT Testing"), Category("Module1")]
        public void TestMethodParallel2()
        {
            var Driver = new BrowserUtility().initFirefox(driver);
            IWebElement emailTextField = Driver.FindElement(By.XPath("//input[@id='email']"));
            emailTextField.SendKeys("abc@gmail.com");
            Thread.Sleep(2000);
            Driver.Close();
        }
        [Test, Category("UAT Testing"), Category("Module1")]
        public void TestMethodParallel3()
        {
            var Driver = new BrowserUtility().initFirefox(driver);
            IWebElement emailTextField = Driver.FindElement(By.XPath("//input[@id='email']"));
            emailTextField.SendKeys("abc@gmail.com");
            Thread.Sleep(2000);
            Driver.Close();
        }

        [Test, Category("UAT Testing"), Category("Module1")]
        public void TestMethodParallel4()
        {
            var Driver = new BrowserUtility().initFirefox(driver);
            IWebElement emailTextField = Driver.FindElement(By.XPath("//input[@id='email']"));
            emailTextField.SendKeys("abc@gmail.com");
            Thread.Sleep(2000);
            Driver.Close();
        }

        [Test, Category("UAT Testing"), Category("Module1")]
        public void TestMethodParallel5()
        {
            var Driver = new BrowserUtility().initFirefox(driver);
            IWebElement emailTextField = Driver.FindElement(By.XPath("//input[@id='email']"));
            emailTextField.SendKeys("abc@gmail.com");
            Thread.Sleep(2000);
            Driver.Close();
        }

        [Test, Category("UAT Testing"), Category("Module1")]
        public void TestMethodParallel6()
        {
            var Driver = new BrowserUtility().initFirefox(driver);
            IWebElement emailTextField = Driver.FindElement(By.XPath("//input[@id='email']"));
            emailTextField.SendKeys("abc@gmail.com");
            Thread.Sleep(2000);
            Driver.Close();
        }
        [Test, Category("UAT Testing"), Category("Module1")]
        public void TestMethodParallel7()
        {
            var Driver = new BrowserUtility().initFirefox(driver);
            IWebElement emailTextField = Driver.FindElement(By.XPath("//input[@id='email']"));
            emailTextField.SendKeys("abc@gmail.com");
            Thread.Sleep(2000);
            Driver.Close();
        }

        [Test, Category("UAT Testing"), Category("Module1")]
        public void TestMethodParallel8()
        {
            var Driver = new BrowserUtility().initFirefox(driver);
            IWebElement emailTextField = Driver.FindElement(By.XPath("//input[@id='email']"));
            emailTextField.SendKeys("abc@gmail.com");
            Thread.Sleep(2000);
            Driver.Close();
        }

        [Test, Category("UAT Testing"), Category("Module1")]
        public void TestMethodParallel9()
        {
            var Driver = new BrowserUtility().initFirefox(driver);
            IWebElement emailTextField = Driver.FindElement(By.XPath("//input[@id='email']"));
            emailTextField.SendKeys("abc@gmail.com");
            Thread.Sleep(2000);
            Driver.Close();
        }

        [Test, Category("UAT Testing"), Category("Module1")]
        public void TestMethodParallel10()
        {
            var Driver = new BrowserUtility().initFirefox(driver);
            IWebElement emailTextField = Driver.FindElement(By.XPath("//input[@id='email']"));
            emailTextField.SendKeys("abc@gmail.com");
            Thread.Sleep(2000);
            Driver.Close();
        }

       
    }
}
