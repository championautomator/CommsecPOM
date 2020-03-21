using AventStack.ExtentReports;
using CommsecPOM.Pages.BaseClass;
using CommsecPOM.Pages.PagesClass;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommsecPOM.Tests
{
    [TestFixture]
    public class TimeSheetsPageTest : BasePage
    {
        LoginPage loginPage;
        HomePage homePage;
        TimeSheetsPage timeSheetsPage;

        [Test]
        public void goToTimeSheetPage()
        {
            
            //test = extent.CreateTest("Go To Time Sheet Page").Info("Time Sheet Page Test Started");
            loginPage = new LoginPage(GetDriver());

            test.Log(Status.Info, "Login To Orange Page");
            homePage = loginPage.LoginToOrangePage("Admin", "admin123");
            timeSheetsPage = homePage.goToTimeSheetsPage();
            Thread.Sleep(1000);

            test.Log(Status.Info, "Enter Employee Name");
            timeSheetsPage.EnterEmployeeName("Thomas Fleming");
            timeSheetsPage.retreiveStatusMessage();

            test.Log(Status.Info, "Add Time Sheet Date");
            timeSheetsPage.AddTimeSheetDate("2020-01-12");
            Thread.Sleep(3000);

            test.Log(Status.Info, "Logout Home Page");
            homePage.LogoutHomePage();

            //ExcelDataOperation.readExcelData();

        }

    }
}
