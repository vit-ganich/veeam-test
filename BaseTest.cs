using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using VeeamTest.Options;

namespace VeeamTest
{
    [TestFixture]
    public class BaseTest<TDriverOptions>
        where TDriverOptions : ITestOptions, new()
    {
        private TDriverOptions options;

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
            WebDriver.Driver = Options.GetDriver();
        }
        
        [TearDown]
        public void TearDown()
        {
            WebDriver.Driver.Quit();
        }  
    }
}
