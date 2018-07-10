using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace AutomationWithSelenium
{
    public class F_GeneralVerification
    {
        /// <summary>
        /// Compare text of actual and expected results
        /// </summary>
        /// <param name="pFieldName">Name of the element</param>
        /// <param name="pActualResult">Actual value displays on the web</param>
        /// <param name="pExpectedResult">Expected value needed to compare</param>
        /// <param name="pResult">Flag that indicates result of the test case</param>
        /// <param name="pMsg">Message of failure</param>
        public static void VerifyElementValue(string pFieldName, string pActualResult, string pExpectedResult, ref bool pResult, ref string pMsg)
        {
            if (pActualResult.TrimStart() != pExpectedResult)
            {
                pResult = false;
                pMsg += pFieldName + " displays " + pActualResult + " instead of " + pExpectedResult + ".\r\n";
            }
        }

        /// <summary>
        /// Verify if an element does not exist
        /// </summary>
        /// <param name="pElement">Element Name</param> 
        /// <param name="pElementName">Element name which is expected to appear in the message</param>
        /// <param name="pResult">Flag that indicates result of the test case</param>
        /// <param name="pMsg">Message of failure</param>
        public static void VerifyElementNotExist(IWebElement pElement, string pElementName, ref bool pResult, ref string pMsg)
        {
            ConstantsLib.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            if (pElement != null && pElement.Displayed)
            {
                pResult = false;
                pMsg += "This " + pElementName + " still exists.\r\n";
            }
            ConstantsLib.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(ConstantsLib.TimeOut));
        }

        /// <summary>
        /// Verify if a element exists
        /// </summary>
        /// <param name="pElement">Element to verify</param>
        /// <param name="pElementName">Control name to appear in the message</param>
        /// <param name="pResult">Flag that indicates result of the test case</param>
        /// <param name="pMsg">Message of failure</param>
        public static void VerifyElementExist(IWebElement pElement, string pElementName, ref bool pResult, ref string pMsg)
        {
            if (pElement == null || pElement.Displayed == false)
            {
                pResult = false;
                pMsg += "This " + pElementName + " does not exist.\r\n";
            }
        }
    }
}
