using System;
using NUnit.Framework;
using VeeamTest.Options;

namespace VeeamTest
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture(typeof(OptionsChrome)), TestFixture(typeof(OptionsFirefox))]
    public class Test_01<TDriverOptions> : BaseTest<TDriverOptions>
        where TDriverOptions : ITestOptions, new()
    {
        [Test]
        public void SmokeTest()
        {
            BasePage page = new BasePage();
            page.SelectItemByText(page.CountriesDropDown, "Romania")
                .SelectCheckBoxById(page.LanguagesDropDown, "7")
                .GetJobSearchResult(out string actualResult);
            Assert.AreEqual("33 jobs found", actualResult);
        }

        [Test]
        public void ExtendedSmokeTest()
        {
            BasePage page = new BasePage();
            page.SelectItemByText(page.CountriesDropDown, "Romania")
                .SelectItemByText(page.CitiesDropDown, "Bucharest")
                .SelectItemByText(page.DepartementsDropDown, "IT")
                .SelectCheckBoxById(page.LanguagesDropDown, "7")
                .GetJobSearchResult(out string actualResult);
            Assert.AreEqual("5 jobs found", actualResult);
        }
    }
}
