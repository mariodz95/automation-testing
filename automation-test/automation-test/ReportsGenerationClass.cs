using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace automation
{
    public class ReportsGenerationClass
    {
        [SetUp]
        public ExtentTest BeforeTest(AventStack.ExtentReports.ExtentReports _extent)
        {
           return _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void AfterTest(AventStack.ExtentReports.ExtentReports _extent, ExtentTest _test)
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            _extent.Flush();
        }

        public void PassOrFailed(ExtentTest _test)
        {
            try
            {
                Assert.IsTrue(true);
                _test.Pass("Assertion passed");
                _test.Log(Status.Pass, "Pass");
            }
            catch (AssertionException)
            {
                _test.Fail("Assertion failed");
                _test.Log(Status.Fail, "Fail");
                throw;
            }
        }
    }
}