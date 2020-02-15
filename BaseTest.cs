using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace VeeamTest
{
    [TestFixture]
    public class BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            WebDriver.Driver = GetDriver();
        }

        private IWebDriver GetDriver()
        {
            string driverFromConfig = "chrome";
            switch (driverFromConfig)
            {
                case "chrome":
                    return Chrome();
                case "firefox":
                    return Firefox();
            }
            throw new ArgumentException("Invalid driver type in config");
        }
        private IWebDriver Chrome()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            // options.AddArgument("--headless");
            return new ChromeDriver(options);
        }

        private IWebDriver Firefox()
        {
            var options = new FirefoxOptions();
            options.AcceptInsecureCertificates = true;
            // options.AddArgument("--headless");

            var driver = new FirefoxDriver(options);
            driver.Manage().Window.Maximize();
            return driver;
        }
        [TearDown]
        public void TearDown()
        {
            WebDriver.Driver.Quit();
        }


        
    }
}
