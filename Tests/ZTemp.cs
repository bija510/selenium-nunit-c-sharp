using C_Sharp_Selenium_NUnit.BaseClass;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Sharp_Selenium_NUnit.Data;

namespace C_Sharp_Selenium_NUnit.Tests
{
    class ZTemp : BaseTest
    {
        [Test]
        [Category("Regression")]   // applies only to this test
        public void TestUsingData()
        {
            Console.WriteLine("===>"+pd.FirstName);  // Adam
            Console.WriteLine("===>" + pd.LastName);   // Smith
        }
    }
}
