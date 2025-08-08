using BC.Selenium.WebUI;
using OpenQA.Selenium;

namespace C_Sharp_Selenium_NUnit.PageObjects
{
    class PersonalDetailsPage
    {
        private readonly IWebDriver Driver;
        private readonly WebUI _WebUI;

        public PersonalDetailsPage(IWebDriver driver)
        {
            Driver = driver;
            _WebUI = new WebUI(driver);
        }
        // Locators
        private readonly By employeeFirstInput = By.Name("firstName");
        private readonly By employeeLastNameInput = By.Name("lastName");
        private readonly By myInfoMenu = By.XPath("//div[@class='oxd-sidepanel-body']//li[6]");
        private readonly By pageTitle = By.XPath("//h6[text()='Personal Details']");
    
        private readonly By employeeIdField = By.XPath("//label[normalize-space()='Employee Id']/parent::div/following-sibling::div/input");
        private readonly By otherIdField = By.XPath("//label[normalize-space()='Other Id']/parent::div/following-sibling::div/input");
        private readonly By driverLicenseNumberField = By.XPath("//label[contains(text(),'License Number')]/parent::div/following-sibling::div/input");   
        private readonly By saveButton = By.XPath("//button[@type='submit']");
       

        // Methods
        public void NavigateTo(string url)
        {
            _WebUI.NavigateToUrl(url);
            _WebUI.WaitForElementVisible(pageTitle);
        }

        public void ClickMyInfoMenu()
        {
            _WebUI.Click(myInfoMenu);
            _WebUI.Delay(2);
        }
        public bool IsAt() => _WebUI.VerifyElementDisabled(pageTitle);

        public void EnterFirstName(string firstName) => _WebUI.SetText(employeeFirstInput, firstName);
        public void EnterLastName(string lastName) => _WebUI.SetText(employeeLastNameInput, lastName);

        public void EnterOtherId(string otherId) => _WebUI.SetText(otherIdField, otherId);
        public void EnterDriverLicenseNum(string licenseNum) => _WebUI.SetText(driverLicenseNumberField, licenseNum);

        public string GetFirstName() => _WebUI.GetAttribute(employeeFirstInput, "value");
        public string GetLastName() => _WebUI.GetAttribute(employeeLastNameInput, "value");
        public string GetOtherId() => _WebUI.GetAttribute(otherIdField, "value");
        public string EnterDriverLicenseNum() => _WebUI.GetAttribute(driverLicenseNumberField, "value");

        public void ClickSave()
        {
            //_WebUI.ScrollToElement(saveButton);
            _WebUI.Click(saveButton);
        }
    }
}