using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace VeeamTest.Options
{
    public interface ITestOptions
    {
        IWebDriver GetDriver();
    }
}
