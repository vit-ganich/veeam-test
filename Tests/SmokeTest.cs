using System;
using NUnit.Framework;
using VeeamTest.Options;
using VeeamTest.Pages;

namespace VeeamTest.Tests
{
    [Parallelizable(ParallelScope.Fixtures)]
    [TestFixture(typeof(OptionsChrome)), TestFixture(typeof(OptionsFirefox))]
    public class SmokeTest<TPage, TDriverOptions> : BaseTest<MainPage, TDriverOptions>
        where TDriverOptions : ITestOptions, new()
    {
        [Test]
        public void JobSearchTest()
        {
            Page.Select(Page.CountriesList, "Romania")
                .Select(Page.CitiesList, "Bucharest")
                .Select(Page.DepartementsList, "IT")
                .Select(Page.LanguagesList, "7")
                .Read(Page.JobSearchResults, out string actualResult);
            Assert.AreEqual("5 jobs found", actualResult);
        }
        //[Test]
        //public void SmokeTest()
        //{
        //    MainPage page = new MainPage();
        //    page.SelectItemByText(page.CountriesDropDown, "Romania")
        //        .SelectCheckBoxById(page.LanguagesDropDown, "7")
        //        .GetJobSearchResult(out string actualResult);
        //    Assert.AreEqual("33 jobs found", actualResult);
        //}

        //[Test]
        //public void ExtendedSmokeTest()
        //{
        //    MainPage page = new MainPage();
        //    page.SelectItemByText(page.CountriesDropDown, "Romania")
        //        .SelectItemByText(page.CitiesDropDown, "Bucharest")
        //        .SelectItemByText(page.DepartementsList, "IT")
        //        .SelectCheckBoxById(page.LanguagesDropDown, "7")
        //        .GetJobSearchResult(out string actualResult);
        //    Assert.AreEqual("5 jobs found", actualResult);
        //}
    }
}
