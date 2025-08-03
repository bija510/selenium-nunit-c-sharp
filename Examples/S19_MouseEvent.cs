using C_Sharp_Selenium_NUnit.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Examples
{
    [TestFixture]
    class S19_MouseEvent
    {
        private IWebDriver? driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void doubleClick()
        {
            driver.Url = "http://api.jquery.com/dblclick/";

            driver.SwitchTo().Frame(0);
            var aaa = driver.FindElement(By.XPath("/html/body/div"));
            Thread.Sleep(3000);
            Actions act = new Actions(driver);
            act.DoubleClick(aaa).Build().Perform();
            Thread.Sleep(3000);
            act.DoubleClick(aaa).Build().Perform();
        }

        [Test]
        public void slider()
        {
            driver.Url = "https://jqueryui.com/slider/";

            driver.Manage().Window.Maximize();
            driver.SwitchTo().Frame(0);
            var slider = driver.FindElement(By.XPath("//div[@id='slider']//span"));
            Thread.Sleep(3000);
            var act = new Actions(driver);
            act.ClickAndHold(slider).MoveByOffset((-(int)slider.Size.Width / 2), 0).MoveByOffset(500, 0).Release().Perform();
            
            Thread.Sleep(3000);

        }
        //Drag and drop , Mouse hovering, move to element, series of action
    }
}
