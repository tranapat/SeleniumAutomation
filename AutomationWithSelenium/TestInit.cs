using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace AutomationWithSelenium
{
    [CodedUITest]
    public class TestInit : AssemblyInit
    {
        public bool Result = true;
        public string Msg = "\r\n";

        [TestInitialize]
        public void Test_Init()
        {
            ConstantsLib.Driver = new InternetExplorerDriver(ConstantsLib.InitFolder);
            ConstantsLib.Driver.Manage().Window.Maximize();
            ConstantsLib.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Convert.ToDouble(ConstantsLib.TimeOut)));
            ConstantsLib.Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(Convert.ToDouble(ConstantsLib.TimeOut)));
            ConstantsLib.Wait = new WebDriverWait(ConstantsLib.Driver, TimeSpan.FromSeconds(Convert.ToDouble(ConstantsLib.TimeOut)));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ConstantsLib.Driver.Quit();
        }
    }
}