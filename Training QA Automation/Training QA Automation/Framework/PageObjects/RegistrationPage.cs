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
        [FindsBy(How = How.Id, Using = "sign-in-desk")]
        private IWebElement SignInButton;

        [FindsBy(How = How.CssSelector, Using = "a.btn")]
        private IWebElement CreateAccountButton;

        [FindsBy(How = How.Name, Using = "Email")]
        private IWebElement Email;

        [FindsBy(How = How.CssSelector, Using = ".auth-forward")]
        private IWebElement NextButtonStep1;

        [FindsBy(How = How.Id, Using = "SecurityCodeViewModel_Code1")]
        private IWebElement VerificationCodeDigit1;

        [FindsBy(How = How.CssSelector, Using = ".tab-forward")]
        private IWebElement VerifyButton;

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

        public string GenerateMail()
        {
            //random 8 digit number
            Random random = new Random();
            return "" + (random.Next(10000000, 99999999));
        }

        public void ClickCreateAccount()
        {
            Actions.ClickOn(driver, CreateAccountButton);
        }

        public void TypeEmail(string ParamEmail)
        {
            Actions.Type(driver, Email, ParamEmail);
        }

        public void ClickNextStep1()
        {
            Actions.ClickOn(driver, NextButtonStep1);
        }

        public void TypeVerificationCode(string ParamCode)
        {
            Actions.Type(driver, VerificationCodeDigit1, ParamCode);
        }

        public void ClickVerifyEmail()
        {
            Actions.ClickOn(driver, VerifyButton);
        }





    }
}
