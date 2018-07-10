using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationWithSelenium
{
    public class S_Keyboard
    {
        /// <summary>
        /// Send a string to a web element
        /// </summary>
        /// <param name="pElement">The Web Element is used</param>
        /// <param name="pValue">The string to type to the element</param>
        public static void SendKey(IWebElement pElement, string pValue)
        {
            pElement.SendKeys(pValue);
        }

        /// <summary>
        /// Send a string to a web element
        /// </summary>
        /// <param name="pBy">Provides a mechanism by which to find elements within a document</param>
        /// <param name="pValue">The string to type to the element</param>
        public static void SendKey(By pBy, string pValue)
        {
            SendKey(F_General.CaptureInterface(pBy), pValue);
        }

        /// <summary>
        /// Clear content in a web element
        /// </summary>
        /// <param name="pElement">The Web Element is used</param>
        public static void Clear(IWebElement pElement)
        {
            pElement.Clear();
        }

        /// <summary>
        /// Clear content in a web element
        /// </summary>
        /// <param name="pBy">Provides a mechanism by which to find elements within a document</param>
        public static void Clear(By pBy)
        {
            Clear(F_General.CaptureInterface(pBy));
        }

        /// <summary>
        /// Telerik Send Key
        /// </summary>
        /// <param name="pElement">The Web Element is used</param>
        /// <param name="pValue">The string to type to the element</param>
        public static void TelerikSendKey(IWebElement pElement, string pValue)
        {
            Actions action = new Actions(ConstantsLib.Driver);
            action.SendKeys(pElement, pValue).Perform();
        }

        /// <summary>
        /// Telerik Send Key
        /// </summary>
        /// <param name="pBy">Provides a mechanism by which to find elements within a document</param>
        /// <param name="pValue">The string to type to the element</param>
        public static void TelerikSendKey(By pBy, string pValue)
        {
            TelerikSendKey(F_General.CaptureInterface(pBy), pValue);
        }
    }
}
