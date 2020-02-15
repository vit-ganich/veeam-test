using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace VeeamTest.Helpers
{
    public class JSExecHelper
    {
        public static bool ScrollElementIntoView(By locator)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver.Driver;
            var element = GenericHelper.GetElement(locator);
            try
            {
                js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("JS scroll into view failed: " + ex.Message);
                return false;
            }
        }

        public static bool ScrollElementIntoView(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver.Driver;
            try
            {
                js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("JS scroll into view failed: " + ex.Message);
                return false;
            }
        }
    }
}
