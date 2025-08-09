using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

public static class ExtentReportManager
{
    private static ExtentReports? extent;
    private static readonly object _lock = new object();

    public static ExtentReports GetInstance(string browser, string environment)
    {
        if (extent == null)
        {
            lock (_lock)
            {
                if (extent == null)
                {
                    string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
                    string reportDir = Path.Combine(projectRoot, "Reports");
                    Directory.CreateDirectory(reportDir);

                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                    string reportName = $"Report_{browser}_{environment}_{timestamp}.html";
                    string reportPath = Path.Combine(reportDir, reportName);

                    var sparkReporter = new ExtentSparkReporter(reportPath);
                    sparkReporter.Config.DocumentTitle = "Automation Test Report";
                    sparkReporter.Config.ReportName = "Selenium NUnit Test Report";

                    extent = new ExtentReports();
                    extent.AttachReporter(sparkReporter);

                    // Add system/environment info here
                    //extent.AddSystemInfo("User Name", Environment.UserName);
                    extent.AddSystemInfo("User Name", "AdamPC");

                    extent.AddSystemInfo(".NET Version", Environment.Version.ToString());
                    extent.AddSystemInfo("Test Framework", "NUnit " + typeof(NUnit.Framework.TestAttribute).Assembly.GetName().Version);
                    extent.AddSystemInfo("Run Start Time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    extent.AddSystemInfo("Git Branch", Environment.GetEnvironmentVariable("GITHUB_REF") ?? "N/A");

                    //extent.AddSystemInfo("Computer Name", Environment.MachineName);
                    extent.AddSystemInfo("Computer Name", "AUT-VM-M01");

                    extent.AddSystemInfo("Environment", environment);
                    extent.AddSystemInfo("TesterName", "John Doe"); // You can make this dynamic too
                    extent.AddSystemInfo("OS", Environment.OSVersion.ToString());
                    extent.AddSystemInfo("Browser name", browser);

                    Console.WriteLine($"[ExtentReports] Report will be generated at: {reportPath}");
                }
            }
        }
        return extent;
    }

    public static void Flush()
    {
        extent?.Flush();
    }
}
