using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationWithSelenium
{
    public class S_Mouse
    {
        /// <summary>
        /// Click on a web element and wait for page load
        /// </summary>
        /// <param name="pElement">The Web Element is used</param>
        public static void Click(IWebElement pElement)
        {
            pElement.Click();
        }

        /// <summary>
        /// Capture the UI control and click on it
        /// </summary>
        /// <param name="pBy"></param>
        public static void Click(By pBy)
        {
            Click(F_General.CaptureInterface(pBy));
        }

        /// <summary>
        /// Select a value in a third party dropdown list
        /// </summary>
        /// <param name="pElement">The Web Element is used</param>
        /// <param name="pValue">The selected value</param>
        public static void SelectTelerikDropdown(IWebElement pElement, string pValue)
        {
            S_Mouse.TelerikClick(pElement.FindElement(By.XPath("following::span[@class='selectBox-arrow'][1]")));
            S_Mouse.TelerikClick(ConstantsLib.Driver.FindElement(By.XPath("//ul[contains(@class,'selectBox-options-')]/li[.='" + pValue + "']/a")));
        }

        /// <summary>
        /// Select a value in a third party dropdown list
        /// </summary>
        /// <param name="pBy">Provides a mechanism by which to find elements within a document</param>
        /// <param name="pValue">The selected value</param>
        public static void SelectTelerikDropdown(By pBy, string pValue)
        {
            SelectTelerikDropdown(F_General.CaptureInterface(pBy), pValue);
        }

        /// <summary>
        /// Select checkbox if it is unchecked, if checked, do nothing
        /// </summary>
        /// <param name="pElement">Checkbox control</param>
        public static void SelectCheckbox(IWebElement pElement)
        {
            if (!pElement.Selected)
                S_Mouse.Click(pElement);
            else
                return;
        }

        /// <summary>
        /// Select checkbox if it is unchecked, if checked, do nothing
        /// </summary>
        /// <param name="pBy">Provides a mechanism by which to find elements within a document</param>
        public static void SelectCheckbox(By pBy)
        {
            SelectCheckbox(F_General.CaptureInterface(pBy));
        }

        /// <summary>
        /// UnSelectSelect checkbox if it is checked
        /// </summary>
        /// <param name="pElement"></param>
        public static void UnselectCheckbox(IWebElement pElement)
        {
            if (pElement.Selected)
            {
                S_Mouse.Click(pElement);
            }
            else
                return;
        }

        /// <summary>
        /// Unselect checkbox if it is checked
        /// </summary>
        /// <param name="pBy">Provides a mechanism by which to find elements within a document</param>
        public static void UnselectCheckbox(By pBy)
        {
            UnselectCheckbox(F_General.CaptureInterface(pBy));
        }

        /// <summary>
        /// Click on a web element
        /// </summary>
        /// <param name="pElement">The Web Element is clicked</param>
        public static void TelerikClick(IWebElement pElement)
        {
            if (pElement.Size.Height <= 0)
                return;
            Actions action = new Actions(ConstantsLib.Driver);
            action.Click(pElement).Perform();
        }

        /// <summary>
        /// Click on a web element
        /// </summary>
        /// <param name="pBy">Provides a mechanism by which to find elements within a document</param>
        public static void TelerikClick(By pBy)
        {
            TelerikClick(F_General.CaptureInterface(pBy));
        }
    }
}
