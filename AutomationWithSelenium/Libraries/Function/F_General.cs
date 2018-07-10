using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;
using System.Linq;

namespace AutomationWithSelenium
{
    public class F_General
    {
        /// <summary>
        /// Capture the interface
        /// </summary>
        /// <param name="pBy">Provides a mechanism by which to find elements within a document</param>
        /// <returns>Return a IWebElement</returns>
        public static IWebElement CaptureInterface(By pBy)
        {
            try { return ConstantsLib.Driver.FindElement(pBy); }
            catch { return null; }
        }

        /// <summary>
        /// Wait until an element is visible
        /// </summary>
        /// <param name="pBy">Provides a mechanism by which to find elements within a document</param>
        /// <param name="pTimeout">The maximum time to wait</param>
        public static void WaitForElementVisible(By pBy, int pTimeout = 0)
        {
            if (pTimeout == 0)
                pTimeout = ConstantsLib.TimeOut;

            DateTime first = DateTime.Now;
            DateTime second = DateTime.Now;
            while ((second - first).Seconds <= pTimeout)
            {
                IWebElement mEle = F_General.CaptureInterface(pBy);
                if (mEle == null || mEle.Displayed == false)
                {
                    Thread.Sleep(1000);
                    second = DateTime.Now;
                }
                else
                    break;
            }
        }

        /// <summary>
        /// Wait until an element is not visible
        /// </summary>
        /// <param name="pBy">Provides a mechanism by which to find elements within a document</param>
        /// <param name="pTimeout">The maximum time to wait</param>
        public static void WaitForElementNotVisible(By pBy, int pTimeout = 0)
        {
            if (pTimeout == 0)
                pTimeout = ConstantsLib.TimeOut;

            DateTime first = DateTime.Now;
            DateTime second = DateTime.Now;
            ConstantsLib.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Convert.ToDouble(5)));
            while ((second - first).Seconds <= pTimeout)
            {
                IWebElement mEle = F_General.CaptureInterface(pBy);
                if (mEle != null && mEle.Displayed)
                {
                    Thread.Sleep(1000);
                    second = DateTime.Now;
                }
                else
                    break;
            }
        }

        /// <summary>
        /// Wait for element attribute changed to another value
        /// </summary>
        /// <param name="pBy">Provides a mechanism by which to find elements within a document/param>
        /// <param name="pAttribute">The attribute name</param>
        /// <param name="pDefaultValue">Value need to wait to be changed</param>
        /// <param name="pTimeout">Maximum time to wait (seconds)</param>
        public static void WaitForElementAttributeChanged(By pBy, string pAttribute, string pDefaultValue, bool pIsExact = false, int pTimeout = 0)
        {
            if (pTimeout == 0)
                pTimeout = ConstantsLib.TimeOut;

            DateTime mFrom = DateTime.Now;
            DateTime mTo = DateTime.Now;
            while ((mTo - mFrom).Seconds < pTimeout)
            {
                IWebElement mEle = F_General.CaptureInterface(pBy);
                if (pIsExact == false)
                {
                    if (mEle.GetAttribute(pAttribute).Contains(pDefaultValue))
                    {
                        Thread.Sleep(2000);
                        mTo = DateTime.Now;
                    }
                    else break;
                }
                else if (mEle.GetAttribute(pAttribute) == pDefaultValue)
                {
                    Thread.Sleep(2000);
                    mTo = DateTime.Now;
                }
                else break;
            }
        }

        /// <summary>
        /// Wait for element attribute changed to expected value
        /// </summary>
        /// <param name="pBy">Provides a mechanism by which to find elements within a document/param>
        /// <param name="pAttribute">The attribute name</param>
        /// <param name="pExpectedValue">Value need to wait to be changed</param>
        /// <param name="pTimeout">Maximum time to wait (seconds)</param>
        public static void WaitForElementAttributeChangedToExpectedValue(By pBy, string pAttribute, string pExpectedValue, int pTimeout = 0)
        {
            if (pTimeout == 0)
                pTimeout = ConstantsLib.TimeOut;

            DateTime mFrom = DateTime.Now;
            IWebElement mEle = F_General.CaptureInterface(pBy);
            DateTime mTo = DateTime.Now;
            while ((mTo - mFrom).Seconds < pTimeout)
            {
                if (!mEle.GetAttribute(pAttribute).Contains(pExpectedValue))
                    Thread.Sleep(2000);
                else break;
            }
        }

        /// <summary>
        /// Generate a random string
        /// </summary>
        /// <param name="pSize">Size of the generated string</param>
        /// <returns>Return the randomed string</returns>
        public static string RandomString(int pSize = 20)
        {
            string mChars = " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random mRandom = new Random();
            string mResult = new string(
                Enumerable.Repeat(mChars, pSize - 16)
                          .Select(s => s[mRandom.Next(1, mChars.Length)])
                          .ToArray());
            return DateTime.Now.ToString("yyyyMMddhhmmssffff") + mResult;
        }
    }
}
