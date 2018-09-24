using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTest.PageObjectModel
{
    public class HomePageModel
    {
        public void NewCustomer()
        {
            GlobalSettings.Driver.FindElement(By.XPath("//div/ul/li/a[text()='New Customer']")).Click();
        }
    }
}
