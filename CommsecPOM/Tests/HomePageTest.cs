using AventStack.ExtentReports;
using CommsecPOM.Data;
using CommsecPOM.Pages.BaseClass;
using CommsecPOM.Pages.PagesClass;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsecPOM.Tests
{
    [TestFixture]
    public class HomePageTest : BasePage
    {
        LoginPage loginPage;
        HomePage homepage;

        [Test]
        public void VerifyOrangeHomePage()
        {

            //test = extent.CreateTest("VerifyOrangeHomePage").Info("Test Started");
            loginPage = new LoginPage(GetDriver());
            homepage = loginPage.LoginToOrangePage("Admin", "admin123");
           
            string homePage = homepage.VerifyAtHomePage();

            Console.WriteLine(homePage);

            //test.Log(Status.Info, "Check homepage");
            Assert.IsTrue(homePage.Equals("Welcome Admin"));


            //homepage.LogoutHomePage();
            //ExcelDataOperation.readExcelData();

        }

        [Test]
        public void VerifyOrangeHomePage1()
        {
            //test = extent.CreateTest("VerifyOrangeHomePage1").Info("Test Started");
            //test.Log(Status.Info, "VerifyOrangeHomePage1xxxxxx");
            //Assert.IsTrue(false);
        }

        [Test]
        public void VerifyOrangeHomePage2()
        {
            //test = extent.CreateTest("VerifyOrangeHomePage2").Info("Test Started");
           // test.Log(Status.Info, "VerifyOrangeHomePage2xxxxxxxx");
            //test.Log(Status.Error, "VerifyOrangeHomePage2");
           // test.Log(Status.Fail, "VerifyOrangeHomePage2fffffffff");
        }

    }
}
