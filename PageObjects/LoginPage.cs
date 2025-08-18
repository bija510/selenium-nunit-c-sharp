using BC.Selenium.WebUI;
using OpenQA.Selenium;


namespace C_Sharp_Selenium_NUnit.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver? Driver;
        private readonly WebUI _WebUI;


        public LoginPage(IWebDriver? driver)
        {
            Driver = driver;
           _WebUI = new WebUI(driver);
        }

        // Locators
        private readonly By userNameTxt = By.XPath("//input[@placeholder='Username']");
        private readonly By passwordTxt = By.XPath("//input[@placeholder='Password']");
        private readonly By loginBtn = By.XPath("//button[@type='submit']");
        private readonly By dashboardLbl = By.XPath("//h6[@class='oxd-text oxd-text--h6 oxd-topbar-header-breadcrumb-module']");

        public void OpenLoginPage(string url)
        {
            _WebUI.NavigateToUrl(url);
        }
        public void Login(string userName, string password)
        {
            _WebUI.SendKeys("UserName Txt", userNameTxt, userName);
            _WebUI.SendKeys("Password Txt", passwordTxt, password);
            _WebUI.Click("Login Bth", loginBtn);
            _WebUI.Delay(2);
            _WebUI.VerifyTextPresent("Dashboard Lbl", "Dashboard");
        }
    }
}