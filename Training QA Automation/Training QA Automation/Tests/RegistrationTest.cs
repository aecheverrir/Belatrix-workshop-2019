using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training_QA_Automation.Framework.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Training_QA_Automation
{
    [TestClass]
    public class UnitTest1
    {
        private RegistrationPage regPage;
        private EmailInboxPage mailPage;
        private IWebDriver driver;

        private string sauceUserName;
        private string sauceAccessKey;

        [TestInitialize]
        public void TestInitialize()
        {

            sauceUserName = "aecheverrir";
            sauceAccessKey = "f52f7e84-4e1f-47cb-bee8-6dc8786c2555";

            ChromeOptions options = new ChromeOptions();
            options.AddAdditionalCapability(CapabilityType.Version, "latest", true);
            options.AddAdditionalCapability(CapabilityType.Platform, "Windows 10", true);
            options.AddAdditionalCapability("username", sauceUserName, true);
            options.AddAdditionalCapability("accessKey", sauceAccessKey, true);

            driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), options.ToCapabilities(),
            TimeSpan.FromSeconds(600));

            regPage = new RegistrationPage(driver);
            mailPage = new EmailInboxPage(driver);
        }

        [TestMethod]
        public void TestMethod1()
        {
            regPage.GoToPage();
            regPage.ClickSignIn();
            regPage.ClickCreateAccount();
            string randomMail = regPage.GenerateMail();
            regPage.TypeEmail(randomMail + "@getnada.com");
            regPage.ClickNextStep1();
            mailPage.GoToPage();
            mailPage.ClickAddInbox();
            mailPage.TypeInboxName(randomMail);
            mailPage.ClickAccept();
            string verificationCode = mailPage.GetVerificationCode();
            regPage.GoToPage("auth/create-account/verify-email");
            regPage.TypeVerificationCode(verificationCode);
            regPage.ClickVerifyEmail();


        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
