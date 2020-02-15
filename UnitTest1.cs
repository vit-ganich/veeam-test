using System;
using NUnit.Framework;

namespace VeeamTest
{
    //[Parallelizable(ParallelScope.Fixtures)]
    [TestFixture]
    public class Test_01 : BaseTest
    {
        [Test]
        public void SmokeTest()
        {
            BasePage page = new BasePage(WebDriver.Driver);
            page.Load();
            var element = page.D
        }
    }
}
