using NUnit.Framework;
using VeeamTest.Base;
using VeeamTest.Options;
using VeeamTest.Pages;

namespace VeeamTest.Tests
{
    /// <summary>
    /// These tests are unstable on Chrome. Need time to fix it.
    /// </summary>
    /// <typeparam name="TDriverOptions"></typeparam>
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture(typeof(OptionsChrome)), TestFixture(typeof(OptionsFirefox)), TestFixture(typeof(OptionsIE))]
    public class BonusTestsUnstable<TDriverOptions> : BaseTest<MainPage, TDriverOptions>
        where TDriverOptions : ITestOptions, new()
    {
        [TestCase("Romania", "Bucharest", "IT", "English", ExpectedResult = "5 jobs found")]
        [TestCase("Romania", "Bucharest", "blank", "English", ExpectedResult = "33 jobs found")]
        [TestCase("Slovakia", "Bratislava", "Sales", "Czech", ExpectedResult = "1 job found")]
        public string JobSearchTest(string country, string city, string department, string langId)
        {
            Page.Select(Page.CountriesList, country)
                .Select(Page.CitiesList, city)
                .Select(Page.DepartementsList, department)
                .Select(Page.LanguagesList, langId)
                .Read(Page.JobSearchResults, out string actualResult);
            return actualResult;
        }

        [Test]
        public void ClearFiltersTest()
        {
            Page.Select(Page.CountriesList, "Austria")
                .Select(Page.CitiesList, "Vienna")
                .Select(Page.DepartementsList, "Sales")
                .Select(Page.LanguagesList, "English")
                .Click(Page.ClearFilters)
                .Read(Page.JobSearchResults, out string actualResult);
            Assert.AreEqual("74 jobs found", actualResult);
        }
    }
}
