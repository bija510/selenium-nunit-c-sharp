using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using excel = Microsoft.Office.Interop.Excel;
using NUnit.Framework;
using System;
using System.IO;

namespace C_Sharp_Selenium_NUnit.Examples
{
    [TestFixture]
    public class ExcelUtility
    {
        /*****************************************************************************
        1. This is the Jar we need to download from --new get package manager--and 
        2. Refrence-->r-Click-->Add refrence---> check<---MicrosoftCSharp--->
        ******************************************************************************/
        [Test]
        public static void ReadExcelSheet()
        {
            excel.Application x1app = new excel.Application();
            excel.Workbook x1workbook = x1app.Workbooks.Open(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..")) + "\\Data\\newdata.xlsx");
            excel.Worksheet x1worksheet = (excel.Worksheet)x1workbook.Sheets[1]; // Explicit cast added
            excel.Range x1range = x1worksheet.UsedRange;

            // Fix: Cast the cell values to string explicitly
            string facebookURL = Convert.ToString((x1range.Cells[1, 1] as excel.Range)?.Value2); // [Row, Column]
            string amazonURL = Convert.ToString((x1range.Cells[2, 1] as excel.Range)?.Value2);
            string youtubeURL = Convert.ToString((x1range.Cells[3, 1] as excel.Range)?.Value2);

            Console.WriteLine(facebookURL);
            Console.WriteLine(amazonURL);
            Console.WriteLine(youtubeURL);

            // Cleanup resources
            x1workbook.Close(false);
            x1app.Quit();
        }
    }
}
