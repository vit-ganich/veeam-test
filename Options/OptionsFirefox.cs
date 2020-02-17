using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace VeeamTest.Options
{
    public class OptionsFirefox : ITestOptions
    {
        public IWebDriver GetDriver()
        {
            var options = new FirefoxOptions();
            options.AcceptInsecureCertificates = true;
            options.AddArgument("--headless"); // For Healdless mode

            var driver = new FirefoxDriver(options);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
