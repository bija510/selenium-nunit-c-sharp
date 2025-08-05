using OpenQA.Selenium;
using BC.Selenium.WebUI;

namespace C_Sharp_Selenium_NUnit.Pages
{
    public class RegistrationPage
    {
        private readonly string _url = "https://demo.automationtesting.in/Register.html";

        // Locators
        private By FirstNameInput => By.CssSelector("input[placeholder='First Name']");
        private By LastNameInput => By.CssSelector("input[placeholder='Last Name']");
        private By EmailInput => By.CssSelector("input[type='email']");
        private By PhoneInput => By.Id("phone");
        private By SkillsDropdown => By.Id("Skills");
        private By MoviesCheckbox => By.XPath("//input[@type='checkbox' and @value='Movies']");
        private By SkipLink => By.PartialLinkText("Skip");

        // Navigation
        public void Open() => WebUI.NavigateToUrl(_url);

        // Actions
        public void EnterFirstName(string firstName) => WebUI.SetText(FirstNameInput, firstName);
        public void EnterLastName(string lastName) => WebUI.SetText(LastNameInput, lastName);
        public void EnterEmail(string email) => WebUI.SetText(EmailInput, email);
        public void EnterPhone(string phone) => WebUI.SetText(PhoneInput, phone);

        public void SelectSkillByText(string skill) => WebUI.SelectDropdownByText(SkillsDropdown, skill);
        public void SelectSkillByValue(string value) => WebUI.SelectOptionByValue(SkillsDropdown, value);
        public void SelectSkillByIndex(int index) => WebUI.SelectOptionByIndex(SkillsDropdown, index);

        public void CheckMovies() => WebUI.Check(MoviesCheckbox);
        public void UncheckMovies() => WebUI.Uncheck(MoviesCheckbox);
        public void ClickMovies() => WebUI.Click(MoviesCheckbox);

        public bool IsMoviesChecked() => WebUI.IsSelected(MoviesCheckbox);
        public string GetFirstNameValue() => WebUI.GetAttribute(FirstNameInput, "value");

        public string GetSelectedSkill() => WebUI.GetSelectedDropdownText(SkillsDropdown);
        public bool IsSkillVisible() => WebUI.VerifyElementVisible(SkillsDropdown);
        public bool IsSkillTextCorrect(string expected) => WebUI.VerifyElementText(SkillsDropdown, expected);

        public void TakeSkillsScreenshot(string name) => WebUI.TakeScreenshot(name);

        public void ScrollToSkipLink() => WebUI.ScrollToElement(SkipLink);
        public void MouseOverSkipLink() => WebUI.MouseOver(SkipLink);
        public bool IsSkipVisible() => WebUI.VerifyElementVisible(SkipLink);
    }
}
