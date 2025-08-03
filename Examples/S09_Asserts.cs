using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace C_Sharp_Selenium_NUnit.Examples
{
    [TestFixture]
    class S09_Asserts
    {
        // The? is a safety feature to help you avoid NullReferenceException by reminding you to check
        private IWebDriver? driver;
        [Test]
        public void AssertExamples()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.letskodeit.com/practice";

            // Example:- 1
            IWebElement option1TxtBx = driver.FindElement(By.XPath("//input[@id='checkBoxOption1']"));
            Assert.That(option1TxtBx.Selected, Is.False);

            // Example:- 2
            IWebElement showHideTxtBx = driver.FindElement(By.XPath("//input[@id='displayed-text']"));
            Assert.That(showHideTxtBx.Displayed, Is.True);

            // Example:- 3
            String actTitle = "Practice Page";
            Assert.That(driver.Title, Is.EqualTo(actTitle));

            // Example:- 4
            String aFor = "apple";
            String bFor = "ball";
            Assert.That(aFor, Is.Not.EqualTo(bFor));

            Console.WriteLine("All Example 1, 2, 3 & 4 Passes Successfully");
        }
    }
}
