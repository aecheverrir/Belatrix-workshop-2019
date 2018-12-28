using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training_QA_Automation;
using Training_QA_Automation.Framework.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Training_QA_Automation
{
    [TestClass]
    public class UnitTest1
    {
        private RegistrationPage regPage;
//        private IWebDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
//           driver = new EdgeDriver(@"C:\Users\Alejandro.Echerverri\Downloads");
//           regPage = new RegistrationPage(driver);
        }

        [TestMethod]
        public void TestMethod1()
        {
//            regPage.GoToPage();
//            regPage.ClickSignIn();
//            regPage.ClickCreateAccount();
//            regPage.TypeEmail("testemail@mail.com");
        }

        [TestCleanup]
        public void TestCleanup()
        {
//            regPage.Close();
        }
    }
}
