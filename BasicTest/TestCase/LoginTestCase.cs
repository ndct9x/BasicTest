using BasicTest.PageObject;
using BasicTest.PageObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTest.TestCase
{
    class LoginTestCase
    {
        [SetUp]
        public void OpenBrower()
        {
            GlobalSettings.Driver = new ChromeDriver(GlobalSettings.WebDriverLocation);
            GlobalSettings.Driver.Manage().Window.Maximize();
            GlobalSettings.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            GlobalSettings.Driver.Url = GlobalSettings.WebURL;
        }

        [Test, TestCaseSource(nameof(AllLoginTestCase))]
        public void TestLogin(List<TestCaseModel> testCaseModels)
        {
            HomePageModel home = LoginPageModel.TestLogin(testCaseModels);
        }

        //[Test, TestCaseSource(nameof(AllLoginTestCase))]
        //public void AddUser(List<TestCaseModel> testCaseModels)
        //{
        //    HomePageModel home = LoginPageModel.TestLogin(testCaseModels);
        //    if (home != null)
        //    {
        //        home.NewCustomer();
        //    }
        //}

        [TearDown]
        public void CloseBrowser()
        {
            GlobalSettings.Driver.Close();
        }

        public static List<List<TestCaseModel>> AllLoginTestCase = Utilities.GenerateTestCaseObject();
    }
}
