
using BC.Selenium.WebUI;
using OpenQA.Selenium;
using System;

namespace Modular.CSharp.TestDemo.PageObjects
{
    public class RegisterPage
    {
        private readonly IWebDriver? Driver;
        private readonly WebUI _WebUI;

        public RegisterPage(IWebDriver? driver)
        {
            Driver = driver;
            _WebUI = new WebUI(driver);
        }

        private readonly By firstNameTxt = By.CssSelector("input[placeholder='First Name']");
        private readonly By lastNameTxt = By.CssSelector("input[placeholder='Last Name']");
        private readonly By addressTxt = By.TagName("textarea");
        private readonly By emailTxt = By.CssSelector("input[type='email']");
        private readonly By phoneTxt = By.CssSelector("input[type='tel']");
        private readonly By genderMaleRdo = By.CssSelector("input[value='Male']");
        private readonly By genderFemaleRdo = By.CssSelector("input[value='FeMale']");
        private readonly By hobbiesCheckboxes = By.CssSelector("input[type='checkbox']");
        private readonly By skillsDropdown = By.XPath("//select[@id='Skill']");

        private readonly By passwordTxt = By.Id("firstpassword");
        private readonly By confirmPasswordTxt = By.Id("secondpassword");
        private readonly By submitBtn = By.Id("submitbtn");

        private const string Url = "https://demo.automationtesting.in/Register.html";


        public void Open() => _WebUI.NavigateToUrl(Url);

        public void EnterFirstName(string firstName) =>
            _WebUI.SetText("First Name Txt", firstNameTxt, firstName);

        public void EnterLastName(string lastName) =>
            _WebUI.SetText("Last Name Txt", lastNameTxt, lastName);

        public void EnterAddress(string address) =>
            _WebUI.SetText("Address Txt", addressTxt, address);

        public void EnterEmail(string email) =>
            _WebUI.SetText("Email Txt", emailTxt, email);

        public void EnterPhone(string phone) =>
            _WebUI.SetText("Phone Txt", phoneTxt, phone);

        public void SelectGender(string gender)
        {
            if (gender.Equals("Male", StringComparison.OrdinalIgnoreCase))
                _WebUI.Click("Gender Male Radio", genderMaleRdo);
            else if (gender.Equals("Female", StringComparison.OrdinalIgnoreCase))
                _WebUI.Click("Gender Female Radio", genderFemaleRdo);
            else
                throw new ArgumentException($"Invalid gender value: {gender}");
        }

        public void CheckHobbiesCheckboxe() =>
           _WebUI.Check("Hobbies Chk", hobbiesCheckboxes);

        public void SelectDropDownLabel(String label) =>
            _WebUI.SelectDropdownByText("Skills Dropdown" , skillsDropdown, label);

        public void EnterPassword(string password) =>
            _WebUI.SetText("Password Txt", passwordTxt, password);

        public void EnterConfirmPassword(string password) =>
            _WebUI.SetText("Confirm Password Txt", confirmPasswordTxt, password);

        public void Submit() =>
            _WebUI.Click("Submit Btn", submitBtn);
    }
}
