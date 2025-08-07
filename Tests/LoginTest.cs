using NUnit.Framework;
using C_Sharp_Selenium_NUnit.BaseClass;
using C_Sharp_Selenium_NUnit.PageObjects;

namespace C_Sharp_Selenium_NUnit.Tests
{
    [TestFixture]
    public class LoginTest : BaseTest
    {
        string userName = Config.UserName;
        string password = Config.Password;

        [Test]
        public void TestLoginValidateCredentials()
        {
            var loginPage = new LoginPage(Driver);
            loginPage.OpenLoginPage(baseUrl);

            // Test valid credentials
            loginPage.Login(userName, password);
            Assert.That(Driver.Url.Contains("dashboard"));
        }

    }
}
