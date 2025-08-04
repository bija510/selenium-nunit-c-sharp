using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BC.Selenium.WebUI;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using C_Sharp_Selenium_NUnit.BaseClass;
using System.Buffers.Text;

namespace C_Sharp_Selenium_NUnit.Tests
{
    [TestFixture]
    public class SeleniumWrapperDemoTest : BaseTest
    {
        [Test, Order(1)]
        public void TestOpenRegistrationPage()
        {
            WebUI.NavigateToUrl(baseUrl);
            WebUI.WaitForPageLoad();
            WebUI.SetText(By.CssSelector("input[placeholder='First Name']"), "John");
            Assert.That(WebUI.VerifyElementPresent(By.Id("Skills")));
        }

        [Test, Order(2)]
        public void TestFillBasicInfoAndSelectSkills()
        {
            WebUI.NavigateToUrl("https://demo.automationtesting.in/Register.html");

            WebUI.SetText(By.CssSelector("input[placeholder='First Name']"), "John");
            WebUI.SetText(By.CssSelector("input[placeholder='Last Name']"), "Doe");
            WebUI.SetText(By.CssSelector("input[type='email']"), "john.doe@example.com");
            WebUI.SetText(By.Id("phone"), "1234567890");

            WebUI.SelectOptionByLabel(By.Id("Skills"), "Java");
            WebUI.SelectOptionByValue(By.Id("Skills"), "APIs");
            WebUI.SelectOptionByIndex(By.Id("Skills"), 5);

            Assert.That(WebUI.VerifyElementVisible(By.Id("Skills")));
        }

        [Test, Order(3)]
        public void TestCheckAndUncheckHobbies()
        {
            WebUI.NavigateToUrl("https://demo.automationtesting.in/Register.html");

            // Check 'Movies' checkbox
            WebUI.Check(By.XPath("//input[@type='checkbox' and @value='Movies']"));
            
            // Uncheck 'Movies' checkbox
            WebUI.Uncheck(By.XPath("//input[@type='checkbox' and @value='Movies']"));
            
        }
        [Test]
        public void Click_Checkbox_Movies_ShouldBeSelected()
        {
            WebUI.NavigateToUrl("https://demo.automationtesting.in/Register.html");

            var moviesCheckbox = By.XPath("//input[@type='checkbox' and @value='Movies']");
            WebUI.Click(moviesCheckbox);

            Assert.That(WebUI.IsSelected(moviesCheckbox), Is.True, "'Movies' checkbox should be selected after click.");
        }

        [Test]
        public void SetText_FirstName_ShouldSetValue()
        {
            WebUI.NavigateToUrl("https://demo.automationtesting.in/Register.html");

            var firstNameInput = By.XPath("//input[@placeholder='First Nam']");
            string expectedFirstName = "Victor";

            WebUI.SetText(firstNameInput, expectedFirstName);

            string actualFirstName = WebUI.GetAttribute(firstNameInput, "value");
            Assert.That(actualFirstName, Is.EqualTo(expectedFirstName), "First Name input should contain the set value.");
        }

        [Test]
        public void SelectDropdownByText_SkillsDropdown_ShouldSelectCorrectOption()
        {
            WebUI.NavigateToUrl("https://demo.automationtesting.in/Register.html");

            var skillsDropdown = By.Id("Skills");
            string expectedSkill = "Java";

            WebUI.SelectDropdownByText(skillsDropdown, expectedSkill);

            string selectedOption = WebUI.GetSelectedDropdownText(skillsDropdown);
            Assert.That(selectedOption, Is.EqualTo(expectedSkill), "Skills dropdown should have the selected option.");
        }
        [Test, Order(4)]
        public void TestDropdownAndScreenshot()
        {
            WebUI.NavigateToUrl("https://demo.automationtesting.in/Register.html");

            WebUI.SelectOptionByLabel(By.Id("Skills"), "Java");
            WebUI.TakeScreenshot("SkillDDL"); // Screenshot saved with timestamp

            Assert.That(WebUI.VerifyElementText(By.Id("Skills"), "Java"));
        }

        [Test, Order(5)]
        public void TestScrollAndMouseOver()
        {
            WebUI.NavigateToUrl("https://demo.automationtesting.in/Register.html");

            // Scroll to footer link (using its partial text)
            WebUI.ScrollToElement(By.PartialLinkText("Skip"));
            WebUI.MouseOver(By.PartialLinkText("Skip"));

            Assert.That(WebUI.VerifyElementVisible(By.PartialLinkText("Skip")));
        }
    }
}
