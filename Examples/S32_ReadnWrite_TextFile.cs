﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace C_Sharp_Selenium_NUnit.Examples
{
    [TestFixture]
    class S32_ReadnWrite_TextFile
    {
        [Test]
        public static void readwrite()
        {          
            try
            {
                string filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..")) + "\\Data\\TextFile.txt";          
                List<string> lines = new List<string>();
                lines = File.ReadLines(filePath).ToList();

                foreach (String line in lines)
                {
                    Console.WriteLine(line);
                }
                lines.Add("Hello world 9-26");
                File.WriteAllLines(filePath, lines);              
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}




