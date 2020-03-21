using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsecPOM.Pages.PagesClass
{
    public class GeneralInfomationPage
    {

        IWebDriver driver;

        public GeneralInfomationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By subTitle = By.Id("genInfoHeading");
        By organizationName = By.Id("organization_name");
        By numberOfEmployee = By.Id("numOfEmployees");

        public string verifyGeneralInfomationPageTitle()
        {
            return driver.Title.ToString();
        }

        public string getSubTitle()
        {
            return driver.FindElement(subTitle).Text;
        }

        public string getOrganizationName()
        {
            return driver.FindElement(organizationName).Text;
        }

        public string getNumberOfEmployee()
        {
            return driver.FindElement(numberOfEmployee).Text;
        }

    }
}
