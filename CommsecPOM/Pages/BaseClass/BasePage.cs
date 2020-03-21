using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommsecPOM.Pages.BaseClass
{
    //[SetUpFixture]
    [TestFixture]
    public class BasePage
    {
        public IWebDriver driver;
        public ExtentReports extent = null;
        private string browser = System.Configuration.ConfigurationManager.AppSettings["Browser"];
        private string url = System.Configuration.ConfigurationManager.AppSettings["Url"];

        [OneTimeSetUp]
        //[SetUp]
        public void Initialization()
        {
            Console.WriteLine("Setup driver");

            //driver = new ChromeDriver();
            //startBrowser("Chrome");
            startBrowser(browser);
            driver.Manage().Window.Maximize();
            driver.Url = url;

            extent = new ExtentReports();
            String testName = GetType().Name;
            String currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(@"C:\Users\Thomas\source\repos\CommsecPOM\CommsecPOM\ExtentReports\"+currentDate+"_" + testName+"_Result.html");
            extent.AddSystemInfo("OS", System.Environment.OSVersion.ToString());
            extent.AddSystemInfo("MachineName", System.Environment.MachineName);
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("User Name", System.Environment.UserName);
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        //[TearDown]
        public void tearDown()
        {
            Console.WriteLine("Quit driver");
            driver.Quit();
            extent.Flush();
        

        }

        public void startBrowser(string browserName)
        {
            if (browserName.ToLower().Equals("chrome"))
            {
                driver = new ChromeDriver();
            }
            else if (browserName.ToLower().Equals("firefox"))
            {
                driver = new FirefoxDriver();
            }
            else
            {
                driver = new ChromeDriver();
            }

        }

        /*public void checkTestStatus()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? “” : string.Format(“{ 0}”, TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    String fileName = “Screenshot_” +time.ToString(“h_mm_ss”) + “.png”;
                    String screenShotPath = Capture(_driver, fileName);
                    _test.Log(Status.Fail, “Fail”);
                    _test.Log(Status.Fail, “Snapshot below: “ +_test.AddScreenCaptureFromPath(“Screenshots\\” +fileName));
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
            */
            //_test.Log(logstatus, “Test ended with “ +logstatus + stacktrace);
            //_extent.Flush();
            //_driver.Quit();
        //}





        //public ExtentReports extent = null;

        /*[OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(@"C:\Users\Thomas\source\repos\CommsecPOM\CommsecPOM\ExtentReports\Result.html");
            //ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(@"C:\temp\Result.html");
            extent.AddSystemInfo("OS", System.Environment.OSVersion.ToString());
            extent.AddSystemInfo("MachineName", System.Environment.MachineName);
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("User Name", System.Environment.UserName);

            extent.AttachReporter(htmlReporter);
      
        }*/

        /*[OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }*/
    }
}
