using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommsecPOM.Pages.BaseClass
{
    ///[SetUpFixture]
    public class BasePage
    {
        public IWebDriver driver;
        protected ExtentReports extent = null;
        protected ExtentTest test = null;
        private string browser = System.Configuration.ConfigurationManager.AppSettings["Browser"];
        private string url = System.Configuration.ConfigurationManager.AppSettings["Url"];
        //log4Net
        public log4net.ILog log;


        [OneTimeSetUp]
        public void Setup()
        {
            //String testName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            String testName = "OrangePOM";
            String currentDate = DateTime.Now.ToString("dd-MM-yyyyHHmmss");
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(@"C:\Users\Thomas\source\repos\CommsecPOM\CommsecPOM\ExtentReports\"+currentDate+"_" + testName+"_Result.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("OS", System.Environment.OSVersion.ToString());
            extent.AddSystemInfo("MachineName", System.Environment.MachineName);
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("User Name", System.Environment.UserName);

            //log4Net
            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            extent.Flush();
        }

        [SetUp]
        public void BeforeTest()
        {
            Console.WriteLine("Setup driver");
            StartBrowser(browser);
            driver.Manage().Window.Maximize();
            driver.Url = url;
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void AfterTest()
        {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
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
                        test.Log(Status.Fail, "Snapshot below: " +test.AddScreenCaptureFromPath("Screenshots\\" + fileName));
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

            test.Log(logstatus, "Test ended with " +logstatus + stacktrace);
            driver.Quit();
            extent.Flush();

        }

        public static string Capture(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var reportPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(reportPath + "ExtentReports\\" + "Screenshots");
            var finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "ExtentReports\\Screenshots\\" + screenShotName;
            var localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return reportPath;
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public void StartBrowser(string browserName)
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
    }
}
