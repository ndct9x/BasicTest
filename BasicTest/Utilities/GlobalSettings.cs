using OpenQA.Selenium;
using System;
using System.Configuration;

namespace BasicTest
{
    public static class GlobalSettings
    {
        public static IWebDriver Driver { get; set; }
        public static string WebDriverLocation = Convert.ToString(ConfigurationManager.AppSettings[nameof(WebDriverLocation)]);
        public static string ExcelFileLocation = Convert.ToString(ConfigurationManager.AppSettings[nameof(ExcelFileLocation)]);
        public static string IsRunAllTestCase = Convert.ToString(ConfigurationManager.AppSettings[nameof(IsRunAllTestCase)]);
        public static string SheetName = Convert.ToString(ConfigurationManager.AppSettings[nameof(SheetName)]);
        public static string WebURL = Convert.ToString(ConfigurationManager.AppSettings[nameof(WebURL)]);

    }

    /// <summary>
    /// Các Action của Element
    /// </summary>
    public enum Action
    {
        EnterText,
        Click,
        Select
    }

    /// <summary>
    /// Các kiểu lấy Element
    /// </summary>
    public enum GetBy
    {
        ClassName,
        CssSelector,
        Id,
        LinkText,
        Name,
        PartialLinkText,
        TagName,
        XPath
    }

    /// <summary>
    /// Các kiểu Expected
    /// </summary>
    public enum Expected
    {
        Show,
        Hide,
        Success
    }
}
