using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsecPOM.Pages.PagesClass
{

    public class TimeSheetsPage
    {
        IWebDriver driver;

        By employeeName = By.Name("time[employeeName]");
        By viewBtn = By.Id("btnView");
        By messageBox = By.XPath("//div[@class='message warning']");
        By addTimesheet = By.Id("btnAddTimesheet");
        By timeDate = By.Id("time_date"); //yyyy-mm-dd


        public TimeSheetsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnterEmployeeName(string inputName)
        {
            driver.FindElement(employeeName).Click();
            driver.FindElement(employeeName).SendKeys(inputName);
            driver.FindElement(viewBtn).Click();
        } 

        public void AddTimeSheetDate(string timedate)
        {
            driver.FindElement(addTimesheet).Click();
            driver.FindElement(timeDate).Click();
            driver.FindElement(timeDate).SendKeys(timedate);
            driver.FindElement(timeDate).SendKeys(Keys.Enter);
        }

        public void retreiveStatusMessage()
        {
            string msg = driver.FindElement(messageBox).Text.ToString();
            Console.WriteLine(msg);
        }





    }
}
