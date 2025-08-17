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
    class S15_WebTable_HtmlTable
    {
        private IWebDriver? driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void demo()
        {
            driver!.Url = "https://www.w3schools.com/html/html_tables.asp";
            IJavaScriptExecutor JS = (IJavaScriptExecutor)driver;
            JS.ExecuteScript("window.scrollBy(0,300)");

            //Example:-1 get all text
            IList<IWebElement> tableTd = driver.FindElements(By.XPath("//*[@id='customers']/tbody/tr/td"));
            Console.WriteLine("===========All text from table ===========");
            foreach(var ele in tableTd)
            {
                Console.WriteLine(ele.Text);
            }

            //Example:-2 get only rowOne text
            IList<IWebElement> row1 = driver.FindElements(By.XPath("//*[@id='customers']/tbody/tr[2]/td"));
            Console.WriteLine("=========All info From Row one==========");
            foreach(var ele in row1)
            {
                Console.WriteLine(ele.Text);
            }

        }

    [Test]
    public void runGetAnyText()
        {
        driver!.Url = "https://www.w3schools.com/html/html_tables.asp";
		IJavaScriptExecutor JS = (IJavaScriptExecutor)driver;
        JS.ExecuteScript("window.scrollBy(0,300)");
            Console.WriteLine(clickOrGetText("//table[@id='customers']", "UK" , "Contact"));
	}

    public String clickOrGetText(String tableXpath, String KeyVal, String colToGet) 
    {			
			int colIndex = -1;
        Boolean found = false;
        String retVal = "";

        IWebElement Table =  driver!.FindElement(By.XPath(tableXpath));
        IList<IWebElement> Rows =Table.FindElements(By.TagName("tr"));
        IList<IWebElement> ColHeaders = Rows[0].FindElements(By.TagName("th"));
        for (int i = 0; i < ColHeaders.Count; i++)
        {
            if (ColHeaders[i].Text.ToLower().Contains(colToGet.ToLower()))
            {
                //println ColHeaders.get(i).getText();
                colIndex = i;
                break;
            }
        }
    outerLoop:
        for (int i = 0; i < Rows.Count; i++)
        {
            IList<IWebElement> Cols = Rows[i].FindElements(By.TagName("td"));
            int colSize = Cols.Count();
            for (int j = 0; j < Cols.Count(); j++)
            {

                if (Cols[j].Text.ToLower().Contains(KeyVal.ToLower()))
                {
                    //return Cols.get(colIndex).click();
                    return Cols[colIndex].Text;

                }

            }
        }
        if (found)
        {
            return retVal;
        }
        else
        {
            throw new Exception(KeyVal + "Was NOt Found");

        }
        }

    }
}
