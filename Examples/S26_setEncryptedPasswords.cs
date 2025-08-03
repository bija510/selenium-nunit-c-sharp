using C_Sharp_Selenium_NUnit.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Examples
{
    [TestFixture]
    class S26_setEncryptedPasswords
    {
        private IWebDriver? driver;

        //For Encoding: https://stackoverflow.com/questions/7185834/encode-and-decode-in-c-sharp-asp-net

        public string EncodeServerName(string ServerName)
        {
            byte[] NameEncodein = new byte[ServerName.Length];
            NameEncodein = System.Text.Encoding.UTF8.GetBytes(ServerName);
            string EcodedName = Convert.ToBase64String(NameEncodein);
            return EcodedName;
        }
        //and Decoding:

        public string DecoAndGetServerName(string Servername)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder strDecoder = encoder.GetDecoder();
            byte[] to_DecodeByte = Convert.FromBase64String(Servername);
            int charCount = strDecoder.GetCharCount(to_DecodeByte, 0, to_DecodeByte.Length);
            char[] decoded_char = new char[charCount];
            strDecoder.GetChars(to_DecodeByte, 0, to_DecodeByte.Length, decoded_char, 0);
            string Name = new string(decoded_char);

            return Name;
        }
        [Test]
        public void setEncryptedPassword()
        {
            driver = new ChromeDriver();
            driver.Url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
            Thread.Sleep(2000);

            var userNameTxtBx = driver.FindElement(By.XPath("//input[@name='username']"));
            userNameTxtBx.SendKeys("Admin");

            var passwordTxtBx = driver.FindElement(By.XPath("//input[@name='password']"));
            passwordTxtBx.SendKeys(DecoAndGetServerName("YWRtaW4xMjM="));

            var loginBtn = driver.FindElement(By.XPath("//button[@type='submit']"));
            loginBtn.Click();

            Assert.That(driver.Url, Does.Contain("dashboard"));

        }


        [Test]
        public void encodedAndDecoded()
        {
            String str = "admin123";

            String encodedString = EncodeServerName("apple");
            Console.WriteLine("encoded string:-" + encodedString);

            string decodedString = DecoAndGetServerName("YWRtaW4xMjM=");
            Console.WriteLine("decoded string:-" + decodedString);

        }
    }
}
