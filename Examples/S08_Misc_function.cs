using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace C_Sharp_Selenium_NUnit.Examples
{
    [TestFixture]
    class S08_Misc_function
    {
        // The? is a safety feature to help you avoid NullReferenceException by reminding you to check
        // if the variable is null before using it.
        // safer, allows null, avoids compiler warning

        private IWebDriver? driver;
        [Test]
        public void OtherMisc()
        {
            driver = new ChromeDriver();
            driver.Url= "https://www.facebook.com/login/";
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

            driver.Manage().Cookies.DeleteAllCookies();
            Console.WriteLine("Current Url:- " + driver.Url);
            Console.WriteLine("Current page title:- " + driver.Title);
            Console.WriteLine("Current window Number(handles):- " + driver.CurrentWindowHandle);

            driver.FindElement(By.XPath("//button[@id='loginbutton']")).Submit(); //To submit the Just for form & Enter

        }
    }
}
