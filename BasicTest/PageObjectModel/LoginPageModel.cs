using BasicTest.PageObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace BasicTest.PageObject
{
    public static class LoginPageModel
    {
        private static IWebElement currentElement;
        public static HomePageModel TestLogin(List<TestCaseModel> testCaseModels)
        {
            foreach (TestCaseModel testCaseModel in testCaseModels)
            {
                currentElement = Utilities.GetSingleElement(testCaseModel.GetBy, testCaseModel.ElementCode);
                Assert.IsNotNull(currentElement, "Không tìm thấy Element với type: " + testCaseModel.GetBy + " và element: " + testCaseModel.ElementCode);
                if (currentElement != null)
                {
                    Utilities.ExecuteAction(currentElement, testCaseModel.Action, testCaseModel.Value);
                    if (testCaseModel.Expected != null)
                    {
                        switch (testCaseModel.Expected)
                        {
                            case Expected.Hide:
                                Assert.IsFalse(GlobalSettings.Driver.FindElement(By.XPath(testCaseModel.ElementCode)).Displayed);
                                return null;

                            case Expected.Show:
                                Assert.IsTrue(GlobalSettings.Driver.FindElement(By.XPath(testCaseModel.ElementCode)).Displayed);
                                Assert.AreEqual(testCaseModel.Message, GlobalSettings.Driver.FindElement(By.XPath(testCaseModel.ElementCode)).Text, "Message sai");
                                Console.WriteLine("Pass_De trong");
                                return null;
                            default:
                                return new HomePageModel();
                        }
                    }
                }
            }
            return null;
        }
    }
}
