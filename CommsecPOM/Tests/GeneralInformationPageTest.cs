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
    public class GeneralInformationPageTest : BasePage
    {
        LoginPage loginPage;
        HomePage homePage;
        GeneralInfomationPage generalInfomationPage;

        /*[SetUp]
        public void init()
        {
            loginPage = new LoginPage(GetDriver());
            homePage = loginPage.LoginToOrangePage("Admin", "admin123");
            homePage.clickAdmin();
            homePage.clickOrganizationMenu();
            generalInfomationPage = homePage.gotoGeneralInfomationPage();

        }*/

        [Test]
        public void generalInformationPageTest()
        {
            log.Info("Log4net is starting here with General Infomation Test");
            loginPage = new LoginPage(GetDriver());
            homePage = loginPage.LoginToOrangePage("Admin", "admin123");
            homePage.clickAdmin();
            homePage.clickOrganizationMenu();
            generalInfomationPage = homePage.gotoGeneralInfomationPage();

            log.Info("Check SubTitle");
            test.Info("Check SubTitle");
            string subTitle = generalInfomationPage.getSubTitle();
            Assert.IsTrue(subTitle.Equals("General Information"));

            log.Info("Check Organization Name");
            test.Info("Check Organization Name");
            string orgName = generalInfomationPage.getOrganizationName();
            Console.WriteLine(orgName);
            Thread.Sleep(1500);
            Assert.AreEqual("OrangeHRM (Pvt) Ltd", orgName);

            log.Info("Number Of Employees");
            test.Info("Number Of Employees");
            string numberEmp = generalInfomationPage.getNumberOfEmployee();
            Assert.AreEqual("9", numberEmp);

            log.Info("Log out");
            test.Info("Log out");
            homePage.LogoutHomePage();

        }
 
       /* [Test]
        public void verifyGeneralInfomationPageSubTitle()
        {
            string subTitle = generalInfomationPage.getSubTitle();
            Assert.IsTrue(subTitle.Equals("General Information"));

        }

        [Test]
        public void checkOrganizationName()
        {
            string orgName = generalInfomationPage.getOrganizationName();
            Console.WriteLine(orgName);
            Thread.Sleep(1500);
            Assert.AreEqual("OrangeHRM (Pvt) Ltd",orgName);

        }

        [Test]
        public void checkNumberOfEmployees()
        {
            string numberEmp = generalInfomationPage.getNumberOfEmployee();
            Assert.AreEqual("9", numberEmp);
        }
        */
    }
}
