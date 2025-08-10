using NUnit.Framework;
using C_Sharp_Selenium_NUnit.BaseClass;
using C_Sharp_Selenium_NUnit.PageObjects;

namespace C_Sharp_Selenium_NUnit.Tests
{
    [TestFixture]
    public class LoginTest : BaseTest
    {

        [Test]
        public void Login()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.OpenLoginPage(baseUrl);

            // Test valid credentials
            loginPage.Login(userName, password);
        }

    }
}
