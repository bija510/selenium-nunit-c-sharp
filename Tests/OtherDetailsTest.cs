using AventStack.ExtentReports.MarkupUtils;
using BC.Selenium.WebUI;
using C_Sharp_Selenium_NUnit.BaseClass;
using C_Sharp_Selenium_NUnit.Data;
using C_Sharp_Selenium_NUnit.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Tests
{
    [TestFixture]
    public class OtherDetailsTest : BaseTest
    {
        private PersonalDetailsPage? personalDetailsPage;

        [Test]
        [Category("Smoke")]   // applies only to this test
        public void VerifyInfoMenuPage()
        {
            test!.Info(MarkupHelper.CreateLabel("Verify Login successfully", ExtentColor.Blue));
            var loginPage = new LoginPage(Driver);
            loginPage.OpenLoginPage(baseUrl);

            // Login to application
            loginPage.Login(userName, password);
            Thread.Sleep(2000); // Wait for the page to load

            test.Info(MarkupHelper.CreateLabel("Verify personal details page", ExtentColor.Blue));
            //Enter personal details
            personalDetailsPage = new PersonalDetailsPage(Driver);
            personalDetailsPage.ClickMyInfoMenu();
            
            personalDetailsPage.EnterFirstName(pd.FirstName);
            Assert.That(personalDetailsPage.GetFirstName(), Does.Contain(pd.FirstName));

            personalDetailsPage.EnterLastName(pd.LastName);
            Assert.That(personalDetailsPage.GetLastName(), Does.Contain(pd.LastName));

            personalDetailsPage.EnterOtherId(pd.OtherId);
            Assert.That(personalDetailsPage.GetOtherId(), Does.Contain(pd.OtherId));

            personalDetailsPage.EnterDriverLicenseNum(pd.DriverLicenseNum);
            Assert.That(personalDetailsPage.EnterDriverLicenseNum(), Does.Contain(pd.DriverLicenseNum));

            personalDetailsPage.ClickSave();

        }

    }
}