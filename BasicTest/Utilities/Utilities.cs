using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTest
{
    public static class Utilities
    {
        /// <summary>
        /// Khởi tạo các testcase từ file excel
        /// </summary>
        /// <returns></returns>
        public static List<List<TestCaseModel>> GenerateTestCaseObject()
        {
            List<List<TestCaseModel>> result = new List<List<TestCaseModel>>();
            List<TestCaseModel> testCaseModels = new List<TestCaseModel>();
            DataTable dataTable = ImportExportExcel.GetDataBySheetName(GlobalSettings.ExcelFileLocation, GlobalSettings.SheetName);
            foreach (DataRow dr in dataTable.Rows)
            {
                TestCaseModel testCaseModel = new TestCaseModel();
                #region Set Property
                testCaseModel.ElementCode = Convert.ToString(dr[nameof(testCaseModel.ElementCode)]);
                testCaseModel.Value = Convert.ToString(dr[nameof(testCaseModel.Value)]);
                testCaseModel.Message = Convert.ToString(dr[nameof(testCaseModel.Message)]);

                switch (Convert.ToString(dr[nameof(testCaseModel.GetBy)]).ToLower())
                {
                    case "classname":
                        testCaseModel.GetBy = GetBy.ClassName;
                        break;
                    case "cssselector":
                        testCaseModel.GetBy = GetBy.CssSelector;
                        break;
                    case "id":
                        testCaseModel.GetBy = GetBy.Id;
                        break;
                    case "linktext":
                        testCaseModel.GetBy = GetBy.LinkText;
                        break;
                    case "name":
                        testCaseModel.GetBy = GetBy.Name;
                        break;
                    case "partiallinktext":
                        testCaseModel.GetBy = GetBy.PartialLinkText;
                        break;
                    case "tagname":
                        testCaseModel.GetBy = GetBy.TagName;
                        break;
                    case "xpath":
                        testCaseModel.GetBy = GetBy.XPath;
                        break;
                    default:
                        testCaseModel.GetBy = null;
                        break;
                }

                switch (Convert.ToString(dr[nameof(testCaseModel.Action)]).ToLower())
                {
                    case "click":
                        testCaseModel.Action = Action.Click;
                        break;
                    case "entertext":
                        testCaseModel.Action = Action.EnterText;
                        break;
                    default:
                        testCaseModel.Action = null;
                        break;
                }

                switch (Convert.ToString(dr[nameof(testCaseModel.Expected)]).ToLower())
                {
                    case "success":
                        testCaseModel.Expected = Expected.Success;
                        break;
                    case "show":
                        testCaseModel.Expected = Expected.Show;
                        break;
                    case "hide":
                        testCaseModel.Expected = Expected.Hide;
                        break;
                    default:
                        testCaseModel.Expected = null;
                        break;
                }
                #endregion
                testCaseModels.Add(testCaseModel);
                if (!string.IsNullOrEmpty(Convert.ToString(dr[nameof(testCaseModel.Expected)])))
                {
                    result.Add(testCaseModels);
                    testCaseModels = new List<TestCaseModel>();
                }
            }
            return result;
        }

        /// <summary>
        /// Lấy 1 Element
        /// </summary>
        /// <param name="type">Kiểu lấy element</param>
        /// <param name="element">Giá trị của kiểu element</param>
        /// <returns>Trả về 1 IWebElement</returns>
        public static IWebElement GetSingleElement(GetBy? type, string element)
        {
            IWebElement result;
            switch (type)
            {
                case GetBy.ClassName:
                    result = GlobalSettings.Driver.FindElement(By.ClassName(element));
                    break;
                case GetBy.CssSelector:
                    result = GlobalSettings.Driver.FindElement(By.CssSelector(element));
                    break;
                case GetBy.Id:
                    result = GlobalSettings.Driver.FindElement(By.Id(element));
                    break;
                case GetBy.LinkText:
                    result = GlobalSettings.Driver.FindElement(By.LinkText(element));
                    break;
                case GetBy.Name:
                    result = GlobalSettings.Driver.FindElement(By.Name(element));
                    break;
                case GetBy.PartialLinkText:
                    result = GlobalSettings.Driver.FindElement(By.PartialLinkText(element));
                    break;
                case GetBy.TagName:
                    result = GlobalSettings.Driver.FindElement(By.TagName(element));
                    break;
                case GetBy.XPath:
                    result = GlobalSettings.Driver.FindElement(By.XPath(element));
                    break;
                default: result = null; break;
            }
            return result;
        }

        /// <summary>
        /// Thực hiện 1 Action
        /// </summary>
        /// <param name="element">IWebElement cần thực hiện action</param>
        /// <param name="action">Action cần thực hiện</param>
        /// <param name="value">Giá trị cần truyền</param>
        public static void ExecuteAction(IWebElement element, Action? action, string value)
        {
            switch (action)
            {
                case Action.Click:
                    element.Click();
                    break;
                case Action.EnterText:
                    element.SendKeys(value);
                    break;
                case Action.Select:
                    new SelectElement(element).SelectByText(value);
                    break;
            }
        }
    }
}
