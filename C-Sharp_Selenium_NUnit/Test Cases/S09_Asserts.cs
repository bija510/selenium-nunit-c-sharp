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
    class S09_Asserts : BaseTest1
    {
        [Test]
        public  void demo()
        {
            driver.Url = "https://www.rahulshettyacademy.com/AutomationPractice/";

            //Example:- 1
            IWebElement option1TxtBx = driver.FindElement(By.XPath("//input[@id='checkBoxOption1']"));
            Assert.False(option1TxtBx.Selected);

            //Example:- 2
            IWebElement showHideTxtBx = driver.FindElement(By.XPath("//input[@id='displayed-text']"));
            Assert.True(showHideTxtBx.Displayed);

            //Example:- 3
            String actTitle = "Practice Page";
            Assert.AreEqual(actTitle, driver.Title);

            //Example:- 4
            String aFor = "apple";
            String bFor = "ball";
            Assert.AreNotEqual(aFor, bFor);

            Console.WriteLine("All Example 1, 2, 3 & 4 Passes Successfully");
        }
    }
}
