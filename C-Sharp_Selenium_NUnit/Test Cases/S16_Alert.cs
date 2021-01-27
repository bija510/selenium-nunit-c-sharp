using C_Sharp_Selenium_NUnit.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Test_Cases
{
    [TestFixture]
    class S16_Alert : BaseTest1
    {
    [Test]
    public void acceptAlert()
        {
            driver.Url = "https://www.rahulshettyacademy.com/AutomationPractice/";
		IWebElement alertBtn = driver.FindElement(By.XPath("//input[@id='alertbtn']"));
        alertBtn.Click();
		Thread.Sleep(3000);
		//driver.switchTo().alert().accept();
		driver.SwitchTo().Alert().Dismiss();

    }
}
}
