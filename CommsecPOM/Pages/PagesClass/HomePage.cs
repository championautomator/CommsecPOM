using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommsecPOM.Pages.PagesClass
{
    public class HomePage
    {
        IWebDriver driver;

        By welcome = By.Id("welcome");
        By welcome_menu = By.Id("welcome-menu");
        By logout = By.XPath("//a[@href='/index.php/auth/logout']");
        //By timeSheets = By.XPath("//a[@href='/index.php/time/viewEmployeeTimesheet']");
        By timeSheets = By.LinkText("Timesheets");
        

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string VerifyHomePageTitle()
        {
            return driver.Title.ToString();
        }

        //[Obsolete]
        public string VerifyAtHomePage()
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           // wait.Until(ExpectedConditions.ElementIsVisible(welcome));

            return driver.FindElement(welcome).Text.ToString();
        }

        public TimeSheetsPage goToTimeSheetsPage()
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(ExpectedConditions.ElementIsVisible(timeSheets));
            Thread.Sleep(1500);
            driver.FindElement(timeSheets).Click();
            return new TimeSheetsPage(driver);
        }

        public void LogoutHomePage()
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(ExpectedConditions.ElementToBeClickable(welcome));
            //driver.FindElement(welcome).Click();

            IJavaScriptExecutor Js = (IJavaScriptExecutor)driver;
            Js.ExecuteScript("document.getElementById('welcome').click();");

            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait2.Until(ExpectedConditions.ElementToBeClickable(logout));

            driver.FindElement(logout).Click();
        }


    }
}
