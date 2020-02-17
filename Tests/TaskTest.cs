using NUnit.Framework;
using VeeamTest.Base;
using VeeamTest.Options;
using VeeamTest.Pages;

namespace VeeamTest.Tests
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture(typeof(OptionsChrome)), TestFixture(typeof(OptionsFirefox)), TestFixture(typeof(OptionsIE))]
    class TaskTest<TDriverOptions> : BaseTest<MainPage, TDriverOptions>
        where TDriverOptions : ITestOptions, new()
    {
        [TestCase("Romania", "English", ExpectedResult = "33 jobs found")]
        [TestCase("Vietnam", "English", ExpectedResult = "1 job found")]
        [TestCase("Netherlands", "Dutch", ExpectedResult = "4 jobs found")]
        [TestCase("Russian Federation", "German", ExpectedResult = "2 jobs found")]
        [TestCase("Argentina", "English", ExpectedResult = "5 jobs found")]
        public string SmokeJobSearch(string country, string langID)
        {
            Page.Select(Page.CountriesList, country)
            .Select(Page.LanguagesList, langID)
            .Read(Page.JobSearchResults, out string actualResult);
            return actualResult;
        }
    }
}
