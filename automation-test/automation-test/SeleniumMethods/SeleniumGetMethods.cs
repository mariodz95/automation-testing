using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace automation
{
    public class SeleniumGetMethods
    {
        /// <summary>
        /// Get text from input field
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetText(IWebElement element)
        {
            return element.GetAttribute("value"); 
            
        }

        /// <summary>
        /// Get text selected value from dropdown
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetTextFromDropDown(IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }
    }
}
