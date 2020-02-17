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
            options.AddArguments("--headless", "--window-size=1920,1080"); // For Healdless mode
            return new ChromeDriver(options);
        }
    }
}
