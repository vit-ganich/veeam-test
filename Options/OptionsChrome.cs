using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VeeamTest.Options
{
    public class OptionsChrome : ITestOptions
    {
        public IWebDriver GetDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--headless");
            return new ChromeDriver(options);
        }
    }
}
