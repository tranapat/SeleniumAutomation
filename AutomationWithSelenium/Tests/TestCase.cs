using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationWithSelenium.Tests
{
    [CodedUITest]
    public class TestCase : TestInit
    {
        [TestMethod]
        public void FirstTestCase()
        {
            ConstantsLib.Driver.Navigate().GoToUrl("https://google.com");
        }
    }
}
