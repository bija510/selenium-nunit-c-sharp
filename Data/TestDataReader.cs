using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework.Interfaces;
using C_Sharp_Selenium_NUnit.Config;

namespace C_Sharp_Selenium_NUnit.Data
{
    public class TestDataReader
    {

        public static TestData Load()
        {
            string filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."))
                      + "/Data/TestData.json";

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Config file not found: {filePath}");

            string json = File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<TestData>(json);

            if (data == null)
                throw new Exception("Failed to load test settings.");

            return data;
        }
    }

    public class TestData
    {
        public required TestData pd { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmployeeId { get; set; }
        public string? OtherId { get; set; }
        public string? DriverLicenseNum { get; set; }
    }
}