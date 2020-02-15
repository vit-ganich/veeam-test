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
            var element = WaitHelper.DefaultWait().Until(d =>
            {
                var elem = d.FindElement(locator);

                if (elem != null)
                    return elem;
                else
                    return null;
            });
            return element ?? throw new NoSuchElementException(nameof(locator));
        }

        public static IWebElement GetChildElement(IWebElement parent, By locator)
        {
            var element = WaitHelper.DefaultWait().Until(d =>
            {
                var elem = parent.FindElement(locator);

                if (elem != null)
                    return elem;
                else
                    return null;
            });
            return element ?? throw new NoSuchElementException(nameof(locator));
        }
    }
}
