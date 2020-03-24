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
        //By admin = By.XPath("//b[contains(text(),'Admin')]");
        //By oganizationMenu = By.Id("menu_admin_Organization");
        //By generalInformation = By.Id("menu_admin_viewOrganizationGeneralInformation");

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
            return driver.FindElement(organizationName).GetAttribute("value");
        }

        public string getNumberOfEmployee()
        {
            return driver.FindElement(numberOfEmployee).Text;
        }

      /*  public void clickAdmin()
        {
            driver.FindElement(admin).Click();
        }

        public void clickOrganizationMenu()
        {
            driver.FindElement(oganizationMenu).Click();
        }

        public void clickGeneralInformation()
        {
            driver.FindElement(generalInformation).Click();
        }
        */
    }
}
