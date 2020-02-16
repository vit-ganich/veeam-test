using System;
using OpenQA.Selenium;

namespace VeeamTest.Helpers
{
    public static class JSExecHelper
    {
        public static bool ScrollElementIntoView(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
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
