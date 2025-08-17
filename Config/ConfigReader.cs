using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace C_Sharp_Selenium_NUnit.Config
{
    public static class ConfigReader
    {
        public static TestProfile Load()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "TestConfig.json");

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Config file not found: {filePath}");

            string json = File.ReadAllText(filePath);
            var profile = JsonConvert.DeserializeObject<TestProfile>(json);

            if (profile == null)
                throw new Exception("Failed to load test settings.");

            return profile;
        }
    }

    public class TestProfile
    {
        public string? Environment { get; set; }
        public string? Browser { get; set; }
        public string? BaseUrl { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
