using CommsecPOM.Pages.BaseClass;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommsecPOM.Pages.PagesClass
{
    public class LoginPage
    {
        IWebDriver driver;

        By username = By.Id("txtUsername");
        By password = By.Id("txtPassword");
        By loginButton = By.Id("btnLogin");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public HomePage LoginToOrangePage(string userName, string passwrd)
        {
            driver.FindElement(username).SendKeys(userName);
            driver.FindElement(password).SendKeys(passwrd);
            driver.FindElement(loginButton).Click();
            return new HomePage(driver);
        }

        public void typeUserName(string userName)
        {
            driver.FindElement(username).SendKeys(userName);
        }

        public void typePassword(string passwrd)
        {
            driver.FindElement(password).SendKeys(passwrd);
        }

        public void clickLoginButton()
        {
            driver.FindElement(loginButton).Click();
        }
    }
}
