using NUnit.Framework;
using C_Sharp_Selenium_NUnit.BaseClass;
using C_Sharp_Selenium_NUnit.Pages;

namespace C_Sharp_Selenium_NUnit.Tests
{
    [TestFixture]
    public class SeleniumWrapperDemoTest : BaseTest
    {
        // Yes — in C#, the underscore (_) prefix is a common naming convention for private fields.

        private RegistrationPage _registration;

        [SetUp]
        public void SetUpPage() => _registration = new RegistrationPage();

        [Test, Order(1)]
        public void TestOpenRegistrationPage()
        {
            _registration.Open();
            _registration.EnterFirstName("John");
            Assert.That(_registration.IsSkillVisible());
        }

        [Test, Order(2)]
        public void TestFillBasicInfoAndSelectSkills()
        {
            _registration.Open();
            _registration.EnterFirstName("John");
            _registration.EnterLastName("Doe");
            _registration.EnterEmail("john.doe@example.com");
            _registration.EnterPhone("1234567890");

            _registration.SelectSkillByText("Java");
            _registration.SelectSkillByValue("APIs");
            _registration.SelectSkillByIndex(5);

            Assert.That(_registration.IsSkillVisible());
        }

        [Test, Order(3)]
        public void TestCheckAndUncheckHobbies()
        {
            _registration.Open();
            _registration.CheckMovies();
            _registration.UncheckMovies();
        }

        [Test]
        public void Click_Checkbox_Movies_ShouldBeSelected()
        {
            _registration.Open();
            _registration.ClickMovies();
            Assert.That(_registration.IsMoviesChecked(), Is.True);
        }

        [Test]
        public void SetText_FirstName_ShouldSetValue()
        {
            _registration.Open();
            string name = "Victor";
            _registration.EnterFirstName(name);
            Assert.That(_registration.GetFirstNameValue(), Is.EqualTo(name));
        }

        [Test]
        public void SelectDropdownByText_SkillsDropdown_ShouldSelectCorrectOption()
        {
            _registration.Open();
            string expectedSkill = "Java";
            _registration.SelectSkillByText(expectedSkill);
            Assert.That(_registration.GetSelectedSkill(), Is.EqualTo(expectedSkill));
        }

        [Test, Order(4)]
        public void TestDropdownAndScreenshot()
        {
            _registration.Open();
            _registration.SelectSkillByText("Java");
            _registration.TakeSkillsScreenshot("SkillDDL");
            Assert.That(_registration.IsSkillTextCorrect("Java"));
        }

        [Test, Order(5)]
        public void TestScrollAndMouseOver()
        {
            _registration.Open();
            _registration.ScrollToSkipLink();
            _registration.MouseOverSkipLink();
            Assert.That(_registration.IsSkipVisible());
        }
    }
}
