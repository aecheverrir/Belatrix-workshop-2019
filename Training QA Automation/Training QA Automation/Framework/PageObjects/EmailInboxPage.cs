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
    public class EmailInboxPage
    {
        private IWebDriver driver;

        //Page Objects
        [FindsBy(How = How.XPath, Using = "/html/body/div/div[2]/div[1]/div/div[2]/nav/a[2]")]
        private IWebElement AddInboxButton;

        [FindsBy(How = How.CssSelector, Using = "input.user_name")]
        private IWebElement MailNameTextField;

        [FindsBy(How = How.CssSelector, Using = "a.button.success")]
        private IWebElement AcceptButton;

        [FindsBy(How = How.XPath, Using = "html/body/div/div[2]/div[2]/div[1]/div[2]/div/div[2]/div/div[1]/ul/li[1]/div/div[2]")]
        private IWebElement EmailTitle;

        public EmailInboxPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void GoToPage(String queryParams = "")
        {
            driver.Navigate().GoToUrl("https://getnada.com/");
        }

        public void ClickAddInbox()
        {
            Actions.ClickOn(driver, AddInboxButton);
        }

        public void TypeInboxName(string mailName)
        {
            Actions.Clear(driver, MailNameTextField);
            Actions.Type(driver, MailNameTextField, mailName);
        }

        public void ClickAccept()
        {
            Actions.ClickOn(driver, AcceptButton);
        }

        public string GetVerificationCode()
        {
            string emailSubject = EmailTitle.Text;

            string[] words = emailSubject.Split(' ');
            string verificationCode = words[words.Length - 1];
            return verificationCode;
        }



    }
}
