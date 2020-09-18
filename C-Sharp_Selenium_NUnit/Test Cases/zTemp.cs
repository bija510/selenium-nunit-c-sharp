
using C_Sharp_Selenium_NUnit.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace C_Sharp_Selenium_NUnit.Test_Cases
{
    [TestFixture]
    class zTemp : BaseTest1
    {
        [Test]
        public static void headLessMethod()
        {
            //IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://demo.automationtesting.in/FileUpload.html");

            //String absoluteFilePath = @"C:\Users\Bijaya Chhetri\Documents\Selenium-C#\C-Sharp_Selenium_NUnit\C-Sharp_Selenium_NUnit\Data\TextFile.txt";
            //String projectDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));

            String relativeFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..")) +"\\Data\\TextFile.txt";
                   
            Console.WriteLine(relativeFilePath);
           
            driver.FindElement(By.XPath("//input[@id='input-4']")).SendKeys(relativeFilePath);
            
        }

    }
}
