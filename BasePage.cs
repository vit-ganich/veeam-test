using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using VeeamTest.Helpers;

namespace VeeamTest
{
    public class BasePage
    {
        IWebDriver driver = WebDriver.Driver;
        
        private const string PageUrl = "https://careers.veeam.com/";

        private By CountriesList => By.Id("country-element");

        private By CitiesList => By.Id("city-element");

        private By DepartementsList => By.Id("department-element");

        private By LanguagesList => By.Id("language");

        public bool Load()
        {
            driver.Navigate().GoToUrl(PageUrl);
            var checkLoad = GenericHelper.GetElement(By.CssSelector(".navbar-brand img"));

            return checkLoad != null;
        }


        public bool SelectByText(IWebElement element, string whatToSelect)
        {
            string findPattern = string.Format("//span[contains(text(), '{0}')]", whatToSelect);

            element.FindElement(By.Id("selecter-selected")).Click();
            var el = element.FindElement(By.XPath(findPattern));
            el.Click();
            return true;
        }

        public bool SelectDepartment()
        {
            Select(DepartementsList, "sales");
            return true;
        }
        public void Select(IWebElement element, string byText)
        {
            DropDownHelper.SelectElement(element, byText);
        }

    }
}
