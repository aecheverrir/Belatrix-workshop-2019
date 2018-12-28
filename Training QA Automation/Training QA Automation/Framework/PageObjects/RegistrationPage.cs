using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Training_QA_Automation.Framework;

namespace Training_QA_Automation.Framework.PageObjects
{
    public class RegistrationPage
    {
        private IWebDriver driver;

        //Page Objects
        [FindsBy(How = How.Name, Using = "Email")]
        private IWebElement Email;

        [FindsBy(How = How.Id, Using = "sign-in-desk")]
        private IWebElement SignInButton;

        [FindsBy(How = How.ClassName, Using = "btn btn-default tab-backward")]
        private IWebElement CreateAccountButton;

        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void GoToPage(String queryParams = "")
        {
            driver.Navigate().GoToUrl("https://aws-test.taxact.com/" + queryParams);
        }

        internal void Close()
        {
            driver.Close();
        }

        public void ClickSignIn()
        {
           Actions.ClickOn(driver, SignInButton);
        }

        public void ClickCreateAccount()
        {
            Actions.ClickOn(driver, CreateAccountButton);
        }

        public void TypeEmail(string ParamEmail)
        {
            Actions.Type(driver, Email, ParamEmail);
        }

    }
}
