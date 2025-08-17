using AventStack.ExtentReports.MarkupUtils;
using C_Sharp_Selenium_NUnit.BaseClass;
using C_Sharp_Selenium_NUnit.PageObjects;
using NUnit.Framework;

namespace C_Sharp_Selenium_NUnit.Tests
{
    [TestFixture]
    public class LoginTest : BaseTest
    {

        [Test]
        [Category("Smoke")]   // applies only to this test
        public void Login()
        {
            test!.Info(MarkupHelper.CreateLabel("Verify Login successfully", ExtentColor.Blue));
            var loginPage = new LoginPage(Driver);
            loginPage.OpenLoginPage(baseUrl);

            // Test valid credentials
            loginPage.Login(userName, password);
        }

    }
}
