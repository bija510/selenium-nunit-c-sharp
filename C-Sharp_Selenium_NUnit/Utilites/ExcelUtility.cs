using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using excel = Microsoft.Office.Interop.Excel;
using NUnit.Framework;
using System;
using System.IO;

namespace C_Sharp_Selenium_NUnit.Utilites
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
            excel.Worksheet x1worksheet = x1workbook.Sheets[1];
            excel.Range x1range = x1worksheet.UsedRange;

            string facebookURL = x1range.Cells[1][1].value2; //[Row] [col]
            string amazonURL = x1range.Cells[2][1].value2;
            string youtubeURL = x1range.Cells[3][1].value2;

            Console.WriteLine(facebookURL);
            Console.WriteLine(amazonURL);
            Console.WriteLine(youtubeURL);


        }
       
    }
}
