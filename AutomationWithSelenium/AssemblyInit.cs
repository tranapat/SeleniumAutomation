using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationWithSelenium
{
    [CodedUITest]
    public class AssemblyInit
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [AssemblyInitialize]
        public static void Assembly_Init(TestContext context)
        {
            XmlDocument xml = new XmlDocument();
            //xml.Load(ConstantsLib.Init_Folder + "Init.xml");

            //ConstantsLib.Payments_URL = xml.SelectSingleNode("//Payments/URL").InnerText;
        }

        [AssemblyCleanup]
        public static void Assembly_Cleanup()
        {
            Process[] processes = Process.GetProcessesByName("IEDriverServer");

            foreach (Process process in processes)
            {
                process.Kill();
            }
        }
    }
}