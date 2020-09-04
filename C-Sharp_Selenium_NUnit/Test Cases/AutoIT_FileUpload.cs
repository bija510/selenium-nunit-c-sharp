
using AutoIt;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Test_Cases
{
    [TestFixture]
    public class AutoIT_FileUpload
    {
        /***************************************************************************
         * Need to download the AutoIt from nuget package manager
         * need to have file in desktop stable version is =3.3.14.2= AutoItX.Dotnet
         **************************************************************************/
        [Test]
        public void FileUploadTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://demo.automationtesting.in/FileUpload.html"); //  
            String path = "C:\\Users\\Bijaya Chhetri\\Desktop\\autoIT.png";
            IWebElement fileUpload = driver.FindElement(By.XPath("//div[@class='btn btn-primary btn-file']"));
            fileUpload.Click();

            AutoItX.WinActivate("File Upload");
            AutoItX.Send(@path);
            Thread.Sleep(2000);
            AutoItX.Send("{ENTER}");

        }
    }
}
