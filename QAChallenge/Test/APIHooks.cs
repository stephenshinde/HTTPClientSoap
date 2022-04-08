using System;
using NUnit.Framework;
using QAChallenge.Helpers;

namespace QAChallenge.Test
{
    [SetUpFixture]
    public class APIHooks
    {
      public static string currentDir = Environment.CurrentDirectory;
        public static string[] solutionpath = currentDir.Split("bin");
        [OneTimeSetUp]
        public void InitializeAPISettings()

        {
            ReportHelper.StartExtentReport(solutionpath[0] + @"/Reports/index.html");
            //ReportHelper.htmlreporter.LoadConfig("/Users/vinitarajak/SOAPProject/QAChallenge/QAChallenge/Config/extent-apiconfig.xml");
           // ReportHelper.StartExtentReport("/Users/vinitarajak/SOAPProject/QAChallenge/QAChallenge/Reports/index.html");
            ReportHelper.htmlreporter.LoadConfig(solutionpath[0] + @"/Config/extent-apiconfig.xml");
        }

        [OneTimeTearDown]
        public void TearDownAPISettings()
        {
            ReportHelper.CloseExtentReport();
        }
    }
}
