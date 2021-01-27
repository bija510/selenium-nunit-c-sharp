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
    class S17_AutoComplete : BaseTest1
    {

    [Test]
    public void test_autoSuggest()
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.rahulshettyacademy.com/AutomationPractice/");
            var autoSuggestTextBox = driver.FindElement(By.CssSelector("input[id='autocomplete']"));
            autoSuggestTextBox.SendKeys("Au"); 
            Thread.Sleep(2000); //This needed otherwise this TC Fail
            autoSuggestTextBox.SendKeys(Keys.ArrowDown);
            
            autoSuggestTextBox.SendKeys(Keys.Enter);
            Thread.Sleep(3000);

        }
    }
}
