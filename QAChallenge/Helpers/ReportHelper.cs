using System;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace QAChallenge.Helpers
{
    public class ReportHelper
    {
        public static ExtentReports extent;
        public static ExtentHtmlReporter htmlreporter;

        private static ThreadLocal<ExtentTest> extenttest = new ThreadLocal<ExtentTest>();

        public static ExtentTest Extenttest
        {
            get
            {
                return extenttest.Value;
            }
            set
            {
                extenttest.Value = value;
            }
        }

        public static void StartExtentReport(string projectPath)
        {
            htmlreporter = new ExtentHtmlReporter(projectPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlreporter);
        }

        public static void CloseExtentReport()
        {
            extent.Flush();
        }

        //public static void APITestCase(string name, string description)
        //{
        //    Extenttest = AddAPITestCaseName(name, description);
        //}

        //public static void WebTestCase(string name, string description)
        //{
        //    Extenttest = AddTestCaseName(name, description);
        //}

        public static void TestCasePassed()
        {
            Extenttest.Pass("Tests passed");
        }
        public static ExtentTest AddTestCaseName(string TestCaseName, string Description)
        {
            return extent.CreateTest(TestCaseName , Description);
        }
    }
}
