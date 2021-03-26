
using AutoIt;
using C_Sharp_Selenium_NUnit.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Test_Cases
{
    [TestFixture]
    public class S29_AutoIT_FileUpload : BaseTest1
    {
        /***************************************************************************
         * Need to download the AutoIt from nuget package manager
         * need to have file in desktop stable version is =3.3.14.2= AutoItX.Dotnet
         **************************************************************************/
        [Test]
        public void FileUploadTest()
        {
            driver.Navigate().GoToUrl("http://demo.automationtesting.in/FileUpload.html");  
            
            String relativeFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..")) + "\\Data\\TextFile.txt";
          
            IWebElement fileUpload = driver.FindElement(By.XPath("//div[@class='btn btn-primary btn-file']"));
            fileUpload.Click();
            AutoItX.WinActivate("File Upload");
            AutoItX.Send(relativeFilePath);
            Thread.Sleep(2000);
            AutoItX.Send("{ENTER}");

        }
        [Test]
        public void fileUploadUsingSendKeys()
        {
            driver.Navigate().GoToUrl("http://demo.automationtesting.in/FileUpload.html");

            String relativeFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..")) + "\\Data\\TextFile.txt";
            driver.FindElement(By.XPath("//input[@id='input-4']")).SendKeys(relativeFilePath);
            Environment.Exit(0);
        }
    }
}
