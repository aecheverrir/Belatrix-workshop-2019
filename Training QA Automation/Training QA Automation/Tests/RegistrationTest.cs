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
        private IWebDriver driver;

        private string sauceUserName;
        private string sauceAccessKey;

        [TestInitialize]
        public void TestInitialize()
        {

            sauceUserName = "aecheverri";
            sauceAccessKey = "51301cae-9ded-46a1-9afb-6c83eb7988ae";

            ChromeOptions options = new ChromeOptions();
            options.AddAdditionalCapability(CapabilityType.Version, "latest", true);
            options.AddAdditionalCapability(CapabilityType.Platform, "Windows 10", true);
            options.AddAdditionalCapability("username", sauceUserName, true);
            options.AddAdditionalCapability("accessKey", sauceAccessKey, true);

            driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), options.ToCapabilities(),
            TimeSpan.FromSeconds(600));

            regPage = new RegistrationPage(driver);
        }

        [TestMethod]
        public void TestMethod1()
        {
            regPage.GoToPage();
            regPage.ClickSignIn();
            regPage.ClickCreateAccount();
            regPage.TypeEmail("testemail@mail.com");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
