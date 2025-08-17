using AventStack.ExtentReports.MarkupUtils;
using BC.Selenium.WebUI;
using C_Sharp_Selenium_NUnit.BaseClass;
using C_Sharp_Selenium_NUnit.PageObjects;
using Modular.CSharp.TestDemo.PageObjects;
using NUnit.Framework;

namespace C_Sharp_Selenium_NUnit.Tests
{
    [TestFixture]
    public class RegisterTest : BaseTest
    {
        private RegisterPage? _registerPage;

        [SetUp]
        public void TestSetup()
        {
            // Driver is already initialized in BaseTest.Setup()
            _registerPage = new RegisterPage(Driver!);
        }


        [Test]
        [Category("Sanity")]   // applies only to this test
        public void TestFillNameAndNumber()
        {
            _registerPage!.Open();
            _registerPage.EnterFirstName("John");
            _registerPage.EnterLastName("Doe");
            _registerPage.EnterAddress("123 Main St");
            _registerPage.EnterEmail("john.doe@example.com");
            _registerPage.EnterPhone("1234567890");
            Assert.Pass("Form submitted successfully");
        }

        [Test]
        [Category("Regression")]   // applies only to this test
        public void TestFillAgeAndHobbies()
        {
            _registerPage!.Open();
            _registerPage.SelectGender("Male"); // checkbox
            _registerPage.CheckHobbiesCheckboxe(); // checkbox
            _registerPage.SelectDropDownLabel("CSS");
            Assert.Pass("Form submitted successfully");
        }

        [Test]
        [Category("Sanity")]   // applies only to this test
        public void TestFillPasswordAndSubmit()
        {
            _registerPage!.Open();
            _registerPage.EnterPassword("Password123!");
            _registerPage.EnterConfirmPassword("Password123!");
            _registerPage.Submit();

            Assert.Pass("Form submitted successfully");
        }

    }
}