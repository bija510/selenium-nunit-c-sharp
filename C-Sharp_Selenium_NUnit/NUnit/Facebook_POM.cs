using C_Sharp_Selenium_NUnit.BaseClass;
using C_Sharp_Selenium_NUnit.PageObject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_Selenium_NUnit.Test_Cases
{
    [TestFixture]
    public class Facebook_POM : BaseTest
    {
        [Test]
        public void testMethod1()
        {
            var searchPage = new SignUpPage(driver);
            var resultpage = searchPage.NavigatetoResultPage();
            var channelpage = resultpage.NavigatetoChannel();

            String actChannelName = channelpage.getChannelName();
            String expChannelName = "Log Into Facebook";
            Assert.IsTrue(actChannelName.Equals(expChannelName));
            Thread.Sleep(3000);

        }
    }
}
