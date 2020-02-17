using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace VeeamTest.Base
{
    public interface IBaseControl
    {
        IWebElement Element { get; }
        IPage Page { get; }
        By Locator { get; }
        WebDriverWait DefaultWait(int timeoutSec);
        IWebElement GetChildElement(By locator, int timeoutSec);
        void WaitFor(Action action, int timeoutSec);
        string GetAttribute(string attribute, int timeoutSec);
    }
}
