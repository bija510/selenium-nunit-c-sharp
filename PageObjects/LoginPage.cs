using BC.Selenium.WebUI;
using OpenQA.Selenium;


namespace C_Sharp_Selenium_NUnit.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver Driver;
        private readonly WebUI _WebUI;


        public LoginPage(IWebDriver driver)
        {
            Driver = driver;
           _WebUI = new WebUI(driver);
        }

        // Locators
        private readonly By userNameField = By.XPath("//input[@placeholder='Username']");
        private readonly By passwordField = By.XPath("//input[@placeholder='Password']");
        private readonly By loginBtn = By.XPath("//button[@type='submit']");

        public void OpenLoginPage(string url)
        {
            _WebUI.NavigateToUrl(url);
        }
        public void Login(string userName, string password)
        {
            _WebUI.SendKeys(userNameField, userName);
            _WebUI.SendKeys(passwordField, password);
            _WebUI.Click(loginBtn);

        }


    }
}