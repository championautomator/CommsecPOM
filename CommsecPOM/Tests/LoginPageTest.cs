using AventStack.ExtentReports;
using CommsecPOM.Pages.BaseClass;
using CommsecPOM.Pages.PagesClass;
using CommsecPOM.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsecPOM.Tests
{
    class LoginPageTest : BasePage
    {
        ExtentTest test = null;

        [SetUp]
        public void beforeTest()
        {
            //test = extent.CreateTest("VerifyOrangeLogin").Info("Test Started");
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
        }

        //https://youtu.be/pbUuWpUZeWk
        //https://medium.com/@djhablog/selenium-with-nunit-extentreports-df8ac63acb2c

        [TearDown]
        public void afterTest()
        {
        /*    var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    String fileName = "Screenshot_" +time.ToString("h_mm_ss") + ".png";
                    String screenShotPath = Capture(driver, fileName);
                    test.Log(Status.Fail, "Fail");
                    test.Log(Status.Fail, "Snapshot below: " +test.AddScreenCaptureFromPath("Screenshots\\" +fileName));
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

            test.Log(logstatus, "Test ended with " +logstatus + stacktrace);*/
            //_test.Log(logstatus, “Test ended with “ +logstatus + stacktrace);
            //extent.Flush();

        }


        public static string Capture(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var reportPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(reportPath + "Reports\\" + "Screenshots");
            var finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports\\Screenshots\\" +screenShotName;
            var localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return reportPath;
        }

        [Test]
        public void VerifyOrangeLogin()
        {
            try
            {
                //test = extent.CreateTest("VerifyOrangeLogin").Info("Test Started");

                string username = System.Configuration.ConfigurationManager.AppSettings["Username"];
                string password = System.Configuration.ConfigurationManager.AppSettings["Password"];
                Console.WriteLine("LoginToApplication");

                LoginPage login = new LoginPage(driver);

                //HomePage homepage = login.LoginToOrangePage("Admin", "admin123");
                test.Log(Status.Info, "Login to OrangeCRM");
                HomePage homepage = login.LoginToOrangePage(username, password);

                string homePageTitle = homepage.VerifyHomePageTitle();
                test.Log(Status.Info, "Verify Orange Homepage Title");
                Assert.AreEqual("OrangeHRM", homePageTitle);
            }
            catch (Exception e)
            {
                test.Error("Exception Message " + e.Message);
            }

        }

        [Test]
        public void VerifyOrangeLogin2()
        {
            //test = extent.CreateTest("VerifyOrangeLogin2").Info("Test Started");
            test.Log(Status.Fail, "VerifyOrangeLogin2");
            Console.WriteLine("VerifyOrangeLogin2");
        }

        [Test]
        public void VerifyOrangeLogin3()
        {
            //test = extent.CreateTest("VerifyOrangeLogin3").Info("Test Started");
            //test.Log(Status.Info, "VerifyOrangeLogin3");
            Console.WriteLine("VerifyOrangeLogin3");
        }

        [Test]
        public void VerifyOrangeLogin4()
        {
            //test = extent.CreateTest("VerifyOrangeLogin3").Info("Test Started");
           // test.Fail("FFFFF");
            //test.Log(Status.Error, "VerifyOrangeLogin4");
            Console.WriteLine("VerifyOrangeLogin4");
        }
    }
}
