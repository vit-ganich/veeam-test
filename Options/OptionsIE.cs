using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace VeeamTest.Options
{
    public class OptionsIE : ITestOptions
    {
        public IWebDriver GetDriver()
        {
            var options = new InternetExplorerOptions
            {
                IgnoreZoomLevel = true,
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                EnablePersistentHover = true,
                RequireWindowFocus = true
            };

            //var driver = new InternetExplorerDriver(path, options);
            var driver = new InternetExplorerDriver(options);

            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}
