using C_Sharp_Selenium_NUnit.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Test_Cases
{
    [TestFixture]
    class S20_DisplayedSelectedEnabled : BaseTest1
    {
        [Test]
        public void SelAndDesMethod()
        {
            driver.Url = "https://www.rahulshettyacademy.com/AutomationPractice/";

            //Example:- 1
            var option1TxtBx = driver.FindElement(By.XPath("//input[@id='checkBoxOption1']"));
            Assert.False(option1TxtBx.Selected);

            //Example:- 2
            var showHideTxtBx = driver.FindElement(By.XPath("//input[@id='displayed-text']"));
            Assert.True(showHideTxtBx.Displayed);

        }

        [Test]
        public void isEnabled()
        {
            driver.Url = "http://www.testdiary.com/training/selenium/selenium-test-page/";
            var saveBtn = driver.FindElement(By.XPath("//button[@id='demo']"));
            Console.WriteLine("is Btn Enabled?:- " + saveBtn.Enabled);
        }
    }
}
