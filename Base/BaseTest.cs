using NUnit.Framework;
using OpenQA.Selenium;
using VeeamTest.Options;

namespace VeeamTest.Base
{
    [SetUpFixture]
    public class BaseTest<TPage, TDriverOptions>
        where TPage : BasePage, new()
        where TDriverOptions : ITestOptions, new()
    {
        private IWebDriver driver;
        private TDriverOptions options;

        protected TPage Page { get; set; }

        protected TDriverOptions Options
        {
            get
            {
                if (options == null)
                    options = new TDriverOptions();
                return options;
            }
        }

        [SetUp]
        public void SetUp()
        {
            this.driver = Options.GetDriver();
            Page = new TPage { Driver = this.driver };
            Page.Load();
        }
        
        [TearDown]
        public void TearDown()
        {
            this.driver.Quit();
        }  
    }
}
