using BC.Selenium.WebUI;
using OpenQA.Selenium;

namespace C_Sharp_Selenium_NUnit.PageObjects
{
    class PersonalDetailsPage
    {
        private readonly IWebDriver? Driver;
        private readonly WebUI _WebUI;

        public PersonalDetailsPage(IWebDriver? driver)
        {
            Driver = driver;
            _WebUI = new WebUI(driver);
        }
        // Locators
        private readonly By employeeFirstNameTxt = By.Name("firstName");
        private readonly By employeeLastNameTxt = By.Name("lastName");
        private readonly By myInfoMenu = By.XPath("//div[@class='oxd-sidepanel-body']//li[6]");
        private readonly By pageTitle = By.XPath("//h6[text()='Personal Details']");
    
        private readonly By employeeIdField = By.XPath("//label[normalize-space()='Employee Id']/parent::div/following-sibling::div/input");
        private readonly By otherIdTxt = By.XPath("//label[normalize-space()='Other Id']/parent::div/following-sibling::div/input");
        private readonly By driverLicenseNumberTxt = By.XPath("//label[contains(text(),'License Number')]/parent::div/following-sibling::div/input");   
        private readonly By saveBtn = By.XPath("//button[@type='submit']");
       

        // Methods
        public void NavigateTo(string? url)
        {
            _WebUI.NavigateToUrl(url);
            _WebUI.WaitForElementVisible("Page Title", pageTitle);
        }

        public void ClickMyInfoMenu()
        {
            _WebUI.Click("My Info Btn", myInfoMenu);
            _WebUI.Delay(2);
        }
        public bool IsAt() => _WebUI.VerifyElementDisabled("Page Title", pageTitle);

        public void EnterFirstName(string? firstName) => _WebUI.SetText("Employee FirstName Txt", employeeFirstNameTxt, firstName);
        public void EnterLastName(string? lastName) => _WebUI.SetText("Employee LastName Txt", employeeLastNameTxt, lastName);

        public void EnterOtherId(string? otherId) => _WebUI.SetText("Other Txt", otherIdTxt, otherId);
        public void EnterDriverLicenseNum(string? licenseNum) => _WebUI.SetText("Driver License Number Txt", driverLicenseNumberTxt, licenseNum);

        public string GetFirstName() => _WebUI.GetAttribute("Employee FirstName Txt", employeeFirstNameTxt, "value");
        public string GetLastName() => _WebUI.GetAttribute("Employee LastName Txt", employeeLastNameTxt, "value");
        public string GetOtherId() => _WebUI.GetAttribute("Other Txt", otherIdTxt, "value");
        public string EnterDriverLicenseNum() => _WebUI.GetAttribute("Driver License Number Txt", driverLicenseNumberTxt, "value");

        public void ClickSave()
        {
            _WebUI.ScrollToPosition(0, 300); // Scroll down to make the button visible
            _WebUI.Delay(2);
            _WebUI.Click("Save Bth", saveBtn);
        }
    }
}