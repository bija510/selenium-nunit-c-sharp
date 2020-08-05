using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.PageObject
{
    class ForgetPasswordPage
    {
        //we are defining Constructor
        IWebDriver driver;

        public ForgetPasswordPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Log In")]
        // prop + 2 time Tab = to get this 
        public IWebElement LogInLinkText { get; set; }

        public LoginPage NavigatetoChannel()
        {
            Thread.Sleep(4000);
            LogInLinkText.Click();
            return new LoginPage(driver);
            
        }
    }
}

    

