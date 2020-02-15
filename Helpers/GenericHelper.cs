using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace VeeamTest.Helpers
{
    public class GenericHelper
    {
        public static IWebElement GetElement(By locator)
        {
            return WaitHelper.DefaultWait().Until(d =>
            {
                var elem = d.FindElement(locator);

                if (elem != null && elem.Displayed)
                    return elem;
                else
                    return null;
            });
        }

        public static IWebElement GetElement(IWebElement element)
        {
            return WaitHelper.DefaultWait().Until(d =>
            {
                if (element != null && element.Displayed)
                    return element;
                else
                    return null;
            });
        }
    }
}
