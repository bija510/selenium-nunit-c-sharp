using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
namespace C_Sharp_Selenium_NUnit.PageObject
{
    class SignUpPage
    {
        //we are defining Constructor
        IWebDriver driver;
        public SignUpPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Forgot account?")]
        // prop + 2 time Tab = to get this 
        public IWebElement ForgotaccountLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[id='identify_email']")]
        public IWebElement MobileNum { get; set; }


        public ForgetPasswordPage NavigatetoResultPage()//Returning driver to next page so ..
        {
            ForgotaccountLink.Click();
            MobileNum.SendKeys("123456");
            return new ForgetPasswordPage(driver);
        }
    }
}
