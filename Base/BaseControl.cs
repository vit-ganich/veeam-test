using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace VeeamTest.Base
{
    public class BaseControl : IBaseControl
    {
        private const int DefaultTimeoutSec = 10;
        public IWebElement Element => GetElement();

        public IPage Page { get; set; }

        public By Locator { get; set; }

        public BaseControl(By locator, IPage testPage)
        {
            this.Locator = locator ?? throw new ArgumentNullException(nameof(locator));
            this.Page = testPage ?? throw new ArgumentNullException(nameof(testPage));
        }

        private IWebElement GetElement(int timeoutSec = DefaultTimeoutSec)
        {
            return DefaultWait(timeoutSec).Until((d) =>
            {
                var elem = d.FindElement(Locator);

                if (elem != null && elem.Enabled)
                    return elem;
                else
                    return null;
            });
        }

        public WebDriverWait DefaultWait(int timeoutSec = DefaultTimeoutSec)
        {
            if (Page.Driver == null)
                throw new ArgumentNullException(nameof(Page.Driver));

            var _wait = new WebDriverWait(Page.Driver, TimeSpan.FromSeconds(timeoutSec));
            _wait.IgnoreExceptionTypes(typeof(NoSuchElementException),
                                       typeof(ElementNotVisibleException),
                                       typeof(ElementNotInteractableException),
                                       typeof(StaleElementReferenceException),
                                       typeof(ElementClickInterceptedException));

            return _wait;
        }

        public IWebElement GetChildElement(By locator, int timeoutSec = DefaultTimeoutSec)
        {
            return DefaultWait(timeoutSec).Until(d =>
            {
                var elem = Element.FindElement(locator);

                if (elem != null)
                    return elem;
                else
                    return null;
            });
        }

        public void WaitFor(Action action, int timeoutSec = DefaultTimeoutSec)
        {
            DefaultWait(timeoutSec).Until((d) =>
            {
                action();
                return true;
            });
        }

        public string GetAttribute(string attribute, int timeoutSec = DefaultTimeoutSec)
        {
            return DefaultWait(timeoutSec).Until((d) =>
            {
                var x = Element.GetAttribute(attribute);

                if (x != null)
                    return x;
                else
                    return null;
            });
        }

        public void ExecuteJavaScript(string script, params object[] args)
        {
            IJavaScriptExecutor js = Page.Driver as IJavaScriptExecutor;
            try
            {
                js.ExecuteScript(script, Element);
            }
            catch (Exception ex)
            {
                Console.WriteLine("JS script failed: " + ex.Message + Locator);
            }
        }
    }
}
