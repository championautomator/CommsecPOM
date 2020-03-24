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
    [TestFixture]
    class LoginPageTest : BasePage
    {
       

        [Test]
        public void VerifyOrangeLogin()
        {
            try
            {
                log.Info("Log4net is starting here");
                string username = System.Configuration.ConfigurationManager.AppSettings["Username"];
                string password = System.Configuration.ConfigurationManager.AppSettings["Password"];
                Console.WriteLine("LoginToApplication");
                LoginPage login = new LoginPage(GetDriver());

                //HomePage homepage = login.LoginToOrangePage("Admin", "admin123");
                log.Info("Log4net: perfomr login.........");
                HomePage homepage = login.LoginToOrangePage(username, password);

                string homePageTitle = homepage.VerifyHomePageTitle();
                
                Assert.AreEqual("OrangeHRM", homePageTitle);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Message " + e.Message);
                log.Info("Exception Message " + e.Message);
            }

        }

        [Test]
        public void VerifyOrangeLogin2()
        {
 
            Console.WriteLine("VerifyOrangeLogin2");
        }

        [Test]
        public void VerifyOrangeLogin3()
        {
            Console.WriteLine("VerifyOrangeLogin3");
        }

        [Test]
        public void VerifyOrangeLogin4()
        {
            Console.WriteLine("VerifyOrangeLogin4");
        }
    }
}
