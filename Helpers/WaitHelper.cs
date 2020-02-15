using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace VeeamTest.Helpers
{
    public static class WaitHelper
    {
        private const int DefaultTimeooutSec = 10;
        public static WebDriverWait DefaultWait(int timeoutSec = DefaultTimeooutSec)
        {
            if (WebDriver.Driver == null)
                throw new ArgumentNullException(nameof(WebDriver.Driver));

            var _wait = new WebDriverWait(WebDriver.Driver, TimeSpan.FromSeconds(timeoutSec));
            _wait.IgnoreExceptionTypes(typeof(NoSuchElementException),
                                       typeof(ElementNotVisibleException),
                                       typeof(ElementNotInteractableException),
                                       typeof(StaleElementReferenceException),
                                       typeof(ElementClickInterceptedException));

            return _wait;
        }

        public static void WaitFor(Action action, int timeoutSec = DefaultTimeooutSec)
        {
            DefaultWait(timeoutSec).Until((d) =>
            {
                action();
                return true;
            });
        }
    }
}
